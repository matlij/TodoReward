using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using TodoReward.Core.Interfaces;
using TodoReward.Core.Models;

namespace TodoReward.ViewModels
{
    public partial class AddItemViewModel : ObservableObject
    {
        private readonly IGenericRepository<TodoItem> _repository;

        [ObservableProperty]
        [NotifyCanExecuteChangedFor(nameof(AddItemCommand))]
        private string _inputTitle = string.Empty;

        [ObservableProperty]
        private double _inputScore;

        public AddItemViewModel(IGenericRepository<TodoItem> repository)
        {
            _repository = repository;
            InputScore = 1;
        }

        [RelayCommand(CanExecute = nameof(CanSaveItem))]
        private async Task AddItem()
        {
            var scoreInt = Convert.ToInt32(InputScore);

            var item = new TodoItem
            { 
                Points = scoreInt, 
                Title = InputTitle 
            };
            await _repository.AddAsync(item);

            await Shell.Current.GoToAsync("..");
        }

        private bool CanSaveItem()
        {
            return string.IsNullOrEmpty(InputTitle) == false;
        }
    }
}
