using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Timers;
using TodoReward.BusinessLayer.Interfaces;
using TodoReward.BusinessLayer.Models;
using Timer = System.Timers.Timer;

namespace TodoReward.ViewModels
{
    public partial class RewardViewModel : ObservableObject
    {
        private readonly IGenericRepository<User> _repository;
        private readonly Stack<Reward> _usedRewards = new();

        [ObservableProperty]
        private ObservableCollection<Reward> _rewards = new();

        [ObservableProperty]
        private Reward _selectedReward = new();

        [ObservableProperty]
        private bool _canUndo;

        private readonly Timer _disableUndoButtonTimer;

        public RewardViewModel(IGenericRepository<User> repository)
        {
            _repository = repository;
            _disableUndoButtonTimer = new Timer(TimeSpan.FromSeconds(3));
            _disableUndoButtonTimer.Elapsed += OnDisableUndoEvent;
            _disableUndoButtonTimer.AutoReset = false;
            _disableUndoButtonTimer.Enabled = false;
        }

        public async Task Init()
        {
            var rewards = await GetUserRewards();
            PopulateRewardsCollection(rewards);
        }

        [RelayCommand]
        private async Task UseReward()
        {
            if (SelectedReward is null)
                return;

            var user = await GetUser();
            RemoveFromList(user.Rewards, SelectedReward.Id);
            RemoveFromList(Rewards, SelectedReward.Id);

            _usedRewards.Push(SelectedReward);

            SelectedReward = null;
            CanUndo = true;
            _disableUndoButtonTimer.Enabled = true;
        }

        [RelayCommand]
        private async Task UndoUsedReward()
        {
            var user = await GetUser();

            foreach (var reward in _usedRewards)
            {
                user.Rewards.Add(reward);
                Rewards.Add(reward);
            }

            _usedRewards.Clear();
            CanUndo = false;
        }

        private bool RemoveFromList(IList<Reward> rewards, Guid idToRemove)
        {
            var rewardToRemove = rewards.SingleOrDefault(r => r.Id == idToRemove);
            if (rewardToRemove is null)
            {
                Debug.WriteLine("Failed to remove Reward with ID " +  idToRemove);
                return false;
            }
            return rewards.Remove(rewardToRemove);
        }

        private void OnDisableUndoEvent(object source, ElapsedEventArgs e)
        {
            Debug.WriteLine($"The hide undo button timer was raised at {e.SignalTime}");
            CanUndo = false;
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
