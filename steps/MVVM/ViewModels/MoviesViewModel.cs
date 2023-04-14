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
        public List<MoviesDto> movies { get; set; }
        public Movies AddMovie { get; set; }

        #region Consuming API

        HttpClient _client;
        JsonSerializerOptions _serializerOptions;


        string baseUrl = "https://localhost:7216/api";
        private List<MoviesDto> moviesAPI;  //  Change From moviesAPI to movies

        #region Get All Movies using Command Get Verb REST API

        //  Get All Movies using Command Get Verb Rest API
        //public ICommand GetAllMoviesCommand =>
        //    new Command(async () =>
        //    {
        //        var url = $"{baseUrl}/movies";
        //        var response = await _client.GetAsync(url);
        //        if (response.IsSuccessStatusCode)
        //        {
        //            using (var responseStream = await response.Content.ReadAsStreamAsync())
        //            {
        //                var data =
        //                await JsonSerializer
        //                .DeserializeAsync<List<MoviesDto>>(responseStream, _serializerOptions);
        //                moviesAPI = data;
        //                // movies = data;
        //            }
        //        }
        //    });
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
                    name = "Falcon and the Winter Solder",
                    description = "Boyz of Captain America the Firts Avengers",
                    rating = "1.1",
                    imageUrl = "thefalconandthewintersolder.png",
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
                var url = $"{baseUrl}/movies/10";
                var response = await _client.DeleteAsync(url);
            });
        #endregion






        

        public ICommand AddOrUpdateCommand { get; set; }

        public ICommand DeleteCommand { get; set; }

        public MoviesViewModel()
        {

            #region Consume API

            _client = new HttpClient();
            _serializerOptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true
            };

            #endregion


            Refresh();
            GenerateNewMovie();


            AddOrUpdateCommand = new Command(async () =>
            {
                var lenght = AddMovie.Name;
                if (lenght.Length > 0)
                {
                    App._movieRepository.AddOrUpdate(AddMovie);
                    Console.Write(App._movieRepository.StatusMsg);
                    GenerateNewMovie();
                    //Refresh();
                }
            });

            DeleteCommand = new Command(() =>
            {
                App._movieRepository.Delete(AddMovie.Id);
                Refresh();
            });


            Refresh();
        }

        public void GenerateNewMovie()
        {
            AddMovie = new Faker<Movies>()
                .RuleFor(x => x.Name, "")
                .RuleFor(x => x.Description, "")
                .RuleFor(x => x.Rating, "")
                .RuleFor(x => x.ImageUrl, "")
                .RuleFor(x => x.isFavorite, false)
                .Generate();
            Refresh();
        }

        public async void Refresh()
        {
            //movies = App._movieRepository.GetAll();

            var url = $"{baseUrl}/movies";
            var response = await _client.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                using (var responseStream = await response.Content.ReadAsStreamAsync())
                {
                    var data =
                    await JsonSerializer
                    .DeserializeAsync<List<MoviesDto>>(responseStream, _serializerOptions);
                    movies = data;
                }
            }

        }
    }
}