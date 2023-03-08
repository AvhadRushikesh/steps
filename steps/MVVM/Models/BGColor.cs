using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Linq;
using SQLite;
using System.Text;
using System.Threading.Tasks;

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
