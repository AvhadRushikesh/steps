using steps.API;
using steps.API.Dto;
using steps.API.VM;
using steps.API.Service;

namespace steps;

public partial class MainPage : ContentPage
{

    readonly ILoginRepository _loginRepository = new LoginService();

    private readonly IAuthService _authService; // This need to be called inside constructor

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

        #region Test using Magicvilla Login
        //try
        //{
        //    LoginRequestDto credential = new()
        //    {
        //        UserName = UserEntry.Text,
        //        Password = PasswordEntry.Text
        //    };


        //    var test1 = credential.UserName;
        //    var test2 = credential.Password;


        //    APIResponse response = await _authService.LoginAsync<APIResponse>(credential);

        //    if (response != null && response.IsSuccess)
        //    {
        //        #region From Magic Villa API Consumption Check Token

        //        //LoginResponseDto model = JsonConvert.DeserializeObject<LoginResponseDto>(Convert.ToString(response.Result));

        //        //var handler = new JwtSecurityTokenHandler();
        //        //var jwt = handler.ReadJwtToken(model.Token);

        //        //var identity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme);
        //        //identity.AddClaim(new Claim(ClaimTypes.Name, jwt.Claims.FirstOrDefault(u => u.Type == "role").Value));
        //        //identity.AddClaim(new Claim(ClaimTypes.Role, jwt.Claims.FirstOrDefault(u => u.Type == "role").Value));
        //        //var principal = new ClaimsPrincipal(identity);
        //        //// await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

        //        //HttpContext.Session.SetString(Class1.SessionToken, model.Token);

        //        #endregion

        //        await Navigation.PushAsync(new steps.MVVM.Views.Tab());
        //    }
        //    else
        //    {
        //        await DisplayAlert("Warning", "Access Denied", "OK");
        //    }
        //}
        //catch (Exception ex)
        //{
        //    await DisplayAlert("Warning", ex.Message, "Ok");
        //}
        #endregion

        #region Testing Using Dummy API
        //// var url = "https://localhost:7025/api/UsersAuth/login/admin/Password1";
        //var url = "https://www.boredapi.com/api/activity";
        //using var client = new HttpClient();
        //client.BaseAddress = new Uri(url);

        //client.DefaultRequestHeaders.Accept.Add(
        //   new MediaTypeWithQualityHeaderValue("application/json"));

        //HttpResponseMessage response = await client.GetAsync(url);//.Result;
        //if (response.IsSuccessStatusCode)
        //{
        //    await Navigation.PushAsync(new steps.MVVM.Views.Tab());
        //}
        //else
        //{
        //    await DisplayAlert("Warning", "Access Denied", "OK");
        //}
        #endregion

    }
}