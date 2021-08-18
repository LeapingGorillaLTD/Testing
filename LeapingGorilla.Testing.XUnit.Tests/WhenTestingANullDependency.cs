using LeapingGorilla.Testing.Core.Attributes;
using LeapingGorilla.Testing.XUnit.Attributes;
using LeapingGorilla.Testing.XUnit.Tests.Mocks;
using Xunit;

namespace LeapingGorilla.Testing.XUnit.Tests
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
			Assert.Null(_result);
		}
	}
}
