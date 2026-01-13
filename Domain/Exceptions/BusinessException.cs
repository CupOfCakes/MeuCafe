using System;

using Domain.Exceptions;

namespace Domain.Exceptions;

public sealed class BusinessException : DomainException
{
    public BusinessException()
        : base("bussiness rules violated") { }
}
