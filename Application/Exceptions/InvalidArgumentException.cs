using System;
using Application.Exceptions;

namespace Application.Exceptions;

public sealed class InvalidArgumentException : ApplicationException
{
    public InvalidArgumentException()
        : base("Missing argument") { }
}
