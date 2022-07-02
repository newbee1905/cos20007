using System.Globalization;

namespace Calculator;

public class Program
{
	public static void Plus<T>(INumber<T> a, INumber<T> b, out INumber<T> c)
	{
		c = a + b;
	}

	public static void Main()
	{
		string[] command;
		string? inp = "";

		while (true)
		{
			Console.Write("> ");
			inp = Console.ReadLine();
			if (inp == null || inp == "quit")
				break;
			command = inp.Split(" ");
			int a, b;
			string op;
		}
	}
}
