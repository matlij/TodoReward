using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using TodoReward.Core.Interfaces;
using TodoReward.Core.Models;

namespace TodoReward.ViewModels
{
    public partial class PutItemViewModel : ObservableObject, IQueryAttributable
    {
        private readonly IGenericRepository<TodoItem> _repository;

        [ObservableProperty]
        [NotifyCanExecuteChangedFor(nameof(DeleteItemCommand))]
        private Guid? _id;

        [ObservableProperty]
        [NotifyCanExecuteChangedFor(nameof(AddOrUpdateItemCommand))]
        private string _inputTitle = string.Empty;

        [ObservableProperty]
        private double _inputPoints;
        [ObservableProperty]
        private bool _isPartOfDailyList;

        [ObservableProperty]
        private string _title;

        public PutItemViewModel(IGenericRepository<TodoItem> repository)
        {
            _repository = repository;
            InputPoints = 1;
            IsPartOfDailyList = true;
        }

        public void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            if (query.TryGetValue("TodoItem", out var item) && item is TodoItem todoItem)
            {
                Title = "Update Todo item";

                InputTitle = todoItem.Title;
                InputPoints = todoItem.Points;
                Id = todoItem.Id;
                IsPartOfDailyList = todoItem.IsPartOfDailyTodoList;
            }
            else
            {
                Title = "Add new Todo item";

                IsPartOfDailyList = true;
            }
        }

        [RelayCommand(CanExecute = nameof(CanSaveItem))]
        private async Task AddOrUpdateItem()
        {
            var scoreInt = Convert.ToInt32(InputPoints);

            var item = new TodoItem
            {
                Id = GuidIsNullOrEmpty(Id) ? Guid.NewGuid() : (Guid)Id,
                Points = scoreInt,
                Title = InputTitle,
                IsPartOfDailyTodoList = IsPartOfDailyList
            };

            var result = GuidIsNullOrEmpty(Id)
                ? await _repository.AddAsync(item)
                : await _repository.UpdateAsync(item.Id, item);

            if (result == false)
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Failed to add or update TodoItem", "OK");
            }

            await Shell.Current.GoToAsync("..");
        }

        [RelayCommand(CanExecute = nameof(CanDeleteItem))]
        private async Task DeleteItem()
        {
            if (Id is null)
            {
                return;
            }

            var userInput = await Application.Current.MainPage.DisplayAlert("Delete todo item?", "Are you sure you want to delete this item?", "Yes", "Cancel");
            if (userInput == false)
            {
                return;
            }

            var result = await _repository.DeleteAsync((Guid)Id);

            if (!result)
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Failed to delete TodoItem", "OK");
            }
            else
            {
                // If the deletion was successful, navigate back
                await Shell.Current.GoToAsync("..");
            }
        }

        private bool CanSaveItem()
        {
            return string.IsNullOrEmpty(InputTitle) == false;
        }

        private bool CanDeleteItem()
        {
            return GuidIsNullOrEmpty(Id) == false;
        }

        private static bool GuidIsNullOrEmpty(Guid? guid) => guid is null || guid == Guid.Empty;
    }
}
