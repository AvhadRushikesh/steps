using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace steps
{
    public class Constant
    {
        private const string DBFileName = "SQLite.db3";

        private const string ColorFileName = "color.db3";


        public const SQLiteOpenFlags Flags =
            SQLiteOpenFlags.ReadWrite |
            SQLiteOpenFlags.Create |
            SQLiteOpenFlags.SharedCache;


        public static string DatabasePath
        {
            get
            {
                return Path.Combine(FileSystem.AppDataDirectory, DBFileName);
            }
        }

        public static string DatabasePathforcolor
        {
            get
            {
                return Path.Combine(FileSystem.AppDataDirectory, ColorFileName);
            }
        }
    }
}