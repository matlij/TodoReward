using CommunityToolkit.Maui.Views;
using TodoReward.BusinessLayer.Models;

namespace TodoReward.Pages;

public partial class RewardPopup : Popup
{
	public RewardPopup(Reward reward)
	{
		InitializeComponent();
	}
}