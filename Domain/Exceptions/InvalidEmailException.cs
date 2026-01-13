using System;
using Domain.Exceptions;

namespace Domain.Exceptions;

public sealed class InvalidEmailException : DomainException
{
	public InvalidEmailException()
		: base("Invalid client Email") { }
}
