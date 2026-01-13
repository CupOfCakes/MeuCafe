using System;

namespace Application.Exceptions;

public abstract class ApplicationExceptions : Exception
{
	protected ApplicationExceptions(string message) : base(message) { }
}
