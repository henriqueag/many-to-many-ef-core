using MvcFilterApi.Notifications;
using MvcFilterApi.Validations.Interfaces;

namespace MvcFilterApi.Validations;

public partial class ContractValidations<T> where T : IContract
{
    private List<Notification> _notifications;

    public ContractValidations()
    {
        _notifications = new List<Notification>();
    }

    public IReadOnlyCollection<Notification> Notifications => _notifications;
    public bool IsValid => _notifications.Count == 0 ? true : false;
    
    public void AddNotification(Notification notification)
    {
        _notifications.Add(notification);
    }
}