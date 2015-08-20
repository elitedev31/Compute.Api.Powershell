namespace x2C.lib
{
	public class TestOutcomeResult
	{
		public TestOutcomeResult(string test, TestOutcome outcome)
		{
			Test = test;
			Outcome = outcome;
		}

		public string Test { get; set; }

		public string[] Messages
		{
			get { return Outcome.Messages.ToArray(); }
		}

		public TestingOutcomeType Result
		{
			get { return Outcome.Type; }
		}

		private TestOutcome Outcome { get; set; }
	}
}
