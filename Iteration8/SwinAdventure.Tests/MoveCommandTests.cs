namespace SwinAdventure.Tests;

[TestFixture]
public class MoveCommandTests 
{
	// set to nullable variables since 
	// Setup function is not recognise as constructor
	// => warnings about nullable variables
	private Player? _player;
	private MoveCommand? _move;
	private Location? _l1;
	private Location? _l2;
	private Location? _l3;
	private Location? _l4;
	private Location? _l5;

	[SetUp]
	public void Setup()
	{
		_move = new MoveCommand();
		_player = new Player("Kodokuna Hachi", "Dying man");

		_l1 = new(
			new string[] { "first", "land" },
			"first",
			"First Land"
		);
		
		_l2 = new(
			new string[] { "second", "land" },
			"second",
			"Second Land"
		);
		
		_l3 = new(
			new string[] { "third", "land" },
			"third",
			"Third Land"
		);
		
		_l4 = new(
			new string[] { "fourth", "land" },
			"fourth",
			"Fourth Land"
		);
		
		_l5 = new(
			new string[] { "fith", "land" },
			"fifth",
			"Fifth Land"
		);

		_l1.UpdatePath("down", _l2);
		_l1.UpdatePath("east", _l3);
		_l2.UpdatePath("up", _l1);
		_l2.UpdatePath("right", _l4);
		_l3.UpdatePath("down", _l4);
		_l3.UpdatePath("left", _l1);
		_l4.UpdatePath("up", _l3);
		_l4.UpdatePath("right", _l5);

		_player.CurLocation = _l1;
	}

	[Test]
	public void TestMove()
	{
		if (_player is null) return;
		_move?.Execute(_player, new string[] { "move", "south", });
		Assert.AreEqual(_player.CurLocation, _l2);
	}

	[Test]
	public void TestInACircle()
	{
		if (_player is null) return;
		_move?.Execute(_player, new string[] { "move", "south", });
		_move?.Execute(_player, new string[] { "move", "east", });
		_move?.Execute(_player, new string[] { "move", "north", });
		_move?.Execute(_player, new string[] { "move", "west", });
		Assert.AreEqual(_player.CurLocation, _l1);
	}

	[Test]
	public void TestLeave()
	{
		if (_player is null) return;
		_move?.Execute(_player, new string[] { "leave", "north", });
		Assert.AreEqual(_player.CurLocation, _l2);
	}
}
