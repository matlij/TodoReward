using TodoReward.Pages;

namespace TodoReward;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();

        Routing.RegisterRoute(nameof(PutItemPage), typeof(PutItemPage));
        Routing.RegisterRoute(nameof(UserPage), typeof(UserPage));

    }
}
