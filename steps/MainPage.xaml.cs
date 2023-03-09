using Android.Media.TV;
using Microsoft.Maui;
using Org.Apache.Http.Protocol;
using steps.MVVM.Models;
using steps.MVVM.Views;
using System.Net.Http.Headers;
using System.Security.Claims;
using static Android.Content.ClipData;
using System.Text.Json;
using System.Text;
using steps.API;

namespace steps;

public partial class MainPage : ContentPage
{
    
    readonly ILoginRepository _loginRepository = new LoginService();

    public MainPage()
	{
		InitializeComponent();

        #region API Work

        #endregion
    }

    private async void Login_Clicked(object sender, EventArgs e)
    {
        #region Login using API Credentials

        var userName = UserEntry.Text;
        var Password = PasswordEntry.Text;

        if (userName == null || Password == null)
        {
            await DisplayAlert("Warning", "Please Input UserName & Password", "OK");
            return;
        }
        UserInfo userinfo = await _loginRepository.Login(userName, Password);
        if (userinfo != null)
        {
            await Navigation.PushAsync(new steps.MVVM.Views.Tab());
        }
        else 
        {
            await DisplayAlert("Warning", "UserName & Password is Incorrect", "OK");
        }

        #endregion
    }
}