using System;
using LeapingGorilla.Testing.Attributes;
using LeapingGorilla.Testing.Exceptions;
using LeapingGorilla.Testing.Tests.Mocks;
using NUnit.Framework;

namespace LeapingGorilla.Testing.Tests
{
	public class WhenTestingSetupWithAWhenMethodThatHasAReturnType : WhenTestingTheBehaviourOf
	{
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

		[When]
		public int BadWhenWithReturnType()
		{
			return 5;
		}

		[Then]
		public void SetupShouldThrowAnException()
		{
			Assert.That(_setupException, Is.Not.Null);
		}

		[Then]
		public void SetupExceptionShouldBeAWhenMethodsMustBeVoidException()
		{
			Assert.That(_setupException, Is.TypeOf<WhenMethodsMustBeVoidException>());
		}
	}
}
