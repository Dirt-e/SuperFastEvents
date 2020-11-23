using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperFastEvents.ViewModel
{
    public class MyViewmodel : INotifyPropertyChanged
    {
        //INotifyPropertyChanged:
        public event PropertyChangedEventHandler PropertyChanged;
        private protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
