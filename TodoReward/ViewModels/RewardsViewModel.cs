using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
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

        [ObservableProperty]
        private Reward _selectedReward = new();

        public RewardViewModel(IGenericRepository<User> repository)
        {
            _repository = repository;
        }

        public async Task Init()
        {
            var rewards = await GetUserRewards();
            PopulateRewardsCollection(rewards);
        }

        [RelayCommand]
        private async Task UseReward()
        {
            var user = await GetUser();

            user.Rewards.Remove(SelectedReward);
            Rewards.Remove(SelectedReward);
            SelectedReward = null;
        }

        private async Task<IEnumerable<Reward>> GetUserRewards()
        {
            var user = await GetUser();

            return user.Rewards;
        }

        private async Task<User> GetUser()
        {
            var users = await _repository.GetAllAsync();
            return users.First();
        }

        private void PopulateRewardsCollection(IEnumerable<Reward> rewards)
        {
            Rewards.Clear();

            foreach (var item in rewards)
            {
                Rewards.Add(item);
            }
        }
    }
}
