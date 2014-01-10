using System;
using LeapingGorilla.Testing.Attributes;
using LeapingGorilla.Testing.Exceptions;
using LeapingGorilla.Testing.Tests.Mocks;
using NUnit.Framework;

namespace LeapingGorilla.Testing.Tests
{
	public class WhenTestingDependencyInjectionWithInvalidAccessLevelOnMock : WhenTestingTheBehaviourOf
	{
		private Exception _setupException;

		[Mock]
		private IMockEventRaiser _thisShouldBeAMockLogger;

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
		public void MockShouldNotBeCreated()
		{
			Assert.That(_thisShouldBeAMockLogger, Is.Null);
		}

		[Then]
		public void SetupExceptionShouldBeACannotMockPrivateFieldsException()
		{
			Assert.That(_setupException, Is.TypeOf<CannotMockPrivateFieldsException>());
		}
	}
}
