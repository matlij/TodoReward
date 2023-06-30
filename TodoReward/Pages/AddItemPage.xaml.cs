using TodoReward.ViewModels;

namespace TodoReward.Pages;

public partial class AddItemPage : ContentPage
{
	public AddItemPage(AddItemViewModel vm)
	{
		BindingContext = vm;

		InitializeComponent();
	}
}