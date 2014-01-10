using LeapingGorilla.Testing.Attributes;
using LeapingGorilla.Testing.Tests.Mocks;
using NUnit.Framework;

namespace LeapingGorilla.Testing.Tests
{
	public class WhenTestingMocking : WhenTestingTheBehaviourOf
	{
		[Mock]
		public IMockLogger publicFieldMock;

		[Mock]
		public IMockLogger PublicPropertyMock { get; set; }

		[Then]
		public void PublicFieldMockShouldBeCreated()
		{
			Assert.That(publicFieldMock, Is.Not.Null);
		}

		[Then]
		public void PublicPropertyMockShouldBeCreated()
		{
			Assert.That(PublicPropertyMock, Is.Not.Null);
		}
	}
}
