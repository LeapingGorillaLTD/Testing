using System;

namespace LeapingGorilla.Testing.Exceptions
{
	public class WhenMethodMayNotHaveParametersException : ApplicationException
	{
		public WhenMethodMayNotHaveParametersException(string methodName) :
			base(String.Format("The method {0} may not be marked as [When] - All [When] methods must not take any parameters", methodName))
		{
			
		}
	}
}
