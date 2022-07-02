using System;

namespace Library;

public class Program {
	public static void Main() {
		Library library = new("Kodo's library");
		Book book1 = new("Le Comte de Monte-Cristo", "Alexandre Dumas", "0199219656");
		Book book2 = new("Chainsaw Man, Vol. 1 (1)", "Tatsuki Fujimoto", "1974709930");
		Game game1 = new("Genshin Impact", "Hoyoverse", "PEGI 12");
		Game game2 = new("Fate Grand Order(EN)", "Delightworks", "12+");

		book1.OnLoan = true;
		game2.OnLoan = true;

		library.AddResource(book1);
		library.AddResource(book2);
		library.AddResource(game1);
		library.AddResource(game2);

		// should return true
		Console.WriteLine(library.HasResource("Chainsaw Man, Vol. 1 (1)"));
		// should return false
		Console.WriteLine(library.HasResource("Fate Grand Order(EN)"));
	}
}
