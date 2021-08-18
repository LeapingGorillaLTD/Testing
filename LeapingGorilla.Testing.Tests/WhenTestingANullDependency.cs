using LeapingGorilla.Testing.Core.Attributes;
using LeapingGorilla.Testing.NUnit.Attributes;
using LeapingGorilla.Testing.NUnit.Tests.Mocks;
using NUnit.Framework;

namespace LeapingGorilla.Testing.NUnit.Tests
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
