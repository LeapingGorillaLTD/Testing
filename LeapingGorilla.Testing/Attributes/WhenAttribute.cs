using System;

namespace LeapingGorilla.Testing.Attributes
{
	[AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
	public sealed class WhenAttribute : Attribute
	{
	}
}
