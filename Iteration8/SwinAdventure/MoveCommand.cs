namespace SwinAdventure;

public class MoveCommand : Command
{
	public MoveCommand(string[] ids) : base(ids) { }
	public MoveCommand() : this(new string[] { "move" , "go", "head", "leave" }) { }

	public override string Execute(Player p, string[] text)
	{
		if (text.Length != 2)
			return "I don't know how to move like that";

		short commandType = text[0] switch
		{
			"move" or "go" or "head" => 0,
			"leave" => 1,
			_ => -1
		};
		if (commandType == -1)
			return "Error in move input";

		if (!Direction.TryParse(text[1], out Direction direction))
			return "I don't know where to move";
		direction = (Direction)(((short)direction + commandType * 2) % 4);
		Location? moveTo = FetchLocation(p, direction);

		if (moveTo is null)
			return "The path is blocked";
		p.CurLocation = moveTo;
		return $"Player moved {direction.ToString()}";
	}

	private Location? FetchLocation(Player p, Direction direction)
		=> (p.CurLocation?.Paths.Fetch(direction.ToString()) as Path)?.To;
		// => p.CurLocation.Paths[direction.ToString()].To;
}
