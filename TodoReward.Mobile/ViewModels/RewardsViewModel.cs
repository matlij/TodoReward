using CommunityToolkit.Maui.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Timers;
using TodoReward.Core.Interfaces;
using TodoReward.Core.Models;
using TodoReward.Pages;
using Timer = System.Timers.Timer;

namespace TodoReward.ViewModels
{
    public partial class RewardViewModel : ObservableObject
    {
        private readonly IGenericRepository<UserReward> _userRewardRepository;
        private readonly Stack<UserReward> _usedRewards = new();

        [ObservableProperty]
        private ObservableCollection<UserReward> _rewards = new();

        [ObservableProperty]
        private UserReward _selectedReward = new();

        [ObservableProperty]
        private bool _canUndo;

        private readonly Timer _disableUndoButtonTimer;

        public RewardViewModel(IGenericRepository<UserReward> userRewardRepository)
        {
            _userRewardRepository = userRewardRepository;
            _disableUndoButtonTimer = new Timer(TimeSpan.FromSeconds(10));
            _disableUndoButtonTimer.Elapsed += OnDisableUndoEvent;
            _disableUndoButtonTimer.AutoReset = false;
            _disableUndoButtonTimer.Enabled = false;
        }

        public async Task Init()
        {
            var rewards = await _userRewardRepository.GetBySpecificationAsync(
                r => r.UserId == ModelConstants.UserId && r.IsDone == false);

            Rewards.Clear();
            foreach (var item in rewards)
            {
                Rewards.Add(item);
            }
        }

        [RelayCommand]
        private async Task UseReward()
        {
            var popup = new RewardPopup(SelectedReward);

            var result = await Shell.Current.ShowPopupAsync(popup);

            if (result is bool boolResult && boolResult)
            {
                await UseSelectedReward();
                SelectedReward = null;
            }
        }

        private async Task UseSelectedReward()
        {
            var result = await UpdateReward(SelectedReward, isDone: true);
            if (result)
            {
                RemoveFromList(Rewards, SelectedReward.Id);

                _usedRewards.Push(SelectedReward);
                CanUndo = _usedRewards.Count > 0;
                _disableUndoButtonTimer.Enabled = true;
            }
        }

        [RelayCommand]
        private async Task UndoUsedReward()
        {
            if (!_usedRewards.TryPeek(out var usedReward))
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Failed to undo used reward (stack is empty)", "OK");
                return;
            }

            var result = await UpdateReward(usedReward, isDone: false);
            if (result == false)
                return;

            Rewards.Add(usedReward);

            _usedRewards.Pop();
            CanUndo = _usedRewards.Count > 0;
        }

        private async Task<bool> UpdateReward(UserReward reward, bool isDone)
        {
            if (reward is null)
                return false;

            reward.IsDone = isDone;

            var result = await _userRewardRepository.UpdateAsync(reward.Id, reward);
            if (!result)
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Update reward failed", "OK");
                return false;
            }

            return true;
        }

        private bool RemoveFromList(IList<UserReward> rewards, Guid idToRemove)
        {
            var rewardToRemove = rewards.SingleOrDefault(r => r.Id == idToRemove);
            if (rewardToRemove is null)
            {
                Debug.WriteLine("Failed to remove Reward with ID " + idToRemove);
                return false;
            }
            return rewards.Remove(rewardToRemove);
        }

        private void OnDisableUndoEvent(object source, ElapsedEventArgs e)
        {
            Debug.WriteLine($"The hide undo button timer was raised at {e.SignalTime}");
            CanUndo = false;
        }
    }
}
