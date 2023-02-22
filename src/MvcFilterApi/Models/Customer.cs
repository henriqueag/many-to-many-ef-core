using MvcFilterApi.Exceptions;
using MvcFilterApi.Validations;
using MvcFilterApi.Validations.Interfaces;

namespace MvcFilterApi.Models;

public class Customer : IValidate, IContract
{
    public Customer(string name, int age)
    {
        Id = Guid.NewGuid();
        CreatedAt = DateTime.UtcNow;

        Name = name;
        Age = age;

        Validate();
    }

    public Guid Id { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public string Name { get; private set; }
    public int Age { get; private set; }

    public void Validate()
    {
        var contracts = new ContractValidations<Customer>()
            .NameIsNull(Name, "O nome está nulo ou vazio", nameof(Name))
            .NameMinLength(Name, 4, "O tamanho mínimo para o nome é 4 caracteres", nameof(Name))
            .NameMaxLength(Name, 128, "O tamanho máximo para o nome é 128 caracteres", nameof(Name));

        if(!contracts.IsValid) 
        {
            throw new EntityNotValidException(
                "entity-not-valid",
                "A construção da entidade Customer falhou, verifique os erros e tente novamente",
                contracts.Notifications);
        }
    }
}