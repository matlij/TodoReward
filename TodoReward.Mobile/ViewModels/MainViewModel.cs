using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using TodoReward.Core.Interfaces;
using TodoReward.Core.Models;
using TodoReward.Pages;

namespace TodoReward.ViewModels
{
    public partial class MainViewModel : ObservableObject
    {
        private readonly IGenericRepository<TodoItem> _itemRepository;
        private readonly IGenericRepository<User> _userRepository;
        private readonly ITodoItemService _itemService;

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

        public MainViewModel(ITodoItemService todoItemService, IGenericRepository<TodoItem> itemRepository, IGenericRepository<User> userRepository)
        {
            _itemRepository = itemRepository;
            _userRepository = userRepository;
            _itemService = todoItemService;
        }

        [RelayCommand]
        private void ToggleShowAllItems()
        {
            ShowAllItems = !ShowAllItems;
        }

        [RelayCommand]
        private async Task DeleteItem(TodoItem todoItem)
        {
            var navigationParameter = new Dictionary<string, object>
            {
                { "TodoItem", todoItem }
            };
            await Shell.Current.GoToAsync(nameof(PutItemPage), navigationParameter);
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
                var result = await _itemService.CompleteItemAsync(selectedItem);
                if (result.result == false)
                {
                    await Application.Current.MainPage.DisplayAlert("Error!", "Couldn't complete todo item", "OK");
                }
                if (result.result && result.reward is not null)
                {
                    await Application.Current.MainPage.DisplaySnackbar($"Nice job! You have received a reward: {result.reward.Title}", duration: TimeSpan.FromSeconds(3));
                }

                TodaysItems.Remove(selectedItem);
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
