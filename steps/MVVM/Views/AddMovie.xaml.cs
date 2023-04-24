using steps.MVVM.Models;
using System.Windows.Input;
using PropertyChanged;
using System.Text.Json;
using steps.DTO;
using System.Text;


namespace steps.MVVM.Views;


public partial class AddMovie : ContentPage
{

    HttpClient _client;
    JsonSerializerOptions _serializerOptions;

    public static string baseUrl = DeviceInfo.Platform == DevicePlatform.Android ? "https://10.0.2.2:7216/api/movies" : "https://localhost:7216/api/movies";


    public AddMovie()
    {
        InitializeComponent();

#if DEBUG
        HttpsClientHandlerService handler = new HttpsClientHandlerService();
        _client = new HttpClient(handler.GetPlatformMessageHandler());
#else
            _client = new HttpClient();            
#endif
        _serializerOptions = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            WriteIndented = true
        };
    }

    private async void Add_Clicked(object sender, EventArgs e)
    {
        var url = $"{baseUrl}";

        var movie = new AddMovieDto
        {
            Name = AddNameEntry.Text,
            Description = AddDescriptionEntry.Text,
            Rating = AddRatingEntry.Text,
            ImageUrl = AddImageUrlEntry.Text,
            IsFavorite = IsFavoriteCheckBox.IsChecked
        };

        string json =
         JsonSerializer.Serialize<AddMovieDto>(movie, _serializerOptions);

        StringContent content =
            new StringContent(json, Encoding.UTF8, "application/json");

        var response = await _client.PostAsync(url, content);

        if (response.IsSuccessStatusCode)
        {
            await Navigation.PopAsync();
        }
        else
        {
            DisplayAlert("Warning", "Please Fill all the Fileds", "Ok");
        }
    }

    private async void Cancel_Clicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }
}