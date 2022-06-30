namespace CounterObject
{
	public class Program
	{
		public static void Main()
		{
			Counter[] myCounters = new Counter[3];
			myCounters[0] = new Counter("Counter 1");
			myCounters[1] = new Counter("Counter 2");
			myCounters[2] = myCounters[0];

			int i;
			for (i = 0; i++ <= 4; myCounters[0].Increment());
			for (i = 0; i++ <= 9; myCounters[1].Increment());
			PrintCounters(myCounters);
			myCounters[2].Reset();
			PrintCounters(myCounters);
		}

		private static void PrintCounters(Counter[] counters)
		{
			foreach (Counter counter in counters)
			{
				Console.WriteLine("{0} is {1}", counter.Name, counter.Ticks);
			}
		}
	}
}
