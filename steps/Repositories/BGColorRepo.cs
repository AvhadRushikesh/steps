using SQLite;
using steps.MVVM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace steps.Repositories
{
    public class BGColorRepo
    {
        SQLiteConnection Conn;

        public string StatusMsg { get; set; }

        public BGColorRepo()
        {
            //  Connection to Database
            Conn = new SQLiteConnection(Constant.DatabasePathforcolor, Constant.Flags);

            //  Create Table Movies
            Conn.CreateTable<BGColor>();
        }

        #region Check Method with different Parameter for testing
        //  Add or Update Movie to Database
        //public void AddOrUpdateColor(BGColor color)
        //{
        //    int result = 0;
        //    color.Id = 1;
        //    try
        //    {
        //        if (color.Id != 0)
        //        {
        //            result = Conn.Update(color);
        //        }
        //        else
        //        {
        //            result = Conn.Insert(color);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        StatusMsg = $"Error: {ex.Message}";
        //    }
        //}


        public void AddOrUpdateColor(BGColor color)
        {
            var col = color.BackColor.ToString();
            var no = color.Id;

            int result = 0;
            try
            {
                if (color.Id != 0)
                {
                    result = Conn.Update(color);
                    //result = Conn.Insert(color);
                }
                else
                {
                    result = Conn.Insert(color);
                }
            }
            catch (Exception ex)
            {
                StatusMsg = $"Error: {ex.Message}";
            }
        }
        #endregion


        public BGColor Get(int id)
        {
            //try
            //{
                return
                    Conn.Table<BGColor>()
                    .FirstOrDefault(x => x.Id == id);
            //}
            //catch (Exception ex)
            //{
            //    StatusMsg = $"Error: {ex.Message}";
            //}
            //return null;
        }
    }
}