using PropertyChanged;
using steps.MVVM.ViewModels;
using steps.NewFolder.Views;

namespace steps.MVVM.Views;


public partial class Movies : ContentPage
{
	public Movies()
	{
		InitializeComponent();

        BindingContext = new MoviesViewModel();
    }

    private void SetBackground(object sender, EventArgs e)
    {
        // await Navigation.PushAsync(new Home());
    }
}