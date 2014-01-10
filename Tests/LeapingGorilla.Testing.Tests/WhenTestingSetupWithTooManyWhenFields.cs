using System;
using LeapingGorilla.Testing.Attributes;
using LeapingGorilla.Testing.Exceptions;
using NUnit.Framework;

namespace LeapingGorilla.Testing.Tests
{
	public class WhenTestingSetupWithTooManyWhenFields : WhenTestingTheBehaviourOf
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
		public void WhenOne()
		{
			
		}

		[When]
		public void WhenTwo()
		{
			
		}

		[Then]
		public void SetupShouldThrowAnException()
		{
			Assert.That(_setupException, Is.Not.Null);
		}

		[Then]
		public void SetupExceptionShouldBeAWhenMethodMayOnlyAppearOnceException()
		{
			Assert.That(_setupException, Is.TypeOf<WhenMethodMayOnlyAppearOnceException>());
		}
	}
}
