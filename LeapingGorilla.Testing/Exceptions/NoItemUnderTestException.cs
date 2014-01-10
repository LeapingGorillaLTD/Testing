using System;

namespace LeapingGorilla.Testing.Exceptions
{
	public class NoItemUnderTestException : ApplicationException
	{
		public NoItemUnderTestException() : base("This test class does not contain a field or property marked with the [ItemUnderTest] attribute but some fields or properties have been marked with the [Dependency] attribute") {}
	}
}
