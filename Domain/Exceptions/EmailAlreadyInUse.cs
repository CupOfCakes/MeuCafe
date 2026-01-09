using System;
using Domain.Exceptions;

namespace Domain.Exceptions;

public sealed class EmailAlreadyInUse : DomainException
{
	public EmailAlreadyInUse()
		: base("Email alreay in use") { }
}
