using LeapingGorilla.Testing.Attributes;
using NUnit.Framework;

namespace LeapingGorilla.Testing.Tests
{
	public class WhenTestingMultipleGivenMethods : WhenTestingTheBehaviourOf
	{
		private int _given1 = -1;
		private int _given2 = -1;
		private int _given3 = -1;

		private int _givenCounter = 0;

		[Given(Order = 3)]
		public void IHaveGivenThree()
		{
			_given3 = ++_givenCounter;
		}

		[Given(Order = 1)]
		public void IHaveGivenOne()
		{
			_given1 = ++_givenCounter;
		}

		[Given(Order = 2)]
		public void IHaveGivenTwo()
		{
			_given2 = ++_givenCounter;
		}

		[Then]
		public void TheCounterShouldBeSetAtThree()
		{
			Assert.That(_givenCounter, Is.EqualTo(3));
		}

		[Then]
		public void Given1ShouldBe1()
		{
			Assert.That(_given1, Is.EqualTo(1));
		}

		[Then]
		public void Given2ShouldBe2()
		{
			Assert.That(_given2, Is.EqualTo(2));
		}

		[Then]
		public void Given3ShouldBe3()
		{
			Assert.That(_given3, Is.EqualTo(3));
		}
	}
}
