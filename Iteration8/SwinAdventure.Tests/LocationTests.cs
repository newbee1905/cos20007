using System;

namespace SwinAdventure.Tests;

public class LocationTests
{
	private Player? _player;
	private Location? _location;
	private Location? _tempLocation;
	private Item? _weapon;
	private Item? _armour;
	private Item? _food;

	[SetUp]
	public void Setup()
	{
		_player = new Player("Kodokuna Hachi", "Dying man");

		string[] identsLocation = { "Start" };
		_location = new Location(identsLocation, "Start", "0.0");

		string[] tempIdentsLocation = { "End" };
		_tempLocation = new Location(identsLocation, "End", "1.1");

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

		_location.Items.Put(_weapon);
		_location.Items.Put(_armour);
		_location.Items.Put(_food);
	}

	[Test]
	public void TestLocationIsIdentifiable()
		=> Assert.True(_location?.AreYou("Start"));

	[Test]
	public void TestLocationLocatesItems()
	{
		Assert.AreSame(_weapon, _location?.Locate("weapon"));
		Assert.AreSame(_armour, _location?.Locate("Armour"));
		Assert.AreSame(_food, _location?.Locate("fOOd"));
	}

	[Test]
	public void TestLocationLocatesItself()
		=> Assert.AreSame(_location, _location?.Locate("Start"));

	[Test]
	public void TestLocationLocatesNothing()
		=> Assert.AreEqual(null, _location?.Locate("End"));

	[Test]
	public void TestLocationFullDescription()
		=> Assert.AreEqual(@"0.0
	a Rusted Sword (weapon)
	a Demon Armour (armour)
	a Pho (food)",
	_location?.FullDescription);

	[Test]
	public void TestLocationName()
		=> Assert.AreEqual("Start", _location?.Name);

	[Test]
	public void TestPlayerCanLocateInLocation()
	{
		if (_player is null) return;
		_player.CurLocation = _location;
		Assert.AreSame(_weapon, _player?.Locate("weapon"));
		Assert.AreSame(_armour, _player?.Locate("Armour"));
		Assert.AreSame(_food, _player?.Locate("fOOd"));
	}

	[Test]
	public void TestPlayerCannotLocateInWrongLocation()
	{
		if (_player is null) return;
		_player.CurLocation = _tempLocation;
		Assert.AreSame(null, _player?.Locate("weapon"));
		Assert.AreSame(null, _player?.Locate("Armour"));
		Assert.AreSame(null, _player?.Locate("fOOd"));
	}
}
