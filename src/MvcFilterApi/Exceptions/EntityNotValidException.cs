using System.Runtime.Serialization;
using MvcFilterApi.Notifications;

namespace MvcFilterApi.Exceptions;

public class EntityNotValidException : Exception
{
    public EntityNotValidException(string code, string message, IEnumerable<Notification> notifications)
        : base(message)
    {
        Code = code;
        Notifications = notifications;
    }

    public string Code { get; }
    public IEnumerable<Notification> Notifications { get; }
}