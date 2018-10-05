﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using WpfAppHierAndNav.ViewModel;

namespace WpfAppHierAndNav
{
    public class BindableBase : INotifyPropertyChanged
    {
        protected virtual void SetProperty<T>(ref T member, T Val, [CallerMemberName] string propertyName = null)
        {
            if (object.Equals(member, Val)) return;
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        public event PropertyChangedEventHandler PropertyChanged = delegate { };

        public static implicit operator BindableBase(OrderViewModel v)
        {
            throw new NotImplementedException();
        }
    }
}
