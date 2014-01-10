using System;

namespace LeapingGorilla.Testing.Exceptions
{
	public class WhenMethodsMustBeVoidException : ApplicationException
	{
		public WhenMethodsMustBeVoidException(string methodName)
			: base(String.Format("The method {0} cannot be marked with the [When] attribute - all [When] methods must be void", methodName))
		{
			
		}
	}
}
