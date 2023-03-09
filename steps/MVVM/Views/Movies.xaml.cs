using Microsoft.Maui.Graphics.Converters;
using PropertyChanged;
using steps.MVVM.Models;
using steps.MVVM.ViewModels;
namespace steps.MVVM.Views;


public partial class Movies : ContentPage
{
    public BGColor Getcolor { get; set; }

    public Movies()
	{
		InitializeComponent();

        GetColorFromTable();

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

    public void GetColorFromTable()
    {
        Getcolor = App._colorRepo.Get(1);
        var seecolor = Getcolor.BackColor;
        ColorTypeConverter converter = new ColorTypeConverter();
        Color color = (Color)(converter.ConvertFromInvariantString(seecolor));
        MainGridofPage.BackgroundColor = color;
        CollectionViewGrid.BackgroundColor = color;
    }
}