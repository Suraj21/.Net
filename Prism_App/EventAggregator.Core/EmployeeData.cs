using Model;
using Prism.Events;

namespace EventAggregator.Core
{
    /// <summary>
    /// Event to send Employee Data
    /// </summary>
    public class EmployeeData : PubSubEvent<Employee>
    {
    }
}
