using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using TodoReward.Core.Interfaces;
using TodoReward.Core.Models;
using TodoReward.Core.Models.Constants;
using TodoReward.Pages;

namespace TodoReward.ViewModels
{
    public partial class UserViewModel : ObservableObject
    {
        private readonly IGenericRepository<User> _userRepository;

        [ObservableProperty]
        private User _user;

        public UserViewModel(IGenericRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task Init()
        {
            User = await _userRepository.GetByIdAsync(ModelConstants.UserId)
                ?? throw new InvalidOperationException("Cannot find user with ID: " + ModelConstants.UserId);
        }
    }

    public partial class MainViewModel : ObservableObject
    {
        private readonly IGenericRepository<TodoItem> _itemRepository;
        private readonly ITodoItemService _itemService;
        private readonly IRewardService _rewardService;

        [ObservableProperty]
        private ObservableCollection<TodoItem> _todaysItems = new();

        [ObservableProperty]
        private ObservableCollection<TodoItem> _items = new();

        [ObservableProperty]
        private ObservableCollection<object> _selectedItems = new();

        [ObservableProperty]
        private ObservableCollection<object> _selectedTodaysItems = new();

        [ObservableProperty]
        private bool _showAllItems;

        public MainViewModel(ITodoItemService todoItemService, IRewardService rewardService, IGenericRepository<TodoItem> itemRepository)
        {
            _itemRepository = itemRepository;
            _itemService = todoItemService;
            _rewardService = rewardService;
        }

        [RelayCommand]
        private void ToggleShowAllItems()
        {
            ShowAllItems = !ShowAllItems;
        }

        [RelayCommand]
        private async void OpenUserPage()
        {
            await Shell.Current.GoToAsync(nameof(UserPage));
        }

        [RelayCommand]
        private async Task EditItem(TodoItem todoItem)
        {
            var navigationParameter = new Dictionary<string, object>
            {
                { "TodoItem", todoItem }
            };
            await Shell.Current.GoToAsync(nameof(PutItemPage), navigationParameter);

            SelectedItems.Clear();
            SelectedTodaysItems.Clear();
        }

        [RelayCommand]
        private async Task AddItem()
        {
            await Shell.Current.GoToAsync(nameof(PutItemPage));
        }

        [RelayCommand]
        private async Task CompleteItems()
        {
            var selectedItemsCopy = new List<TodoItem>(SelectedTodaysItems.Cast<TodoItem>());

            foreach (var selectedItem in selectedItemsCopy)
            {
                try
                {
                    var todoItemResult = await _itemService.CompleteItemAsync(selectedItem);
                    if (!todoItemResult)
                    {
                        throw new InvalidOperationException("Failed to update Todoitem");
                    }

                    var result = await _rewardService.GetRewardAsync(selectedItem);
                    if (result.MilestoneReached)
                    {
                        await Application.Current.MainPage.DisplaySnackbar($"Milestone reached! Rewards received: {result.RewardsFromCompletedMilestone.Count()}", duration: TimeSpan.FromSeconds(5));
                    }
                    else if (result.RewardReceived)
                    {
                        await Application.Current.MainPage.DisplaySnackbar($"Nice job! You have received a reward: {result.Reward.Title}", duration: TimeSpan.FromSeconds(3));
                    }

                    TodaysItems.Remove(selectedItem);
                }
                catch (Exception e)
                {
                    await Application.Current.MainPage.DisplayAlert("Error!", $"Couldn't complete todo item: {e.Message}", "OK");
                }
            }

            SelectedTodaysItems.Clear();
        }

        [RelayCommand]
        private async void MoveSelectedItemsToTodaysList()
        {
            foreach (var item in SelectedItems)
            {
                var todoItem = item as TodoItem;
                todoItem.IsPartOfDailyTodoList = true;

                var result = await _itemRepository.UpdateAsync(todoItem.Id, todoItem);
                if (result == false)
                {
                    await Application.Current.MainPage.DisplayAlert("Error!", "Couldn't move todo item to todays list", "OK");
                }
            }
            SelectedItems.Clear();

            await LoadItemsAsync();
        }

        public async Task Init()
        {
            await LoadItemsAsync();
        }

        private async Task LoadItemsAsync()
        {
            var items = await _itemRepository.GetBySpecificationAsync(item => !item.IsCompleted);

            var itemsInBacklog = items.Where(item => item.IsPartOfDailyTodoList == false);
            Items.Clear();
            foreach (var item in itemsInBacklog)
            {
                Items.Add(item);
            }

            var todaysItems = items.Where(item => item.IsPartOfDailyTodoList);
            TodaysItems.Clear();
            foreach (var item in todaysItems)
            {
                TodaysItems.Add(item);
            }
        }
    }
}
