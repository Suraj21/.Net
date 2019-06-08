using NavigationParticipation.Notifications;
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

        public InteractionRequest<ICustomNotification> CustomNotificationRequest { get; set; }
        public DelegateCommand CustomNotificationCommand { get; set; }

        private string _title = "Prism Unity Application";
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        private string _UserSelectionInformation = "User Selection Information";
        public string UserSelectionInformation
        {
            get { return _UserSelectionInformation; }
            set { SetProperty(ref _UserSelectionInformation, value); }
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

            CustomNotificationRequest = new InteractionRequest<ICustomNotification>();
            CustomNotificationCommand = new DelegateCommand(RaiseCustomInteraction);
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

        private void RaiseCustomInteraction()
        {
            CustomNotificationRequest.Raise(new CustomNotification { Title = "Custom Notification" }, r =>
            {
                if (r.Confirmed && r.SelectedItem != null)
                    UserSelectionInformation = $"User selected: { r.SelectedItem}";
                else
                    UserSelectionInformation = "User cancelled or didn't select an item";
            });
        }

    }
}
