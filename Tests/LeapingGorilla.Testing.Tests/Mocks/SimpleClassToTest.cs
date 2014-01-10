namespace LeapingGorilla.Testing.Tests.Mocks
{
	public class SimpleClassToTest
	{
		private IMockLogger Log { get; set; }

		public SimpleClassToTest(IMockLogger log)
		{
			Log = log;
		}

		public void MethodThatGeneratesALogMessage()
		{
			Log.Log("Test Message");
		}

		public IMockLogger LogGetter()
		{
			return Log;
		}
	}
}
