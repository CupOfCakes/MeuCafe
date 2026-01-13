using System;
using Domain.Exceptions;

namespace Domain.Exceptions;

public sealed class EmptyPasswordException : DomainException
{
	public EmptyPasswordException()
		: base("Empty client password") { }
}
