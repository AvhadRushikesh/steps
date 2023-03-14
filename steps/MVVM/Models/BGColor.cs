using PropertyChanged;
using SQLite;

namespace steps.MVVM.Models
{
    [AddINotifyPropertyChangedInterface]
    public class BGColor
    {
        [PrimaryKey]
        public int Id { get; set; }
        public string BackColor { get; set; }
    }
}
