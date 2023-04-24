using steps.MVVM.Views;
using steps.Repositories;

namespace steps;

public partial class App : Application
{

    #region Used For Database with Repository

    //public static MovieRepository _movieRepository { get; private set; }    //	For Movie to add or update or Delete
    //public static BGColorRepo _colorRepo { get; private set; }              //	For Background Color
    //   public App(MovieRepository movieRepo, BGColorRepo colorrepo)
    //{
    //	InitializeComponent();
    //	_movieRepository = movieRepo;
    //	_colorRepo = colorrepo;
    //	MainPage = new NavigationPage(new MainPage());
    //}
    #endregion

    public App()
    {
        InitializeComponent();

        MainPage = new NavigationPage(new MainPage());
    }
}