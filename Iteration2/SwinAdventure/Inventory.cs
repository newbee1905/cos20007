namespace SwinAdventure;

public class Inventory
{
	private List<Item> _items;

	public Inventory() => _items = new List<Item>();

	public string ItemList => _items.Aggregate("", (res, itm) => res + $"\n\t{itm.ShortDescription}");

	public bool HasItem(string id) => _items.Any(itm => itm.AreYou(id));
	public void Put(Item itm) => _items.Add(itm);
	public Item? Fetch(string id) => _items.Find(itm => itm.AreYou(id));
	public Item? Take(string id)
	{
		Item? item = Fetch(id);
		if (item is not null)
			_items.Remove(item);
		return item;
	}
}
