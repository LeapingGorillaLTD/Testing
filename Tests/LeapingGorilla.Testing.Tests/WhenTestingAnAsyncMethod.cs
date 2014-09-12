using System.Threading.Tasks;
using LeapingGorilla.Testing.Attributes;
using NUnit.Framework;

namespace LeapingGorilla.Testing.Tests
{
	public class WhenTestingAnAsyncMethod : WhenTestingTheBehaviourOf
	{
		private int _result;
		private int _expectedReturnValue;

		public async Task<int> SampleMethod()
		{
			await Task.Delay(50);
			return _expectedReturnValue;
		}

		[Given]
		public void WeHaveExpectedReturnValue()
		{
			_expectedReturnValue = 12345;
		}

		[When]
		public async Task WeCanUseWhenOnMethodReturningTask()
		{
			_result = await SampleMethod();
		}

		[Then]
		public void ResultShouldBeAsExpected()
		{
			Assert.That(_result, Is.EqualTo(_expectedReturnValue));
		}
	}
}
