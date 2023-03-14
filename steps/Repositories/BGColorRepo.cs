using SQLite;
using steps.MVVM.Models;

namespace steps.Repositories
{
    public class BGColorRepo
    {
        SQLiteConnection Conn;

        public string StatusMsg { get; set; }

        public BGColorRepo()
        {
            Conn = new SQLiteConnection(Constant.DatabasePathforcolor, Constant.Flags);

            Conn.CreateTable<BGColor>();
        }

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


        public BGColor Get(int id)
        {
            return
                Conn.Table<BGColor>()
                .FirstOrDefault(x => x.Id == id);
        }
    }
}