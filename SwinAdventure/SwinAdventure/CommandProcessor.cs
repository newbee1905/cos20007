namespace SwinAdventure;

public class CommandProcessor
{
	Dictionary<string, Command> _commands;

	public CommandProcessor()
		=> _commands = new();

	public void AddCommand(string[] cmdsStart, Command cmd)
	{
		foreach (var cmdStart in cmdsStart)
			_commands.Add(cmdStart, cmd);
	}

	public Command? GetCommand(string cmdStart)
		=> _commands[cmdStart];
}
