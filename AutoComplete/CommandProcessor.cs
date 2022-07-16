using System.Text;
using System.Globalization;

namespace AutoComplete;

public class CommandProcessor {
	private Command? _defaultCommand;
	private Dictionary<string, Command> _commands;
	private static string _emptyLine = new string(' ', Console.WindowWidth);

	public CommandProcessor(Command? defaultCommand = null) {
		_defaultCommand = defaultCommand;
		_commands = new();
	}

	public void AddCommand(Command cmd) {
		_commands[cmd.Name] = cmd;
	}

	public void SetDefaultCommand(string cmdName)
		=> _defaultCommand = _commands[cmdName];

	public void Parse(string[]? cmds = null) {
		if (cmds is null || cmds.Length == 0) {
			_defaultCommand?.Execute("");
			return;
		}
	}

	public void InterectiveParse(string[]? cmds = null) {
		StringBuilder builder = new();
		string input = "";
		List<Command> matchCmds = new();
		ConsoleKeyInfo rawInput;
		while (true) {
			rawInput = Console.ReadKey(intercept: true);
			switch (rawInput.Key) {
				case ConsoleKey.Enter:
					this.Parse(input.Split(' '));
					return;

				case ConsoleKey.Tab:
					matchCmds = _commands.
						Where(cmdInfo 
							=> cmdInfo.Value.Name != input
							&& cmdInfo.Value.Name.StartsWith(input, true, CultureInfo.InvariantCulture)
						).
						Select(cmdInfo => cmdInfo.Value).
						ToList();
					if (matchCmds.Count == 0)
						continue;
					goto default;

				default:
					ClearCurrentLine();
					builder.Clear();
					Console.Write(matchCmds[0]);
					builder.Append(matchCmds[0]);
					break;
			}
			input = builder.ToString();
		}
	}

	private static void ClearCurrentLine() {
		int currentLine = Console.CursorTop;
		Console.SetCursorPosition(0, currentLine);
		Console.Write(_emptyLine);
		Console.SetCursorPosition(0, currentLine);
	}
}
