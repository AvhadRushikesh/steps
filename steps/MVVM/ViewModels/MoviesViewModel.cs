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
        public MoviesDto AddMovie { get; set; }

        public static string baseUrl = DeviceInfo.Platform == DevicePlatform.Android ? "https://10.0.2.2:7216/api" : "https://localhost:7216/api";
        private int idEntry;
        private string nameEntry;
        private string descriptionEntry;
        private string ratingEntry;
        private string imageUrlEntry;




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

        #region Get Single Movie Record
        //  Get Single Record
        //public ICommand GetSinglemovieCommand =>
        //    new Command(async () =>
        //    {
        //        var url = $"{baseUrl}/movies/2";
        //        var response = await _client.GetAsync(url);
        //    });
        #endregion


        #region Get Fields Values for passing parameter

        public int IdEntry
        {
            get => idEntry;
            set
            {
                idEntry = value;
            }
        }

        public string NameEntry
        {
            get => nameEntry;
            set
            {
                nameEntry = value;
            }
        }

        public string DescriptionEntry
        {
            get => descriptionEntry;
            set
            {
                descriptionEntry = value;
            }
        }

        public string RatingEntry
        {
            get => ratingEntry;
            set
            {
                ratingEntry = value;
            }
        }

        public string ImageUrlEntry
        {
            get => imageUrlEntry;
            set
            {
                imageUrlEntry = value;
            }
        }

        #endregion

        #region Add New Movie

        //  Add Record
        //public ICommand AddMovieCommand =>
        //    new Command(async () =>
        //    {
        //        MoviesDto movieId = new MoviesDto();

        //        var url = $"{baseUrl}/movies";

        //        var movie = new MoviesDto
        //        {
        //            name = nameEntry,
        //            description = descriptionEntry,
        //            rating = ratingEntry,
        //            imageUrl = imageUrlEntry,
        //            isFavorite = true
        //        };

        //        string json =
        //         JsonSerializer.Serialize<MoviesDto>(movie, _serializerOptions);

        //        StringContent content =
        //            new StringContent(json, Encoding.UTF8, "application/json");

        //        var response = await _client.PostAsync(url, content);
        //        //}
        //    });
        #endregion

        // Update the Records
        public ICommand UpdateMovieCommand =>
            new Command(async () =>
            {
                var url = $"{baseUrl}/movies/{AddMovie.id}";
                var movie = new MoviesDto
                {
                    id = AddMovie.id,
                    name = AddMovie.name,
                    description = AddMovie.description,
                    rating = AddMovie.rating,
                    imageUrl = AddMovie.imageUrl,
                    isFavorite = AddMovie.isFavorite
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
                var responseStream = await response.Content.ReadAsStreamAsync();
                var data = await JsonSerializer.DeserializeAsync<List<MoviesDto>>(responseStream, _serializerOptions);
                movies = data;
                //using (var responseStream = await response.Content.ReadAsStreamAsync())
                //{
                //    var data = await JsonSerializer.DeserializeAsync<List<MoviesDto>>(responseStream, _serializerOptions);
                //    movies = data;
                //}
            }
        }
    }
}