using System;
using System.Collections.Generic;
using WpfAppMVVM.Helper;
using WpfAppMVVM.Model;

namespace WpfAppMVVM.ViewModel
{
    public class PersonViewModel:INPCBase
    {
        
        private List<Person> _royal;
        public List<Person> Royal
        {
            get { return _royal; }
            set { SetProp(ref _royal, value); }
        }

        public PersonViewModel()
        {
            Initialize();
        }

        public void Initialize()
        {
            var p1 = new Person("George V", 1865, 1936);

            var p2 = new Person("Edward VIII", 1894, 1974);
            var p3 = new Person("George VI", 1895, 1952);
            var p4 = new Person("Mary", 1897, 1965);
            var p5 = new Person("Henry", 1900, 1974);
            var p6 = new Person("George", 1902, 1942);
            var p7 = new Person("John", 1905, 1919);

            var p8 = new Person("Elizabeth II", 1926, null);
            var p9 = new Person("Margaret", 1865, 1936);

            var p10 = new Person("Richard", 1944, null);

            var p11 = new Person("Edward", 1935, null);
            var p12 = new Person("Michael", 1942, null);

            var p13 = new Person("Charles", 1948, null);
            var p14 = new Person("Anne", 1950, null);
            var p15 = new Person("Andrew", 1960, null);
            var p16 = new Person("Edward", 1964, null);

            p1.Children.AddRange(new[] { p2, p3, p4, p5, p6, p7 });
            p3.Children.AddRange(new[] { p8, p9 });
            p5.Children.Add(p10);
            p6.Children.AddRange(new[] { p11, p12 });
            p8.Children.AddRange(new[] { p13, p14, p15, p16 });

            Royal = new List<Person>() { p1 };
        }
    }
}
