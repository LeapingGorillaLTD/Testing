namespace LeapingGorilla.Testing.Tests.Mocks
{
	public class ClassRaisingAnEvent
	{
		private IMockEventRaiser EventRaiser { get; set; }

		public ClassRaisingAnEvent()
		{}

		public ClassRaisingAnEvent(IMockEventRaiser eventRaiser)
		{
			EventRaiser = eventRaiser;
		}

		public string DoSomethingWithTheEventRaiser(bool severe)
		{
			return EventRaiser.RaiseEvent(severe);
		}
	}
}
