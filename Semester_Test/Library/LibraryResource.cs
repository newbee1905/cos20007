namespace Library;

public abstract class LibraryResource {
	private string _name;
	protected string _creator;
	private bool _onLoan;

	public LibraryResource(string name, string creator) {
		_name = name;
		_creator = creator;
		_onLoan = false;
	}

	public string Name => _name;
	public bool OnLoan { get => _onLoan; set => _onLoan= value; }
}
