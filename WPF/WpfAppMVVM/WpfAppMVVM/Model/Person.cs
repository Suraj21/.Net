using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfAppMVVM.Helper;

namespace WpfAppMVVM.Model
{
    public class Person : INPCBase
    {
        public Person()
        {

        }
        public Person(string name, int birth, int? death)
        {
            Name = name;
            Birth = birth;
            Death = death;

            Children = new List<Person>();
        }

        private string _name;
        public string Name
        {
            get { return _name; }
            set { SetProp(ref _name, value); }
        }

        private int _birth;
        public int Birth
        {
            get { return _birth; }
            set { SetProp(ref _birth, value); }
        }

        private int? _death;
        public int? Death
        {
            get { return _death; }
            set { SetProp(ref _death, value); }
        }

        private List<Person> _children;
        public List<Person> Children
        {
            get { return _children; }
            private set { SetProp(ref _children, value); }
        }

        public override string ToString()
        {
            string death = Death.HasValue ? Death.Value.ToString() : "";
            return string.Format($"{Name} ({Birth} - {death})");
        }

        private List<Person> _royal;
        public List<Person> Royal
        {
            get { return _royal; }
            set { SetProp(ref _royal, value); }
        }
    }
}
