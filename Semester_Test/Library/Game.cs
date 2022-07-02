namespace Library;

public class Game : LibraryResource {
	private string _contentRating;

	public Game(string name, string developer, string contentRating)
		: base(name, developer)
			=> _contentRating = contentRating;

	public string Developer => _creator;
	public string ContentRating => _contentRating;
}
