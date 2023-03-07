using PropertyChanged;
using steps.MVVM.ViewModels;
namespace steps.MVVM.Views;


public partial class Movies : ContentPage
{
	public Movies()
	{
		InitializeComponent();

        BindingContext = new MoviesViewModel();
    }

    private async void SetBackground(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Home());
    }

    private async void AddMovie_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new AddNewMovies());
    }
}