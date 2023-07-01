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
            await LoadItemsAsync();
        }

        private async Task LoadItemsAsync()
        {
            Items.Clear();

            var items = await _itemService.GetAllAsync(item => !item.IsDone);
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

        [RelayCommand]
        private async Task CompleteItems()
        {
            var selectedItemsCopy = new List<TodoItem>(SelectedItems.Cast<TodoItem>());

            foreach (var selectedItem in selectedItemsCopy)
            {
                selectedItem.IsDone = true;
                await _itemService.UpdateAsync(selectedItem.Id, selectedItem);

                Items.Remove(selectedItem);
            }

            //var itemsCopy = new List<TodoItem>(Items);

            //foreach (var selectedItem in SelectedItems.Cast<TodoItem>())
            //{
            //    selectedItem.IsDone = true;
            //    await _itemService.UpdateAsync(selectedItem.Id, selectedItem);

            //    itemsCopy.Remove(selectedItem);
            //}

            //Items = new ObservableCollection<TodoItem>(itemsCopy);
        }
    }
}
