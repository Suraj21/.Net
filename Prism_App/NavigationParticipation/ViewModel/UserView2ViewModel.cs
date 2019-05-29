using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NavigationParticipation.ViewModel
{
    public class UserView2ViewModel : BindableBase, INavigationAware
    {
        private string _title = "User View 2";
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

        public UserView2ViewModel()
        {

        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            PageViews++;
        }

        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            //return true;
            //return PageViews / 6 != 1;
            return false; //when flase always creats a new instance of tab of same Views
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {

        }
    }
}
