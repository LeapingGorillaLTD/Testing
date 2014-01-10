using System;

namespace LeapingGorilla.Testing.Exceptions
{
	public class GivenMethodsMustBeVoidException : ApplicationException
	{
		public GivenMethodsMustBeVoidException(string methodName)
			: base(String.Format("The method {0} cannot be marked with the [Given] attribute - all [Given] methods must be void", methodName))
		{
			
		}
	}
}
