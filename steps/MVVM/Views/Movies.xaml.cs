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
    public List<Models.Movies> moviess { get; set; }

    public Movies()
    {
        InitializeComponent();

        BindingContext = new MoviesViewModel();

        GetColorFromTable();

        GetAllMovieList();        
    }

    private async void SetBackground(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Home());
    }

    private void AddMovie_Clicked(object sender, EventArgs e)
    {
        // await Navigation.PushAsync(new AddNewMovies());

        SearchAndAddGrid.IsVisible = false;
        Id.IsVisible = false;
        AddOrUpdate.Text = "Add";
        CollectionViewGrid.IsVisible = false;
        UpdateGrid.IsVisible = true;
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

    private void Update_Clicked(object sender, EventArgs e)
    {
        SearchAndAddGrid.IsVisible = false;
        AddOrUpdate.Text = "Update";
        Id.IsVisible = true;
        Id.IsReadOnly = true;
        CollectionViewGrid.IsVisible = false;
        UpdateGrid.IsVisible = true;
    }

    private void CancelUpdate_Clicked(object sender, EventArgs e)
    {
        UpdateGrid.IsVisible = false;
        CollectionViewGrid.IsVisible = true;
        SearchAndAddGrid.IsVisible = true;
    }
    
    private void SearhBarforMovie_TextChanged(object sender, TextChangedEventArgs e)
    {
        var SearchMovie = moviess.Where(x =>
           x.Name.Contains(SearhBarforMovie.Text) ||
           x.Description.Contains(SearhBarforMovie.Text)).ToList();

        MoviesCollectionView.ItemsSource = SearchMovie;
    }

    public void GetAllMovieList()
    {
        moviess = App._movieRepository.GetAll();
    }

}