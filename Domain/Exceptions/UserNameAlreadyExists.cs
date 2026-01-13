using System;
using Domain.Exceptions;

namespace Domain.Exceptions;

public sealed class UserNameAlreadyExists : DomainException
{
    public UserNameAlreadyExists()
        : base("User name already exists") { }
}
