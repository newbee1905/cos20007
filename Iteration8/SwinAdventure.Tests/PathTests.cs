namespace SwinAdventure.Tests;

public class PathTests 
{
	private Location? _l1;
	private Location? _l2;
	private Location? _l3;

	[SetUp]
	public void Setup()
	{
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
	}

	[Test]
	public void TestLocationToLocation()
	{
		if (_l2 is null) return;
		_l1?.UpdatePath("down", _l2);
		Assert.AreEqual((_l1?.Paths.Fetch("down") as Path)?.To, _l2);
	}

	[Test]
	public void TestLocationNotToLocation()
	{
		if (_l2 is null) return;
		_l1?.UpdatePath("down", _l2);
		Assert.AreNotEqual((_l1?.Paths.Fetch("down") as Path)?.To, _l3);
	}

	[Test]
	public void TestRemovePath()
	{
		if (_l2 is null) return;
		_l1?.UpdatePath("down", _l2);
		_l1?.RemovePath("down");
		Assert.AreEqual((_l1?.Paths.Fetch("down") as Path)?.To, null);
	}
}
