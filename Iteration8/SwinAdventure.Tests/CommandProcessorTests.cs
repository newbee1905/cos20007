namespace SwinAdventure.Tests;

public class CommandProcessorTests
{
	MoveCommand? _move;
	LookCommand? _look;
	MoveCommand? _test;
	CommandProcessor? cmdProcessor;

	[SetUp]
	public void Setup()
	{
		_move = new();
		_look = new();
		_test = new(new string[] { "test" });
		cmdProcessor = new();
		cmdProcessor?.AddCommand(_move);
		cmdProcessor?.AddCommand(_look);
	}

	[Test]
	public void TestGetCommandMoveInCommandProcessor()
		=> Assert.AreEqual(cmdProcessor?.GetCommand("move"), _move);
	
	[Test]
	public void TestGetLookMoveInCommandProcessor()
		=> Assert.AreEqual(cmdProcessor?.GetCommand("look"), _look);

	[Test]
	public void TestGetNoCommandInCommandProcessor()
		=> Assert.AreEqual(cmdProcessor?.GetCommand("test"), null);

	[Test]
	public void TestAddCommandToCommandProcessor()
	{
		cmdProcessor?.AddCommand(_test);
		Assert.AreEqual(cmdProcessor?.GetCommand("test"), _test);
	}
}
