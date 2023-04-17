using steps.MVVM.Models;
using System.Windows.Input;
using PropertyChanged;
using System.Text.Json;
using steps.DTO;
using System.Text;

namespace steps.MVVM.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class MoviesViewModel
    {
        HttpClient _client;

        JsonSerializerOptions _serializerOptions;

        public List<MoviesDto> movies { get; set; }
        public MoviesDto AddMovie;// { get; set; }

        public static string baseUrl = DeviceInfo.Platform == DevicePlatform.Android ? "https://10.0.2.2:7216/api" : "https://localhost:7216/api";
        private int iD;
        private string name;
        private string description;
        private string rating;
        private string imageUrl;



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
                        var data = await JsonSerializer.DeserializeAsync<List<MoviesDto>>(responseStream, _serializerOptions);
                        movies = data;
                    }
                }
            });

        //  Get Single Record
        public ICommand GetSinglemovieCommand =>
            new Command(async () =>
            {
                var url = $"{baseUrl}/movies/2";
                var response = await _client.GetAsync(url);
            });

        #region Get Fields Values for passing parameter

        public int Id
        {
            get => iD;
            set
            {
                iD = value;
            }
        }

        public string Name
        {
            get => name;
            set
            {
                name = value;
            }
        }

        public string Description
        {
            get => description;
            set
            {
                description = value;
            }
        }

        public string Rating
        {
            get => rating;
            set
            {
                rating = value;
            }
        }

        public string ImageUrl
        {
            get => imageUrl;
            set
            {
                imageUrl = value;
            }
        }

        #endregion


        //  Add Record
        public ICommand AddMovieCommand =>
            new Command(async () =>
            {
                MoviesDto movieId = new MoviesDto();

                if (movieId.id > 0)
                {
                    var url = $"{baseUrl}/movies/24";
                    //var movie = moviesAPI.FirstOrDefault(x => x.id == 24);
                    var movie = new MoviesDto
                    {
                        id = movieId.id,
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
                }
                else
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

                }



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
                var id = AddMovie.id;
                var url = $"{baseUrl}/movies/{id}";
                var response = await _client.DeleteAsync(url);
            });

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
            if (response.IsSuccessStatusCode)
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