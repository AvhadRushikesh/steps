using Bogus;
using steps.MVVM.Models;
using System.Windows.Input;
using PropertyChanged;
using System.Text.Json;
using steps.DTO;
using System.Text;
using Android.Graphics;

namespace steps.MVVM.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class MoviesViewModel
    {
        #region Consuming API

        HttpClient client;
        JsonSerializerOptions _serializeOptions;
        //string baseUrl = "https://localhost:7216/api";
        string baseUrl = "https://64008f0d29deaba5cb3a5609.mockapi.io";
        private List<MoviesDto> moviesAPI;  //  Change From moviesAPI to movies

        public ICommand GetAllMoviesCommand =>
            new Command(async () =>
            {
                var url = $"{baseUrl}/users";
                var response = await client.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    using (var responseStream = await response.Content.ReadAsStreamAsync())
                    {
                        var data = 
                        await JsonSerializer
                        .DeserializeAsync<List<MoviesDto>>(responseStream, _serializeOptions);
                        moviesAPI = data;
                    }
                }
            });


        //  Get Single Record
        public ICommand GetSinglemovieCommand =>
            new Command(async () =>
            {
                var url = $"{baseUrl}/movies/1";
            });

        //  Add Record
        public ICommand AddMovieCommand =>
            new Command(async () =>
            {
                var url = $"{baseUrl}/movies";
                var movie = new MoviesDto
                {
                    id = 1,
                    name = "",
                    description = "",
                    rating = "",
                    imageUrl = "",
                    isFavorite = true
                };
                string json =
                     JsonSerializer.Serialize<MoviesDto>(movie, _serializeOptions);

                StringContent content =
                    new StringContent(json, Encoding.UTF8, "application/json");

                var response = await client.PostAsync(url, content);
            });



        // Update the Records
        public ICommand UpdateMovieCommand =>
            new Command(async () =>
            {
                var moviess = movies.FirstOrDefault(x => x.Id == 1);
                var url = $"{baseUrl}/movies/1";

                moviess.Name = "Hulk";

                string json =
                     JsonSerializer.Serialize<Movies>(moviess, _serializeOptions);

                StringContent content =
                    new StringContent(json, Encoding.UTF8, "application/json");

                var response = await client.PutAsync(url, content);
            });

        // Delete Record
        public ICommand DeleteUserCommand =>
            new Command(async () =>
            {
                var url = $"{baseUrl}/movies/10";
                var response = await client.DeleteAsync(url);
            });
        #endregion






        public List<Movies> movies { get; set; }

        public Movies AddMovie { get; set; }

        public ICommand AddOrUpdateCommand { get; set; }

        public ICommand DeleteCommand { get; set; }

        public MoviesViewModel()
        {
            Refresh();
            GenerateNewMovie();

            #region Consume API

            client = new HttpClient();
            _serializeOptions = new JsonSerializerOptions
            {
                WriteIndented = true,
            };

            #endregion

            AddOrUpdateCommand = new Command(async () =>
            {
                var lenght = AddMovie.Name;
                if (lenght.Length > 0)
                {
                    App._movieRepository.AddOrUpdate(AddMovie);
                    Console.Write(App._movieRepository.StatusMsg);
                    GenerateNewMovie();
                    Refresh();
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

        public void Refresh()
        {
            movies = App._movieRepository.GetAll();
        }
    }
}