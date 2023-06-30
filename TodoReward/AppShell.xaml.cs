using TodoReward.Pages;

namespace TodoReward;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();

        Routing.RegisterRoute(nameof(AddItemPage), typeof(AddItemPage));
    }
}
