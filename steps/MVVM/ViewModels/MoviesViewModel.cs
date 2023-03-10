using Bogus;
using steps.MVVM.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using PropertyChanged;
using System.Globalization;
using System.Xml;
using CommunityToolkit.Maui.Converters;

namespace steps.MVVM.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class MoviesViewModel
    {
        public List<Movies> movies { get; set; }

        public Movies AddMovie { get; set; }

        public ICommand AddOrUpdateCommand { get; set; }

        public ICommand DeleteCommand { get; set; }


        #region Get Search Result from search bar

        //private string _TextSearch;

        //public string SearchBarText
        //{
        //    get => _TextSearch;
        //    set
        //    {
        //        _TextSearch = value;
        //        if (_TextSearch.Length > 0)
        //        {
        //            OnSearchCommand();
        //        }
        //        else
        //        {
        //            Refresh();
        //        }
        //    }
        //}

        //private void OnSearchCommand()
        //{
        //    var SearchMovie = movies.Where(x =>
        //    x.Name.Contains(SearchBarText) ||
        //    x.Description.Contains(SearchBarText)).ToList();

        //    if (SearchMovie.Count > 0)
        //    {
        //        movies.Clear();
        //        foreach (var movie in SearchMovie)
        //        {
        //            movies.Add(movie);
        //        }
        //    }
        //}

        #endregion


        public MoviesViewModel()
        {
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
                    Refresh();
                }
            });

            DeleteCommand = new Command(() =>
            {
                App._movieRepository.Delete(AddMovie.Id);
                Refresh();
            });
            // Refresh();
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