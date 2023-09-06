using TodoReward.ViewModels;

namespace TodoReward.Pages;

public partial class UserPage : ContentPage
{
    private readonly UserViewModel _vm;

    public UserPage(UserViewModel vm)
	{
		InitializeComponent();

        BindingContext = _vm = vm;
	}

    protected override async void OnAppearing()
    {
        await _vm.Init();
    }
}