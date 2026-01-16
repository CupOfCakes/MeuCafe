using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Common;
using Domain.Exceptions;

namespace Domain.Entities;

public class Client
{
    public Guid Id{get; init;} = Guid.NewGuid();

    public string Name{get; set;} = string.Empty;

    public string Email{get; set;} = string.Empty;

    public string HashPassword {get; init; } = string.Empty;

    public string Description {get; set;} = string.Empty;

    public string ProfilePicURL {get; set;} = string.Empty;

    public string BackgroundPicURL {get; set;} = string.Empty;

    public DateTimeOffset CreatedAt {get; init;} = DateTimeOffset.UtcNow;

    public bool IsActive { get; set; } = true;

    public Client() { }

    public Client(string name, string email, string hashPassword)
    {
        if(string.IsNullOrWhiteSpace(name)) 
            throw new EmptyClientNameException();

        if (string.IsNullOrWhiteSpace(email) ||
            !new EmailAddressAttribute().IsValid(email))
            throw new InvalidEmailException();

        if (string.IsNullOrWhiteSpace(hashPassword))
            throw new EmptyPasswordException();

        Name = name;
        Email = email;
        HashPassword = hashPassword;
    }

}