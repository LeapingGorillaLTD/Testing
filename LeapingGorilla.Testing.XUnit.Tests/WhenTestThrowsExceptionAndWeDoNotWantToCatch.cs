using System;
using LeapingGorilla.Testing.Core.Attributes;
using LeapingGorilla.Testing.XUnit.Attributes;
using LeapingGorilla.Testing.XUnit.Tests.Mocks;
using Xunit;

namespace LeapingGorilla.Testing.XUnit.Tests
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
			Assert.NotNull(_thrownException);
		}
		
		[Then]
		public void ExceptionShouldNotBeLogged()
		{
			Assert.Null(ThrownException);
		}
	}
}
