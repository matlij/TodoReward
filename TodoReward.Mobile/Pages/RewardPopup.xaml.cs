using CommunityToolkit.Maui.Views;
using TodoReward.Core.Models;

namespace TodoReward.Pages;

public partial class RewardPopup : Popup
{
	public RewardPopup(Reward reward)
	{
		InitializeComponent();
	}
}