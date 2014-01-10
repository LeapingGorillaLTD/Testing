using System;
using LeapingGorilla.Testing.Attributes;
using LeapingGorilla.Testing.Exceptions;
using LeapingGorilla.Testing.Tests.Mocks;
using NUnit.Framework;

namespace LeapingGorilla.Testing.Tests
{
	public class WhenTestingDependencyInjectionWithNoItemUnderTest : WhenTestingTheBehaviourOf
	{
		private Exception _setupException;

		public SimpleClassToTest SimpleClassMIssingItemUnderTestAttribute { get; set; }

		[Dependency]
		public IMockLogger MockLogger { get; set; }

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
		public void SetupExceptionShouldBeANoItemUnderTestException()
		{
			Assert.That(_setupException, Is.TypeOf<NoItemUnderTestException>());
		}
	}
}
