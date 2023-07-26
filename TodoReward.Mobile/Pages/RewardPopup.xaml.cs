using CommunityToolkit.Maui.Views;
using TodoReward.Core.Models;

namespace TodoReward.Pages;

public partial class RewardPopup : Popup
{
	public RewardPopup(UserReward reward)
	{
		InitializeComponent();

		BindingContext = reward;

    }

    void OnYesButtonClicked(object? sender, EventArgs e) => Close(true);

    void OnNoButtonClicked(object? sender, EventArgs e) => Close(false);
}