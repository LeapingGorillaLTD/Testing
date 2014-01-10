using System;
using LeapingGorilla.Testing.Attributes;
using LeapingGorilla.Testing.Exceptions;
using LeapingGorilla.Testing.Tests.Mocks;
using NUnit.Framework;

namespace LeapingGorilla.Testing.Tests
{
	public class WhenTestingDependencyInjectionWithInvalidDependencies : WhenTestingTheBehaviourOf
	{
		[ItemUnderTest]
		public ClassWithMultipleParametersOfSameType ClassToTest { get; set; }

		[Dependency]
		public IMockLogger FakeLogger { get; set; }
		
		[Dependency]
		public IMockEventRaiser ThisShouldBeAnotherLogger { get; set; }

		private Exception _setupException;

		public override void Setup()
		{
			try
			{
				base.Setup();
			}
			catch (Exception ex)
			{
				_setupException = ex;
			}
		}

		[Then]
		public void SetupShouldThrowAnException()
		{
			Assert.That(_setupException, Is.Not.Null);
		}

		[Then]
		public void SetupExceptionShouldBeADependencyMismatchException()
		{
			Assert.That(_setupException, Is.TypeOf<DependencyMismatchException>());
		}
	}
}
