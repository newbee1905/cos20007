namespace SwinAdventure;

public class Item : GameObject
{
	public Item(string[] idents, string name, string desc) : base(idents, name, desc) { }

	public bool Equals(Item itm) => this.AreYou(itm.FirstId);
}
