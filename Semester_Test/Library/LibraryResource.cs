namespace Library;

public abstract class LibraryResource {
	private string _name;
	protected string _creator, _rating;
	private bool _onLoan;

	public LibraryResource(string name, string creator, string rating) {
		_name = name;
		_creator = creator;
		_rating = rating;
		_onLoan = false;
	}

	public string Name => _name;
	public bool OnLoan { get => _onLoan; set => _onLoan= value; }
}
