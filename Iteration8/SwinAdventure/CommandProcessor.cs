namespace SwinAdventure;

public class CommandProcessor
{
	// Dictionary<string, Command> _commands;
	private List<Command> _commands;

	public CommandProcessor()
		=> _commands = new();

	public void AddCommand(Command cmd)
		=> _commands.Add(cmd);

	public Command? GetCommand(string cmdId)
	{
		foreach (var cmd in _commands)
			if (cmd.AreYou(cmdId))
				return cmd;
		return null;
	}
}
