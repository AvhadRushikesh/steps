
using steps.MVVM.Views;
using steps.NewFolder.Views;
using steps.Repositories;

namespace steps;

public partial class App : Application
{
	public static MovieRepository _movieRepository { get; private set; }
	public App(MovieRepository movieRepo)
	{
		InitializeComponent();

		_movieRepository = movieRepo;

		//MainPage = new NavigationPage(new MainPage());

		MainPage = new Movies();
    }
}