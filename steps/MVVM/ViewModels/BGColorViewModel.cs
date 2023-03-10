using Microsoft.Maui.Graphics.Converters;
using PropertyChanged;
using steps.MVVM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace steps.MVVM.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class BGColorViewModel
    {
        public List<BGColor> color { get; set; }
        public BGColor Addcolor { get; set; }

        public ICommand AddColorCommand { get; set; }

        public BGColorViewModel()
        {
            GetColorFromTable();

            AddColorCommand = new Command(async () =>
            {
                App._colorRepo.AddOrUpdateColor(Addcolor);
                GetColorFromTable();
            });
        }


        public void GetColorFromTable()
        {
            Addcolor = App._colorRepo.Get(1);
        }
    }
}