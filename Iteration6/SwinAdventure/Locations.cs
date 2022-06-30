namespace SwinAdventure;

public class Location : GameObject, IHaveInventory
{
	private Inventory _items;

	public Location(string[] ids, string name, string desc) : base(ids, name, desc)
		=> _items = new Inventory();

	public GameObject? Locate(string id) => AreYou(id) ? this : _items.Fetch(id);

	public Inventory Items => _items;
}
