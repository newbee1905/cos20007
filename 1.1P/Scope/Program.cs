using System;

namespace Scope {
	public class Program {
		double c = 4.0;

		public static void Main(string[] args) {
			var _ = new Program();
			double c = 6.0;

			void DemoScope() {
				double c = 5.0;
				// This will print out 5.0
				Console.WriteLine($"Demo scope: {c:0.0}");
			}

			void DemoScope2() {
				Console.WriteLine($"Demo scope: {c:0.0}");
			}

			// This will print out 4.0
			Console.WriteLine($"Main function: {_.c:0.0}");
			// This will print out 6.0
			Console.WriteLine($"Main function: {c:0.0}");
			DemoScope();
			// This will print out 6.0
			// Since it doesn't declare a local variable c 
			// and it will use the global scope one
			DemoScope2();

			{
				int a = 3;
				Console.WriteLine($"Block level: {a}");
			}

			// Uncomment the next-line will cause compile error since
			// variable a is only initialized inside a block scope
			// Console.WriteLine($"Main function: {a}");
		}
	}
}
