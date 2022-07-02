namespace Library;

public class Book : LibraryResource {
	private string _isbn;

	public Book(string name, string author, string isbn)
		: base(name, author)
			=> _isbn = isbn;

	public string Author => _creator;
	public string ISBN => _isbn;
}
