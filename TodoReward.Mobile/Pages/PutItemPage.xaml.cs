using System.Diagnostics;
using TodoReward.ViewModels;

namespace TodoReward.Pages;

public partial class PutItemPage : ContentPage
{
	public PutItemPage(PutItemViewModel vm)
	{
		BindingContext = vm;

		InitializeComponent();

        Appearing += (sender, e) =>
        {
            Task.Run(() =>
            {
                try
                {
                    while (!TodoTitleEntry.IsLoaded)
                    {
                        Debug.WriteLine("TodoTitleEntry.IsLoaded " + TodoTitleEntry.IsLoaded);
                        Thread.Sleep(50);
                    }

                    TodoTitleEntry.Focus();
                }
                catch (Exception e)
                {
                    Debug.WriteLine("Failed to set focus on entry field: " + e.Message);
                }
            });
        };
    }
}