using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WpfAppMVVM.Helper;

namespace WpfAppMVVM.ViewModel
{
    public class AvalonDockViewModel : INPCBase
    {
        private ICommand _changeColorCommand;
        public ICommand ChangeColorCommand
        {
            get
            {
                return _changeColorCommand ?? (_changeColorCommand = new RelayCommand(() => ChangeColor(), IsValid));
            }
        }

        public bool IsValid()
        {
            return true;
        }

        public void ChangeColor()
        {
            if (isTrue)
                Color = "#009999";
            else Color = "#e6ffff";
        }

        public AvalonDockViewModel()
        {
            
        }

        private bool isTrue = true;

        public bool IsTrue
        {
            get { return isTrue; }
            set
            {
                if (value) Color = "#80bfff";
                else Color = "Green";

                SetProp(ref isTrue, value);
                isTrue = value;
            }
        }

        private string _color;

        public string Color
        {
            get { return _color; }
            set
            {
                SetProp(ref _color, value);
                _color = value;
            }
        }
    }
}
