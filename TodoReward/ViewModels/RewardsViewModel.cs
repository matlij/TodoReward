using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;
using TodoReward.BusinessLayer.Interfaces;
using TodoReward.BusinessLayer.Models;

namespace TodoReward.ViewModels
{
    public partial class RewardViewModel : ObservableObject
    {
        private readonly IGenericRepository<User> _repository;

        [ObservableProperty]
        private ObservableCollection<Reward> _rewards = new();

        public RewardViewModel(IGenericRepository<User> repository)
        {
            _repository = repository;
        }

        public async Task Init()
        {
            await LoadItemsAsync();
        }

        private async Task LoadItemsAsync()
        {
            Rewards.Clear();

            var items = (await _repository.GetAllAsync()).First().Rewards;
            foreach (var item in items)
            {
                Rewards.Add(item);
            }
        }
    }
}
