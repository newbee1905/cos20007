namespace SwinAdventure;

public class Bag : Item
{
	private Inventory _inventory;

	public Bag(string[] ids, string name, string desc) : base(ids, name, desc)
	{
		_inventory = new Inventory();
	}

	public GameObject? Locate(string id) => AreYou(id) ? this : _inventory.Fetch(id);

	public override string FullDescription
		=> $"In the {Name} you can see:{_inventory.ItemList}";
	public Inventory Inventory => _inventory;
}
