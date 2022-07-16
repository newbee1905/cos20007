namespace AutoComplete;

public abstract class Command {
	private string _name, _desc;
	private string[] _args;


	public Command(string cmd, string desc, string[]? defaultArgs = null) {
		_name = cmd;
		_desc = desc;
		_args = defaultArgs ?? new string[] { };
	}

	public string Name => _name;
	public string Description => _desc;

	/// <summary>
	/// Limit to only get one string per command 
	/// to simply the process
	/// </summary>
	/// <param name="inp">The only input the command takes</param>
	public abstract void Execute(string inp);
}
