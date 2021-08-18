using System;
using LeapingGorilla.Testing.Core.Attributes;
using LeapingGorilla.Testing.NUnit.Attributes;
using LeapingGorilla.Testing.NUnit.Tests.Mocks;
using NUnit.Framework;

namespace LeapingGorilla.Testing.NUnit.Tests
{
	public class WhenTestThrowsExceptionAndWeDoNotWantToCatch : WhenTestingTheBehaviourOf
	{
		private Exception _thrownException;

		[ItemUnderTest]
		public SimpleClassToTest Item { get; set; }

		[NullDependency]
		public IMockLogger Dependency { get; set; }
		
		[When]
		public void WeCauseAnException()
		{
			try
			{
				Item.MethodThatThrowsAnException();
			}
			catch (Exception ex)
			{
				_thrownException = ex;
			}
		}

		[Then]
		public void ExceptionShouldBeThrown()
		{
			Assert.That(_thrownException, Is.Not.Null);
		}
		
		[Then]
		public void ExceptionShouldNotBeLogged()
		{
			Assert.That(ThrownException, Is.Null);
		}
	}
}
