using TodoReward.ViewModels;

namespace TodoReward.Pages;

public partial class RewardPage : ContentPage
{
    private readonly RewardViewModel _vm;

    public RewardPage(RewardViewModel vm)
	{
        BindingContext = _vm = vm;

        InitializeComponent();
	}

    protected override async void OnAppearing()
    {
        base.OnAppearing();

        await _vm.Init();
    }
}