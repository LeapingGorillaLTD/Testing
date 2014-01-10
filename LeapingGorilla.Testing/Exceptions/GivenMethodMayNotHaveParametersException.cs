using System;

namespace LeapingGorilla.Testing.Exceptions
{
	public class GivenMethodMayNotHaveParametersException : ApplicationException
	{
		public GivenMethodMayNotHaveParametersException(string methodName) :
			base(String.Format("The method {0} may not be marked as [Given] - All [Given] methods must not take any parameters", methodName))
		{
			
		}
	}
}
