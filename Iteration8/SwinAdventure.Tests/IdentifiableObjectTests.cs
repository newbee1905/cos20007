namespace SwinAdventure.Tests;

[TestFixture]
public class IdentifiableObjectTests
{
	private IdentifiableObject? id;

	[SetUp]
	public void Init() => id = new IdentifiableObject(new string[] { "id1", "id2" });

	[TestCase("id1")]
	[TestCase("id2")]
	public void TestAreYou(string val) => Assert.IsTrue(id?.AreYou(val));


	[TestCase("id12343")]
	[TestCase("hehe")]
	public void TestNotAreYou(string val) => Assert.IsFalse(id?.AreYou(val));

	[TestCase("ID1")]
	[TestCase("iD1")]
	public void TestAreYouCaseSentitive(string val) => Assert.IsTrue(id?.AreYou(val));

	[Test]
	public void TestFirstID() => Assert.AreEqual(id?.FirstId, "id1");

	[Test]
	public void TestAddID()
	{
		id?.AddIdentifier("id3");
		Assert.IsTrue(id?.AreYou("id3"));
	}

}
