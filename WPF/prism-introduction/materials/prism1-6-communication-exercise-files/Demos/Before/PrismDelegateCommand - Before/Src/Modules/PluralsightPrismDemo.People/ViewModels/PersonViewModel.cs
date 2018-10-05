using System;
using PluralsightPrismDemo.Infrastructure;
using PluralsightPrismDemo.Business;

namespace PluralsightPrismDemo.People
{
    public class PersonViewModel : ViewModelBase, IPersonViewModel
    {
        public PersonViewModel(IPersonView view)
            : base(view)
        {
            CreatePerson();
        }

        private Person _person;
        public Person Person
        {
            get { return _person; }
            set
            {
                _person = value;
                OnPropertyChanged("Person");
            }
        }

        private void CreatePerson()
        {
            Person = new Person()
            {
                FirstName = "Bob",
                LastName = "Smith",
                Age = 46
            };
        }
    }
}
