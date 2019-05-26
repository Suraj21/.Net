using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using WpfAppMVVM.Model;

namespace WpfAppMVVM.View.TemplateSelector
{
    public class UserAgeDataTemplateSelector : DataTemplateSelector
    {
        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            //return base.SelectTemplate(item, container);
            FrameworkElement element = container as FrameworkElement;
            if (element != null && item != null && item is User)
            {
                User user = (User)item;
                if (user.State == "UP") return (DataTemplate)element.TryFindResource("InverseUserTemplate");
                else return (DataTemplate)element.TryFindResource("UserDataTemplate");
            }
            else
                return null;
        }
    }
}
