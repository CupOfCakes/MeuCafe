using System;
using Domain.Exceptions;

namespace Domain.Exceptions;

public sealed class InvalidEmailException
{
	public InvalidEmailException()
		: base("Invalid client Email") { }
}
