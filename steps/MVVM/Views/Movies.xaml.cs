using Microsoft.Maui.Graphics.Converters;
using PropertyChanged;
using steps.MVVM.Models;
using steps.MVVM.ViewModels;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace steps.MVVM.Views;


public partial class Movies : ContentPage
{
    public BGColor Getcolor { get; set; }
    public List<Models.AllMovies> moviess { get; set; }

    public Movies()
    {
        InitializeComponent();

        BindingContext = new MoviesViewModel();
    }

    private async void SetBackground(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new ChangeBackground());
    }

    private async void AddMovie_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new steps.MVVM.Views.AddMovie());
    }


    private void Update_Clicked(object sender, EventArgs e)
    {
        SearchAndAddGrid.IsVisible = false;
        CollectionViewGrid.IsVisible = false;
        UpdateGrid.IsVisible = true;
    }

    private void CancelUpdate_Clicked(object sender, EventArgs e)
    {
        UpdateGrid.IsVisible = false;
        SearchAndAddGrid.IsVisible = true;
        CollectionViewGrid.IsVisible = true;
    }

    #region Search Bar for movie
    private void SearhBarforMovie_TextChanged(object sender, TextChangedEventArgs e)
    {
        var SearchMovie = moviess.Where(x =>
           x.Name.Contains(SearhBarforMovie.Text) ||
           x.Description.Contains(SearhBarforMovie.Text)).ToList();

        MoviesCollectionView.ItemsSource = SearchMovie;
    }
    #endregion


    private async void ImageButton_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new ChangeBackground());
    }
}