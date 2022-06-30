namespace Library;

public class Book : LibraryResource {
	public Book(string name, string author, string isbn)
		: base(name, author, isbn) {}

	public string Author { get => _creator; set => _creator = value; }
	public string ISBN { get => _rating; set => _rating = value; }
}
