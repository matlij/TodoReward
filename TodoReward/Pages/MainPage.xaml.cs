using TodoReward.ViewModels;

namespace TodoReward.Pages;

public partial class MainPage : ContentPage
{
    private readonly MainViewModel _vm;

    public MainPage(MainViewModel vm)
	{
        BindingContext = _vm = vm;
        InitializeComponent();
    }

    protected override async void OnAppearing()
    {
        await _vm.Init();
    }
}

