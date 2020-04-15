using System;
using LeapingGorilla.Testing.Attributes;
using LeapingGorilla.Testing.Tests.Mocks;
using NUnit.Framework;

namespace LeapingGorilla.Testing.Tests
{
	public class WhenTestThrowsExceptionAndWeWantToCatch : WhenTestingTheBehaviourOf
	{
		[ItemUnderTest]
		public SimpleClassToTest Item { get; set; }

		[NullDependency]
		public IMockLogger Dependency { get; set; }
		
		[When(DoNotRethrowExceptions: true)]
		public void WeCauseAnException()
		{
			Item.MethodThatThrowsAnException();
		}
		
		[Then]
		public void ExceptionShouldBeLogged()
		{
			Assert.That(ThrownException, Is.Not.Null);
		}
		
		[Then]
		public void LoggedExceptionShouldBeExpectedType()
		{
			Assert.That(ThrownException, Is.TypeOf<ApplicationException>());
		}
		
		[Then]
		public void LoggedExceptionShouldHaveExpectedMessage()
		{
			Assert.That(ThrownException?.Message, Is.EqualTo(SimpleClassToTest.ExceptionMessage));
		}

		
	}
}
