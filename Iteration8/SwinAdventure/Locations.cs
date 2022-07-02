namespace SwinAdventure;

public class Location : GameObject, IHaveInventory
{
	private Inventory _items;
	/// Using Inventory instead of Dictionory eventhough it is not as fast in
	/// fetching and updating
	/// This is for more consistency
	// private Dictionary<string, Path> _paths;
	private Inventory _paths;

	public Location(string[] ids, string name, string desc) : base(ids, name, desc)
	{
		_items = new Inventory();
		_paths = new();
		// _paths.Add("north", new Path(new string[] { "north" }, $"north:{name}", $"North of {name}"));
		// _paths.Add("south", new Path(new string[] { "south" }, $"south:{name}", $"South of {name}"));
		// _paths.Add("east", new Path(new string[] { "east" }, $"east:{name}", $"East of {name}"));
		// _paths.Add("west", new Path(new string[] { "west" }, $"west:{name}", $"West of {name}"));
		_paths.Put(new Path(new string[] { "north", "up" }, $"north:{name}", $"North of {name}"));
		_paths.Put(new Path(new string[] { "south", "down" }, $"south:{name}", $"South of {name}"));
		_paths.Put(new Path(new string[] { "east", "left" }, $"east:{name}", $"East of {name}"));
		_paths.Put(new Path(new string[] { "west", "right" }, $"west:{name}", $"West of {name}"));
	}

	public GameObject? Locate(string id) => AreYou(id) ? this : _items.Fetch(id);

	public Inventory Items => _items;
	// public Dictionary<string, Path> Paths => _paths;
	public Inventory Paths => _paths;

	public void UpdatePath(string direction, Location to)
	{
		// _paths[direction].To = to;
		var path = _paths.Fetch(direction) as Path;
		if (path is not null)
			path.To = to;
	}

	public void RemovePath(string direction)
	{
		// _paths[direction].To = null;
		var path = _paths.Fetch(direction) as Path;
		if (path is not null)
			path.To = null;
	}
}
