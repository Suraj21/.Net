using Prism.Commands;
using Prism.Interactivity.InteractionRequest;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NavigationParticipation.ViewModel
{
    public class NavigationParticipationViewViewModel : BindableBase
    {
        private readonly IRegionManager _regionManager;

        public InteractionRequest<INotification> NotificationRequest { get; set; }
        public DelegateCommand NotificationCommand { get; set; }

        public InteractionRequest<IConfirmation> ConfirmationRequest { get; set; }
        public DelegateCommand ConfirmationCommand { get; set; }

        public InteractionRequest<INotification> CustomPopupRequest { get; set; }
        public DelegateCommand CustomPopupCommand { get; set; }

        private string _title = "Prism Unity Application";
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        public DelegateCommand<string> NavigateCommand { get; private set; }

        public NavigationParticipationViewViewModel(IRegionManager regionManager)
        {
            _regionManager = regionManager;

            NavigateCommand = new DelegateCommand<string>(Navigate);

            NotificationRequest = new InteractionRequest<INotification>();
            NotificationCommand = new DelegateCommand(RaiseNotification);

            ConfirmationRequest = new InteractionRequest<IConfirmation>();
            ConfirmationCommand = new DelegateCommand(RaiseConfirmation);

            CustomPopupRequest = new InteractionRequest<INotification>();
            CustomPopupCommand = new DelegateCommand(RaiseCustomPopup);

        }

        private void Navigate(string navigatePath)
        {
            if (navigatePath != null)
                _regionManager.RequestNavigate("NavigateParticipationContentRegion", navigatePath);
        }

        void RaiseNotification()
        {
            NotificationRequest.Raise(new Notification { Content = "Notification Message", Title = "Notification" }, r => Title = "Notified");
        }

        void RaiseConfirmation()
        {
            ConfirmationRequest.Raise(new Confirmation
            {
                Title = "Confirmation",
                Content = "Confirmation Message"
            },
                r => Title = r.Confirmed ? "Confirmed" : "Not Confirmed");
        }

        void RaiseCustomPopup()
        {
            CustomPopupRequest.Raise(new Notification { Title = "Custom Popup", Content = "Custom Popup Message " }, r => Title = "Good to go");
        }

    }
}
