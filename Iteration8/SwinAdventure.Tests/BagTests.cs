namespace SwinAdventure.Tests;

[TestFixture]
public class BagTests
{
	private Bag? _bag;
	private Item? _weapon;
	private Item? _armour;
	private Item? _food;

	[SetUp]
	public void Setup()
	{
		string[] bagIds = { "bb", "Kodo's Bag", "Skill Issues" };
		_bag = new Bag(bagIds, "Kodo's bag", "Dying bag");

		string[] weaponIdents = { "weapon", "sword", "rusted" };
		_weapon = new Item(weaponIdents,
			"Rusted Sword",
			"Sword that has been rusted through decade of not washing of the blood"
		);

		string[] armourIdents = { "armour", "black", "iron" };
		_armour = new Item(armourIdents,
			"Demon Armour",
			"Darkest Black Amour"
		);

		string[] foodIdents = { "food", "noddles", "Pho" };
		_food = new Item(foodIdents,
			"Pho",
			"Pho - Vietnam"
		);

		_bag.Inventory.Put(_weapon);
		_bag.Inventory.Put(_armour);
		_bag.Inventory.Put(_food);
	}

	[Test]
	public void TestBagLocatesItems()
	{
		Assert.AreSame(_weapon, _bag?.Locate("Weapon"));
		Assert.AreSame(_armour, _bag?.Locate("Armour"));
		Assert.AreSame(_food, _bag?.Locate("Food"));
	}

	[Test]
	public void TestBagLocatesItself()
		=> Assert.AreSame(_bag, _bag?.Locate("kOdO's BaG"));

	[Test]
	public void TestBagLocatesNothing()
		=> Assert.AreEqual(null, _bag?.Locate("not-me-lmao"));


	[Test]
	public void TestBagFullDescription()
		=> Assert.That
		(
			_bag?.FullDescription,
			Is.EqualTo(@"In the Kodo's bag you can see:
	a Rusted Sword (weapon)
	a Demon Armour (armour)
	a Pho (food)").NoClip);

	[Test]
	public void TestBagInBag()
	{
		string[] bag2Ids = { "bb2", "Kodo's Bag2"};
		Bag bag2 = new Bag(bag2Ids, "Kodo's bag2", "Dying bag2");

		string[] weapon2Idents = { "weapon2", "sword2", "shiny" };
		Item weapon2 = new Item(weapon2Idents,
			"Shiny Sword",
			"Super Shiny Sword that you can't unsee"
		);

		_bag?.Inventory.Put(bag2);
		Assert.AreSame(_bag?.Locate("bb2"), bag2);
		Assert.AreSame(_weapon, _bag?.Locate("Weapon"));
		Assert.AreSame(_armour, _bag?.Locate("Armour"));
		Assert.AreSame(_food, _bag?.Locate("Food"));
		Assert.True(_bag?.Locate("sHiNy") is null);
	}
}
