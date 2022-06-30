namespace SwinAdventure.Tests;

[TestFixture]
public class InventoryTests
{
	private Inventory? _inventory;
	private Item? _weapon;
	private Item? _armour;
	private Item? _food;

	[SetUp]
	public void Setup()
	{
		_inventory = new Inventory();

		string[] weaponIdents = { "Weapon", "sword", "rusted" };
		_weapon = new Item(weaponIdents,
			"Rusted Sword",
			"Sword that has been rusted through decade of not washing of the blood"
		);

		string[] armourIdents = { "Armour", "black", "iron" };
		_armour = new Item(armourIdents,
			"Demon Armour",
			"Darkest Black Amour"
		);

		string[] foodIdents = { "Food", "noddles", "Pho" };
		_food = new Item(foodIdents,
			"Pho",
			"Pho - Vietnam"
		);

		_inventory?.Put(_weapon);
		_inventory?.Put(_armour);
		_inventory?.Put(_food);
	}

	[TestCase("rusted")]
	[TestCase("sword")]
	[TestCase("pHo")]
	public void TestFindItem(string id) => Assert.True(_inventory?.HasItem(id));

	[TestCase("shiny")]
	[TestCase("blade")]
	[TestCase("bUn")]
	public void TestNoItemFind(string id) => Assert.False(_inventory?.HasItem(id));

	[Test]
	public void TestFetchItem() 
	{
		Assert.AreSame(_inventory?.Fetch("rusted"), _weapon);
		Assert.True(_inventory?.HasItem("rusted"));
		Assert.AreSame(_inventory?.Fetch("black"), _armour);
		Assert.True(_inventory?.HasItem("black"));
		Assert.AreSame(_inventory?.Fetch("noddles"), _food);
		Assert.True(_inventory?.HasItem("noddles"));
	}

	[Test]
	public void TestTakeItem() 
	{
		Assert.AreSame(_inventory?.Take("rusted"), _weapon);
		Assert.False(_inventory?.HasItem("rusted"));
		Assert.AreSame(_inventory?.Take("black"), _armour);
		Assert.False(_inventory?.HasItem("black"));
		Assert.AreSame(_inventory?.Take("noddles"), _food);
		Assert.False(_inventory?.HasItem("noddles"));
	}

	[Test]
	public void TestItemList()
	{
		Assert.That(_inventory?.ItemList,
Is.EqualTo(@"
	a Rusted Sword (Weapon)
	a Demon Armour (Armour)
	a Pho (Food)").NoClip
		);
	}
}
