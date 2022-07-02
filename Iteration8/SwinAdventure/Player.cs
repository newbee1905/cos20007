namespace SwinAdventure;

public class Player : GameObject, IHaveInventory
{
	private Inventory _inventory;
	private Location? _curLocation;

	private static readonly string[] DefaultIndents = { "me", "inventory" };
	public Player(string name, string desc) : base(DefaultIndents, name, desc)
		=> _inventory = new Inventory();

	public GameObject? Locate(string id)
	{
		if (AreYou(id))
			return this;
		if (_curLocation == null)
			return _inventory.Fetch(id);
		var item = _curLocation.Locate(id);
		if (item == null)
			return _inventory.Fetch(id);
		return item;
	}

	public override string FullDescription
		=> $"You are {Name} {Description}\nYou are carrying:{_inventory.ItemList}";
	public Inventory Inventory => _inventory;
	public Location? CurLocation { get => _curLocation; set => _curLocation = value; }
}
