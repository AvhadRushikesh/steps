using steps.MVVM.ViewModels;

namespace steps.MVVM.Views;

public partial class AddNewMovies : ContentPage
{
	public AddNewMovies()
	{
		InitializeComponent();

        BindingContext = new MoviesViewModel();

		//BindingContext = new BGColorViewModel();
    }

    private async void Back_Clicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }
}