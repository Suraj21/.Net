using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace NavigationParticipation.ViewModel
{
    public class UserView1ViewModel : BindableBase, IConfirmNavigationRequest//, INavigationAware
    {
        private string _title = "User View 1";
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        private int _pageViews;
        public int PageViews
        {
            get { return _pageViews; }
            set { SetProperty(ref _pageViews, value); }
        }

        public UserView1ViewModel()
        {

        }

        public void ConfirmNavigationRequest(NavigationContext navigationContext, Action<bool> continuationCallback)
        {
            bool result = true;

            if (MessageBox.Show("Do you to navigate?", "Navigate?", MessageBoxButton.YesNo) == MessageBoxResult.No)
                result = false;

            continuationCallback(result);
        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            PageViews++;
        }

        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            //return true;
            return PageViews / 3 != 1;  //when flase always creats a new instance of tab of same Views
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {

        }
    }
}
