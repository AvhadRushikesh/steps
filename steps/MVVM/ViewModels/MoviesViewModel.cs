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

namespace steps.MVVM.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class MoviesViewModel
    {
        public List<Movies> movies { get; set; }

        public Movies AddMovie { get; set; }

        public ICommand AddOrUpdateCommand { get; set; }

        public MoviesViewModel()
        {
            Refresh();
            GenerateNewMovie();

            AddOrUpdateCommand = new Command(async () =>
            {
                App._movieRepository.AddOrUpdate(AddMovie);
                Console.Write(App._movieRepository.StatusMsg);
                GenerateNewMovie();
                Refresh();
            });
        }

        public void GenerateNewMovie()
        {
            #region Pass Parameter and insert

            //AddMovie = new Movies
            //{
            //    Id = 0,
            //    Name = "Test Name",
            //    Description = "Test Description",
            //    Rating = "Test Rating",
            //    ImageUrl = "Test url"
            //};
            #endregion

            AddMovie = new Faker<Movies>()
                .RuleFor(x => x.Name, f => f.Person.FullName)
                .RuleFor(x => x.Description, f => f.Person.Address.Street)
                .RuleFor(x => x.Rating, f => f.Person.FullName)
                .RuleFor(x => x.ImageUrl, f => f.Person.FullName)
                .Generate();
            App._movieRepository.AddOrUpdate(AddMovie);
        }

        private void Refresh()
        {
            movies = App._movieRepository.GetAll();
        }

        public void UpdateBackGroundColor(int id, string hexvaluecolor)
        {

        }
    }
}