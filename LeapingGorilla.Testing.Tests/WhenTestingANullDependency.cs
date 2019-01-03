using LeapingGorilla.Testing.Attributes;
using LeapingGorilla.Testing.Tests.Mocks;
using NUnit.Framework;

namespace LeapingGorilla.Testing.Tests
{
	public class WhenTestingANullDependency : WhenTestingTheBehaviourOf
	{
		[ItemUnderTest]
		public SimpleClassToTest Item { get; set; }

		[NullDependency]
		public IMockLogger Dependency { get; set; }

		private IMockLogger _result;

		[When]
		public void WeGetTheValueOfTheDependency()
		{
			_result = Item.LogGetter();
		}

		[Then]
		public void TheDependencyShouldBeNull()
		{
			Assert.That(_result, Is.Null);
		}
	}
}
