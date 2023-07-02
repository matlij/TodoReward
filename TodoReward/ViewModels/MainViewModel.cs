using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using TodoReward.BusinessLayer.Interfaces;
using TodoReward.BusinessLayer.Models;
using TodoReward.Pages;

namespace TodoReward.ViewModels
{
    public partial class MainViewModel : ObservableObject
    {
        private readonly ITodoItemRepository _itemRepository;
        private readonly ITodoItemService _itemService;

        [ObservableProperty]
        private ObservableCollection<TodoItem> _items = new();

        [ObservableProperty]
        private List<object> _selectedItems = new();

        public MainViewModel(ITodoItemRepository itemRepository, ITodoItemService todoItemService)
        {
            _itemRepository = itemRepository;
            _itemService = todoItemService;
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
                var reward = await _itemService.CompleteItemAsync(selectedItem);
                if (reward != null)
                {
                    await Application.Current.MainPage.DisplayAlert("Alert", "You have been alerted", "OK");
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

            var items = await _itemRepository.GetAllAsync(item => !item.IsCompleted);
            foreach (var item in items)
            {
                Items.Add(item);
            }
        }
    }
}
