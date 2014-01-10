using System;
using NUnit.Framework;

namespace LeapingGorilla.Testing.Attributes
{
	[AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
	public sealed class ThenAttribute : TestAttribute
	{
	}
}
