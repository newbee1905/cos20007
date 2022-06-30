using System;

namespace Clock {
	public class Program {
		public static void Main() {
			Clock clock = new Clock();

			for (int i = 0; i++ < 86400 + 48265; clock.Tick());

			Console.WriteLine("Should output: 13:24:25");
			Console.WriteLine(clock.Time);
		}
	}
}
