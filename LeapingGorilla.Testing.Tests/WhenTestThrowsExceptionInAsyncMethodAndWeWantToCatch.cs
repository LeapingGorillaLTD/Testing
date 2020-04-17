using System;
using System.Threading.Tasks;
using LeapingGorilla.Testing.Attributes;
using LeapingGorilla.Testing.Tests.Mocks;
using NUnit.Framework;

namespace LeapingGorilla.Testing.Tests
{
	public class WhenTestThrowsExceptionInAsyncMethodAndWeWantToCatch : WhenTestingTheBehaviourOf
	{
		[ItemUnderTest]
		public SimpleClassToTest Item { get; set; }

		[NullDependency]
		public IMockLogger Dependency { get; set; }
		
		[When(DoNotRethrowExceptions: true)]
		public async Task WeCauseAnException()
		{
			await Item.MethodThatThrowsAnExceptionAsync();
		}
		
		[Then]
		public void ExceptionShouldBeLogged()
		{
			Assert.That(ThrownException, Is.Not.Null);
		}
		
		[Then]
		public void LoggedExceptionShouldContainTheExpectedType()
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
