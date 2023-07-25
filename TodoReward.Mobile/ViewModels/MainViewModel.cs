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
        private ObservableCollection<TodoItem> _items = new();

        [ObservableProperty]
        private List<object> _selectedItems = new();

        public MainViewModel(ITodoItemService todoItemService, IGenericRepository<TodoItem> itemRepository, IGenericRepository<User> userRepository)
        {
            _itemRepository = itemRepository;
            _userRepository = userRepository;
            _itemService = todoItemService;
        }

        [RelayCommand]
        private async Task DeleteItem(TodoItem todoItem)
        {
            var navigationParameter = new Dictionary<string, object>
            {
                { "TodoItem", todoItem }
            };
            await Shell.Current.GoToAsync(nameof(AddItemPage), navigationParameter);
        }

        [RelayCommand]
        private async Task AddItem()
        {
            await Shell.Current.GoToAsync(nameof(AddItemPage));
        }

        [RelayCommand]
        private async Task CompleteItems()
        {
            var selectedItemsCopy = new List<TodoItem>(SelectedItems.Cast<TodoItem>());

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

                Items.Remove(selectedItem);
            }
        }

        public async Task Init()
        {
            await LoadItemsAsync();
        }

        private async Task LoadItemsAsync()
        {
            Items.Clear();

            var items = await _itemRepository.GetBySpecificationAsync(item => !item.IsCompleted);
            foreach (var item in items)
            {
                Items.Add(item);
            }
        }
    }
}
