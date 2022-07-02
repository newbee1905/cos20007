namespace SwinAdventure;

public class Location : GameObject, IHaveInventory
{
	private Inventory _items;
	private Dictionary<string, Path> _paths;

	public Location(string[] ids, string name, string desc) : base(ids, name, desc)
	{
		_items = new Inventory();
		_paths = new Dictionary<string, Path>();
		_paths.Add("north", new Path(new string[] { "north" }, $"north:{name}", $"North of {name}"));
		_paths.Add("south", new Path(new string[] { "south" }, $"south:{name}", $"South of {name}"));
		_paths.Add("east", new Path(new string[] { "east" }, $"east:{name}", $"East of {name}"));
		_paths.Add("west", new Path(new string[] { "west" }, $"west:{name}", $"West of {name}"));
	}

	public GameObject? Locate(string id) => AreYou(id) ? this : _items.Fetch(id);

	public Inventory Items => _items;
	public Dictionary<string, Path> Paths => _paths;

	public void UpdatePath(string direction, Location to)
		=> _paths[direction].To = to;
	public void RemovePath(string direction)
		=> _paths[direction].To = null;
}
