using Prism.Interactivity.InteractionRequest;

namespace NavigationParticipation.Notifications
{
    public interface ICustomNotification : IConfirmation
    {
        string SelectedItem { get; set; }
    }
}
