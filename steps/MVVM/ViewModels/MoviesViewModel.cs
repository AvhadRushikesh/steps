using Bogus;
using steps.MVVM.Models;
using System.Windows.Input;
using PropertyChanged;
using System.Text.Json;
using steps.DTO;
using System.Text;
using System.Diagnostics;

namespace steps.MVVM.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class MoviesViewModel
    {
        //public List<Movies> movies { get; set; }
        //public List<MoviesDto> movies { get; set; }
        public Movies AddMovie { get; set; }

        #region Consuming API

        HttpClient _client;
        JsonSerializerOptions _serializerOptions;

        
        public static string baseUrl = DeviceInfo.Platform == DevicePlatform.Android ? "https://10.0.2.2:7216/api" : "https://localhost:7216/api";

        private List<MoviesDto> movies;  //  Change From moviesAPI to movies



        #region Get All Movies using Command Get Verb REST API

        //  Get All Movies using Command Get Verb Rest API
        public ICommand GetAllMoviesCommand =>
            new Command(async () =>
            {
                var url = $"{baseUrl}/movies";
                var response = await _client.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    using (var responseStream = await response.Content.ReadAsStreamAsync())
                    {
                        var data =
                        await JsonSerializer
                        .DeserializeAsync<List<MoviesDto>>(responseStream, _serializerOptions);
                        //moviesAPI = data;
                        movies = data;
                    }
                }
            });
        #endregion



        //  Get Single Record

        public ICommand GetSinglemovieCommand =>
            new Command(async () =>
            {
                var url = $"{baseUrl}/movies/2";
                var response = await _client.GetAsync(url);
            });

        //  Add Record
        public ICommand AddMovieCommand =>
            new Command(async () =>
            {
                var url = $"{baseUrl}/movies";
                var movie = new MoviesDto
                {
                    name = "Wanda Vision",
                    description = "The witch take over city",
                    rating = "2.3",
                    imageUrl = "wandavision.png",
                    isFavorite = false
                };
                string json =
                     JsonSerializer.Serialize<MoviesDto>(movie, _serializerOptions);

                StringContent content =
                    new StringContent(json, Encoding.UTF8, "application/json");

                var response = await _client.PostAsync(url, content);
            });

        // Update the Records
        public ICommand UpdateMovieCommand =>
            new Command(async () =>
            {
                var url = $"{baseUrl}/movies/24";
                //var movie = moviesAPI.FirstOrDefault(x => x.id == 24);
                var movie = new MoviesDto
                {
                    id = 24,
                    name = "Captain America",
                    description = "Captain America The Firts Avengers",
                    rating = "2.1",
                    imageUrl = "TestUrl.Png",
                    isFavorite = false
                };

                string json =
                     JsonSerializer.Serialize<MoviesDto>(movie, _serializerOptions);

                StringContent content =
                    new StringContent(json, Encoding.UTF8, "application/json");

                var response = await _client.PutAsync(url, content);
            });

        // Delete Record
        public ICommand DeleteMovieCommand =>
            new Command(async () =>
            {
                var id = AddMovie.Id;
                var url = $"{baseUrl}/movies/{id}";
                var response = await _client.DeleteAsync(url);
            });
        #endregion






        public MoviesViewModel()
        {
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

            Refresh();            
        }

        
        public async void Refresh()
        {
            var url = $"{baseUrl}/movies";
            var response = await _client.GetAsync(url);

            if (response.StatusCode != System.Net.HttpStatusCode.OK)
            {
                using (var responseStream = await response.Content.ReadAsStreamAsync())
                {
                    var data = await JsonSerializer.DeserializeAsync<List<MoviesDto>>(responseStream, _serializerOptions);
                    movies = data;
                }
            }
        }
    }
}