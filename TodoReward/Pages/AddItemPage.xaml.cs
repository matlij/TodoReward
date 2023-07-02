using System.Diagnostics;
using TodoReward.ViewModels;

namespace TodoReward.Pages;

public partial class AddItemPage : ContentPage
{
	public AddItemPage(AddItemViewModel vm)
	{
		BindingContext = vm;

		InitializeComponent();

        this.Appearing += (sender, e) =>
        {
            Task.Run(() =>
            {
                while (!TodoTitleEntry.IsLoaded)
                {
                    Debug.WriteLine("TodoTitleEntry.IsLoaded " + TodoTitleEntry.IsLoaded);
                    Thread.Sleep(50);
                }

                TodoTitleEntry.Focus();
            });
        };
    }
}