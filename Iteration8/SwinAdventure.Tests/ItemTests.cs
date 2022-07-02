namespace SwinAdventure.Tests;

[TestFixture]
public class ItemTests
{
	[SetUp]
	public void Setup()
	{
	}

	[TestCase(new string[] { "test1" }, "", "", "test1")]
	[TestCase(new string[] { "test", "second_test_id" }, "", "", "second_test_id")]
	[TestCase(new string[] { "test1", "test2", "test3", "test4", "test5", "very_deep_id" }, "", "", "very_deep_id")]
	public void TestItemIsIdentifiable(string[] idents, string name, string desc, string testId)
	{
		Item testItem = new Item(idents, name, desc);
		Assert.True(testItem.AreYou(testId));
	}

	[TestCase(new string[] { "test1" }, "short", "long")]
	[TestCase(new string[] { "test", "second_test_id" }, "S", "T")]
	public void TestItemShortDescription(string[] idents, string name, string desc)
	{
		Item testItem = new Item(idents, name, desc);
		Assert.AreEqual(testItem.ShortDescription, $"a {name} ({idents[0]})");
	}

	[TestCase(new string[] { "test1" }, "short", "long")]
	[TestCase(new string[] { "test", "second_test_id" }, "S", "T")]
	public void TestItemFullDescription(string[] idents, string name, string desc)
	{
		Item testItem = new Item(idents, name, desc);
		Assert.AreEqual(testItem.FullDescription, desc);

	}
}
