using System;

namespace HelloWorld
{
	static public class Program
	{
		public static void Main(string[] args)
		{
			Message[] messages = new Message[] {
				new Message("Ah yes to lonely Minh"),
				new Message("How's your day mah fiend?"),
				new Message("Such disappointment"),
				new Message("Oivia Desu"),
				new Message("Begone Kodokuna Hachi"),
				new Message("That is a silly name"),
			};

			Message myMessage = new Message(@"
Hello World
From HelloWorld Project
");
			myMessage.Print();

			Console.Write("Enter name: ");
			string? name = Console.ReadLine();

			if (string.IsNullOrEmpty(name))
			{
				Console.ForegroundColor = ConsoleColor.Red;
				Console.WriteLine("Please Provide a name");
				Console.ResetColor();
				return;
			}

			// shorter + cleaner than normal switch
			byte messageId = name.ToLower() switch
			{
				"kodo" => 0,
				"fukun" => 1,
				"wabi" => 2,
				"thinh" => 3,
				"minh" => 4,
				_ => 5,
			};
			messages[messageId].Print();
		}
	}
}
