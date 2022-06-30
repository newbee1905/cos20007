namespace Library;

public class Game : LibraryResource {
	public Game(string name, string developer, string contentRating)
		: base(name, developer, contentRating) {}

	public string Developer => _creator;
	public string ContentRating => _rating;
}
