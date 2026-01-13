using System;
using Domain.Exceptions;

namespace Domain.Exceptions;

public sealed class EmptyClientNameException : DomainException
{
	public EmptyClientNameException()
		: base("Empty client name") { }
}
