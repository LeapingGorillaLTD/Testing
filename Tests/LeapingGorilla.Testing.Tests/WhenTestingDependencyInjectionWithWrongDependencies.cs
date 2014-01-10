using System;
using LeapingGorilla.Testing.Attributes;
using LeapingGorilla.Testing.Exceptions;
using LeapingGorilla.Testing.Tests.Mocks;
using NUnit.Framework;

namespace LeapingGorilla.Testing.Tests
{
	public class WhenTestingDependencyInjectionWithWrongDependencies : WhenTestingTheBehaviourOf
	{
		private Exception _setupException;

		[ItemUnderTest]
		public SimpleClassToTest BadItem { get; set; }

		[Dependency]
		public IMockEventRaiser ThisShouldBeAMockLogger;

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
		public void SetupExceptionShouldBeANoMatchingConstructorFoundException()
		{
			Assert.That(_setupException, Is.TypeOf<NoMatchingConstructorFoundException>());
		}
	}
}
