using SQLite;
using steps.MVVM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace steps.Repositories
{
    public class MovieRepository
    {
        SQLiteConnection Conn;
        public string StatusMsg { get; set; }

        public MovieRepository()
        {
            //  Connection to Database
            Conn = new SQLiteConnection(Constant.DatabasePath, Constant.Flags);

            //  Create Table Movies
            Conn.CreateTable<Movies>();
        }

        //  Add or Update Movie to Database
        public void AddOrUpdate(Movies movie)
        {
            int result = 0;
            try
            {
                if (movie.Id != 0)
                {
                    result = Conn.Update(movie);
                    StatusMsg = $"{result} Movie(s) Updated";
                }
                else
                {
                    result = Conn.Insert(movie);
                    StatusMsg = $"{result} Movie(s) added";
                }
            }
            catch (Exception ex)
            {
                StatusMsg = $"Error: {ex.Message}";
            }
        }

        //  Select Movie
        public List<Movies> GetAll()
        {
            try
            {
                return Conn.Table<Movies>().ToList();
            }
            catch (Exception ex)
            {
                StatusMsg = $"Error: {ex.Message}";
            }
            return null;
        }

        //  Get Single Movie Record
        public Movies Get(int id)
        {
            try
            {
                return Conn.Table<Movies>()
                    .FirstOrDefault(x => x.Id == id);
            }
            catch (Exception ex)
            {
                StatusMsg = $"Error: {ex.Message}";
            }
            return null;
        }

        //  Delete Movie Record from Database
        public void Delete(int MovieId)
        {
            try
            {
                var movie = Get(MovieId);
                Conn.Delete(movie);
            }
            catch (Exception ex)
            {
                StatusMsg = $"Error: {ex.Message}";
            }
        }

    }
}