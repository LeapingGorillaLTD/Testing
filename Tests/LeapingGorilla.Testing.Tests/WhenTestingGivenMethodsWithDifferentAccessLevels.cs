using LeapingGorilla.Testing.Attributes;
using NUnit.Framework;

namespace LeapingGorilla.Testing.Tests
{
	public class WhenTestingGivenMethodsWithDifferentAccessLevels : WhenTestingTheBehaviourOf
	{
		private bool _publicGivenCalled = false;
		private bool _privateGivenCalled = false;
		private bool _protectedGivenCalled = false;

		[Given]
		public void PublicGiven()
		{
			_publicGivenCalled = true;
		}

		[Given]
		protected void ProtectedGiven()
		{
			_protectedGivenCalled = true;
		}

		[Given]
		private void PrivateGiven()
		{
			_privateGivenCalled = true;
		}

		[Then]
		public void PublicGivenShouldBeCalled()
		{
			Assert.That(_publicGivenCalled, Is.True);
		}

		[Then]
		public void ProtectedGivenShouldBeCalled()
		{
			Assert.That(_protectedGivenCalled, Is.True);
		}

		[Then]
		public void PrivateGivenShouldBeCalled()
		{
			Assert.That(_privateGivenCalled, Is.True);
		}
	}
}
