using CompositeCommands.Core;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompositeCommandExample.ViewModel
{
    public class CompositeCommandViewModel: BindableBase
    {
        private string _selectedItemText;
        public string SelectedItemText
        {
            get { return _selectedItemText; }
            private set { SetProperty(ref _selectedItemText, value); }
        }

        public IList<string> Items { get; private set; }

        public DelegateCommand<object[]> SelectedCommand { get; private set; }

        private IApplicationCommands _applicationCommands;
        public IApplicationCommands ApplicationCommands
        {
            get { return _applicationCommands; }
            set { SetProperty(ref _applicationCommands, value); }
        }

        public CompositeCommandViewModel(IApplicationCommands applicationCommands)
        {
            ApplicationCommands = applicationCommands;

            Items = new List<string>();

            Items.Add("Item1");
            Items.Add("Item2");
            Items.Add("Item3");
            Items.Add("Item4");
            Items.Add("Item5");

            // This command will be executed when the selection of the ListBox in the view changes.
            SelectedCommand = new DelegateCommand<object[]>(OnItemSelected);
        }

        private void OnItemSelected(object[] selectedItems)
        {
            if (selectedItems != null && selectedItems.Count() > 0)
            {
                SelectedItemText = selectedItems.FirstOrDefault().ToString();
            }
        }
    }
}
