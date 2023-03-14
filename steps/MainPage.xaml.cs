using Microsoft.Maui;
using steps.MVVM.Models;
using steps.MVVM.Views;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text.Json;
using System.Text;
using steps.API;
using Newtonsoft.Json;

namespace steps;

public partial class MainPage : ContentPage
{
    
    readonly ILoginRepository _loginRepository = new LoginService();

    public MainPage()
	{
		InitializeComponent();        
    }

    private async void Login_Clicked(object sender, EventArgs e)
    {

        await Navigation.PushAsync(new steps.MVVM.Views.Tab());

        #region Login using API Credentials Need to pass username and password in API

        //var userName = UserEntry.Text;
        //var Password = PasswordEntry.Text;

        //if (userName == null || Password == null)
        //{
        //    await DisplayAlert("Warning", "Please Input UserName & Password", "OK");
        //    return;
        //}
        //UserInfo userinfo = await _loginRepository.Login(userName, Password);
        //if (userinfo != null)
        //{
        //    await Navigation.PushAsync(new MVVM.Views.Tab());
        //}
        //else
        //{
        //    await DisplayAlert("Warning", "UserName Or Password is Incorrect", "OK");
        //}

        #endregion

    }
}