using System;

namespace LeapingGorilla.Testing.Attributes
{
	[AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
	public sealed class GivenAttribute : Attribute
	{
		public int Order { get; set; }
	}
}
