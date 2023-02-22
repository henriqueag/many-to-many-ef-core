using MvcFilterApi.Notifications;

namespace MvcFilterApi.Validations;

public partial class ContractValidations<T>
{
    public ContractValidations<T> NameMinLength(string name, int minLength, string message, string propertyName) 
    {
        if(string.IsNullOrEmpty(name) || name.Length < minLength) 
        {
            AddNotification(new Notification(message, propertyName));
        }

        return this;
    }

    public ContractValidations<T> NameMaxLength(string name, int maxLength, string message, string propertyName) 
    {
        if(name.Length > maxLength) 
        {
            AddNotification(new Notification(message, propertyName));
        }

        return this;
    }

    public ContractValidations<T> NameIsNull(string name, string message, string propertyName) 
    {
        if(string.IsNullOrEmpty(name)) 
        {
            AddNotification(new Notification(message, propertyName));
        }
        
        return this;
    }
}