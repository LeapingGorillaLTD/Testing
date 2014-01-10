using System;

namespace LeapingGorilla.Testing.Attributes
{
	[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false)]
	public sealed class MockAttribute : Attribute
	{
	}
}
