using LeapingGorilla.Testing.Attributes;
using LeapingGorilla.Testing.Tests.Mocks;
using NSubstitute;
using NUnit.Framework;

namespace LeapingGorilla.Testing.Tests
{
	public class WhenTestingDependencyInjectionWithAField : WhenTestingTheBehaviourOf
	{
		[ItemUnderTest] 
		public SimpleClassToTest SimpleClass;

		[Dependency] 
		public IMockLogger FakeLogger;

		[When]
		protected void MyClassRaisesALoggingEvent()
		{
			SimpleClass.MethodThatGeneratesALogMessage();
		}

		[Then]
		public void TheFakeLoggerShouldBeCreated()
		{
			Assert.That(FakeLogger, Is.Not.Null);
		}

		[Then]
		public void WeShouldReceiveACallToLog()
		{
			FakeLogger.Received().Log(Arg.Any<string>());
		}

		[Then]
		public void TheSimpleClassShouldBeCreated()
		{
			Assert.That(SimpleClass, Is.Not.Null);
		}
	}
}
