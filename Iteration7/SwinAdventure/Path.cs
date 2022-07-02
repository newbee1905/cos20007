namespace SwinAdventure;

public class Path : Item
{
	private Location? _to = null;

	public Path(string[] ids, string name, string desc) : base(ids, name, desc)
	{}

	public Location? To { get => _to; set => _to = value; }
}
