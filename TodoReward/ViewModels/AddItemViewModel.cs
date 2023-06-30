using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using TodoReward.Models;
using TodoReward.Services;

namespace TodoReward.ViewModels
{
    public partial class AddItemViewModel : ObservableObject
    {
        private readonly ITodoItemService _itemService;

        [ObservableProperty]
        private string _inputTitle = string.Empty;

        [ObservableProperty]
        private double _inputScore;

        public AddItemViewModel(ITodoItemService itemService)
        {
            _itemService = itemService;
            InputScore = 1;
        }

        [RelayCommand]
        private async Task AddItem()
        {
            var scoreInt = Convert.ToInt32(InputScore);

            var item = new TodoItem
            { 
                Score = scoreInt, 
                Title = InputTitle 
            };
            await _itemService.AddAsync(item);

            await Shell.Current.GoToAsync("..");
        }
    }
}
