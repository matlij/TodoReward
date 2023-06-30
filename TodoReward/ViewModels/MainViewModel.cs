using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using TodoReward.Models;
using TodoReward.Pages;
using TodoReward.Services;

namespace TodoReward.ViewModels
{
    public partial class MainViewModel : ObservableObject
    {
        private readonly ITodoItemService _itemService;

        [ObservableProperty]
        private ObservableCollection<TodoItem> _items = new();

        [ObservableProperty]
        private List<object> _selectedItems = new();

        public MainViewModel(ITodoItemService itemService)
        {
            _itemService = itemService;
        }

        public async Task Init()
        {
            Items.Clear();

            var items = await _itemService.GetAllAsync();
            foreach (var item in items)
            {
                Items.Add(item);
            }
        }

        [RelayCommand]
        private async Task AddItem()
        {
            await Shell.Current.GoToAsync(nameof(AddItemPage));
        }
    }
}
