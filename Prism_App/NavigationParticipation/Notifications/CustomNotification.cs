using Prism.Interactivity.InteractionRequest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NavigationParticipation.Notifications
{
    public class CustomNotification : Confirmation, ICustomNotification
    {
        public IList<string> Items { get; private set; }

        public string SelectedItem { get; set; }

        public CustomNotification()
        {
            this.Items = new List<string>();
            this.SelectedItem = null;

            CreateItems();
        }

        private void CreateItems()
        {
            Items.Add("Item1");
            Items.Add("Item2");
            Items.Add("Item3");
            Items.Add("Item4");
            Items.Add("Item5");
            Items.Add("Item6");
        }
    }
}
