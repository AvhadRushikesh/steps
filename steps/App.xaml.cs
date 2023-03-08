
using steps.MVVM.Views;
using steps.Repositories;

namespace steps;

public partial class App : Application
{
	//	For Movie to add or update or Delete
	public static MovieRepository _movieRepository { get; private set; }

	// For Background Color
	public static BGColorRepo _colorRepo { get; private set; }
	public App(MovieRepository movieRepo, BGColorRepo colorrepo)
	{
		InitializeComponent();

		_movieRepository = movieRepo;

		_colorRepo = colorrepo;

		//MainPage = new NavigationPage(new MainPage());

		MainPage = new steps.MVVM.Views.Tab();
		//MainPage = new Movies();
	}
}