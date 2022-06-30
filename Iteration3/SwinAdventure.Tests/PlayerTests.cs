namespace SwinAdventure.Tests;

[TestFixture]
public class PlayerTests
{
	// set to nullable variables since 
	// Setup function is not recognise as constructor
	// => warnings about nullable variables
	private Player? _player;
	private Item? _weapon;
	private Item? _armour;
	private Item? _food;

	[SetUp]
	public void Setup()
	{
		_player = new Player("Kodokuna Hachi", "Dying man");

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

		_player.Inventory.Put(_weapon);
		_player.Inventory.Put(_armour);
		_player.Inventory.Put(_food);
	}

	// No test cases like item test
	// Since player require more variables
	[Test]
	public void TestPlayerIsIdentifiable()
	{
		Assert.True(_player?.AreYou("me"));
		Assert.True(_player?.AreYou("inventory"));
	}

	[Test]
	public void TestPlayerLocatesItems()
	{
		Assert.AreSame(_weapon, _player?.Locate("Weapon"));
		Assert.AreSame(_armour, _player?.Locate("Armour"));
		Assert.AreSame(_food, _player?.Locate("Food"));
	}

	[Test]
	public void TestPlayerLocatesItself()
		=> Assert.AreSame(_player, _player?.Locate("me"));

	[Test]
	public void TestPlayerLocatesNothing()
		=> Assert.AreEqual(null, _player?.Locate("not-me-lmao"));

	[Test]
	public void TestPlayerFullDescription()
		=> Assert.That
		(
			_player?.FullDescription,
			Is.EqualTo(@"You are Kodokuna Hachi Dying man
You are carrying:
	a Rusted Sword (weapon)
	a Demon Armour (armour)
	a Pho (food)").NoClip
		);

	[Test]
	public void TestPlayerName() => Assert.AreEqual("Kodokuna Hachi", _player?.Name);
}
