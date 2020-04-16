using System;
using System.Threading.Tasks;
using LeapingGorilla.Testing.Attributes;
using LeapingGorilla.Testing.Tests.Mocks;
using NUnit.Framework;

namespace LeapingGorilla.Testing.Tests
{
	public class WhenTestThrowsExceptionInAsyncMethodAndWeDoNotWantToCatch : WhenTestingTheBehaviourOf
	{
		[ItemUnderTest]
		public SimpleClassToTest Item { get; set; }

		[NullDependency]
		public IMockLogger Dependency { get; set; }

		private Exception _caughtException;
		
		[When]
		public async Task WeCauseAnException()
		{
			try
			{
				await Item.MethodThatThrowsAnExceptionAsync();
			}
			catch (Exception ex)
			{
				_caughtException = ex;
			}
		}
		
		[Then]
		public void ExceptionShouldBeLogged()
		{
			Assert.That(_caughtException, Is.Not.Null);
		}
		
		[Then]
		public void LoggedExceptionShouldContainTheExpectedType()
		{
			Assert.That(_caughtException, Is.TypeOf<ApplicationException>());
		}
		
		[Then]
		public void LoggedExceptionShouldHaveExpectedMessage()
		{

			Assert.That(_caughtException?.Message, Is.EqualTo(SimpleClassToTest.ExceptionMessage));
		}

		
	}
}
