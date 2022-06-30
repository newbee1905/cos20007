using System;
namespace SwinAdventure.Tests;

[TestFixture]
public class LookCommandTests
{

	// set to nullable variables since 
	// Setup function is not recognise as constructor
	// => warnings about nullable variables
	private Player? _player;
	private Item? _gem;
	private Bag? _bag;
	private LookCommand? _look;

	[SetUp]
	public void Setup()
	{
		_look = new LookCommand(new string[] { "look" });
		_player = new Player("Kodokuna Hachi", "Dying man");
		string[] gemIds = { "gem" };
		_gem = new Item(gemIds, "Gem", "Gem Ruby");
		string[] bagIds = { "bag", "Kodo's Bag", "Skill Issues" };
		_bag = new Bag(bagIds, "Kodo's bag", "Dying bag");
	}

	[Test]
	public void TestLookAtMe()
	{
		Assert.AreEqual(_look?.Execute(_player, new string[] { "look", "at", "inventory" }), _player?.FullDescription);
	}

	[Test]
	public void TestLookAtGem()
	{
		_player?.Inventory.Put(_gem);
		Assert.AreEqual(_look?.Execute(_player, new string[] { "look", "at", "gem" }), _gem?.FullDescription);
	}

	[Test]
	public void TestLookAtUnk()
	{
		Assert.AreEqual(_look?.Execute(_player, new string[] { "look", "at", "gem" }), "I can't find the gem");
	}

	[Test]
	public void TestLookAtGemInMe()
	{
		_player?.Inventory.Put(_gem);
		Assert.AreEqual(_look?.Execute(_player, new string[] { "look", "at", "gem", "in", "me" }), _gem?.FullDescription);
	}

	[Test]
	public void TestLookAtGemInBag()
	{
		_bag?.Inventory.Put(_gem);
		_player?.Inventory.Put(_bag);
		Assert.AreEqual(_look?.Execute(_player, new string[] { "look", "at", "gem", "in", "bag" }), _gem?.FullDescription);
	}

	[Test]
	public void TestLookAtGemInNoBag()
	{
		_bag?.Inventory.Put(_gem);
		Assert.AreEqual(_look?.Execute(_player, new string[] { "look", "at", "gem", "in", "bag" }), "I can't find the bag");
	}

	[Test]
	public void TestLookAtNoGemInBag()
	{
		_player?.Inventory.Put(_bag);
		Assert.AreEqual(_look?.Execute(_player, new string[] { "look", "at", "gem", "in", "bag" }), "I can't find the gem in the bag");
	}

	[TestCase(0)]
	[TestCase(1)]
	[TestCase(2)]
	public void TestInvalidLook(int errorCase)
	{
		switch (errorCase)
		{
			case 0:
				Assert.AreEqual(_look?.Execute(_player, new string[] { "look", "around" }), "I don't know how to look like that");
				break;
			case 1:
				Assert.AreEqual(_look?.Execute(_player, new string[] { "look", "for", "gem"}), "What do you want me to look at?");
				break;
			case 3:
				Assert.AreEqual(_look?.Execute(_player, new string[] { "look", "at", "gem", "from", "bag"}), "What do you want me to look in?");
				break;
			default:
				break;
		}
	}
}
