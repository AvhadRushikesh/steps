using Microsoft.Maui.Graphics.Converters;
using steps.MVVM.Models;
using steps.MVVM.ViewModels;

namespace steps.MVVM.Views;

public partial class AddNewMovies : ContentPage
{
    public BGColor Getcolor { get; set; }

    public AddNewMovies()
	{
		InitializeComponent();

        GetColorFromTable();

        BindingContext = new MoviesViewModel();

		//BindingContext = new BGColorViewModel();
    }

    private async void Back_Clicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }

    public void GetColorFromTable()
    {
        Getcolor = App._colorRepo.Get(1);
        var seecolor = Getcolor.BackColor;
        ColorTypeConverter converter = new ColorTypeConverter();
        Color color = (Color)(converter.ConvertFromInvariantString(seecolor));
        MainGridOfPage.BackgroundColor = color;
    }

}