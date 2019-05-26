using Prism.Commands;

namespace CompositeCommands.Core
{
    public interface IApplicationCommands
    {
        CompositeCommand SaveAllCommand { get; }

        void UnregisterCommand(DelegateCommand delegateCommand);
    }

    public class ApplicationCommands : IApplicationCommands
    {
        public CompositeCommand SaveAllCommand { get; } = new CompositeCommand();

        /// <summary>
        /// Method to unregistor the command to avoid memory leaks
        /// </summary>
        /// <param name="delegateCommand"></param>
        public void UnregisterCommand(DelegateCommand delegateCommand)
        {
            SaveAllCommand.UnregisterCommand(delegateCommand);
        }
    }
}
