using System;

using Domain.Exceptions;

namespace Domain.Exceptions;

public sealed class ClientNotFoundException : DomainException
{
    public ClientNotFoundException()
        : base("Client not found") { }
}
