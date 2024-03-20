using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace AutomaticDemo.Base
{
    class NotifyBase: INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        public void SetProperty<T> 
            (ref T field, T value, [CallerMemberName]string propName="")
        {
            field = value;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }
    }
}
