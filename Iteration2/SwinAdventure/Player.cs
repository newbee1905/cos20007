namespace SwinAdventure;

public class Player : GameObject
{
	private Inventory _inventory;

	private static readonly string[] DefaultIndents = { "me", "inventory" };
	public Player(string name, string desc) : base(DefaultIndents, name, desc)
	{
		_inventory = new Inventory();
	}

	public GameObject? Locate(string id) => AreYou(id) ? this : _inventory.Fetch(id);

	public override string FullDescription
		=> $"You are {Name} {Description}\nYou are carrying:{_inventory.ItemList}";
	public Inventory Inventory => _inventory;
}
