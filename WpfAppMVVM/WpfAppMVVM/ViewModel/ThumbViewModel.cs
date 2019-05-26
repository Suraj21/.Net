using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace WpfAppMVVM.ViewModel
{
    public class ThumbViewModel : INotifyPropertyChanged
    {
        private BobNotify _bobNotify;

        private string _yourText;
        public string YourText
        {
            get { return _yourText; }
            set
            {
                if (SetProp(ref _yourText, value))
                {
                    // E-mail Bob if someone types his name
                    // (but we forgot to initialize BobNotify object, so will get NullRefException here).
                    if (_yourText == "Bob")
                        _bobNotify.SendEmail(_yourText);

                    RaisePropertyChanged("TextLength");
                }
            }
        }

        public int TextLength
        {
            get
            {
                return string.IsNullOrWhiteSpace(_yourText) ? 0 : _yourText.Length;
            }
        }

        protected bool SetProp<T>(ref T backingField, T value, [CallerMemberName] string propName = null)
        {
            bool valueChanged = false;

            // Can't use equality operator on generic types
            if (!EqualityComparer<T>.Default.Equals(backingField, value))
            {
                backingField = value;
                RaisePropertyChanged(propName);
                valueChanged = true;
            }

            return valueChanged;
        }

        public event PropertyChangedEventHandler PropertyChanged = delegate { };

        private void RaisePropertyChanged(string propname)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(propname));
        }
    }

    internal class BobNotify
    {
        public string Email { get; set; }

        public void SendEmail(string text)
        {
            Email = text != null ? text:"Mail has been sent" ;
        }
    }
}
