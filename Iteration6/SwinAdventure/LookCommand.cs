namespace SwinAdventure;

public class LookCommand : Command
{
	public LookCommand(string[] ids) : base(ids) { }

	public override string Execute(Player p, string[] text)
	{
		if ((text.Length != 3 && text.Length != 5))
			return "I don't know how to look like that";

		if (text[0] != "look")
			return "Error in look input";

		if (text[1] != "at")
			return "What do you want me to look at?";

		string thingId = text[2];
		string containerId = "inventory";

		if (text.Length == 5)
		{
			if (text[3] != "in")
				return "What do you want me to look in?";
			containerId = text[4];
		}

		IHaveInventory? container = FetchContainer(p, containerId);
		if (container == null)
			return $"I can't find the {containerId}";

		string? foundItem = LookAtIn(thingId, container);
		if (foundItem == null)
			return $"I can't find the {thingId}" + (text.Length == 5 ? $" in the {containerId}" : "");

		return foundItem;
	}

	private IHaveInventory? FetchContainer(Player p, string containerId)
	{
		GameObject? container = p.Locate(containerId);
		if (container != null)
			return container as IHaveInventory;
		return null;
	}

	private string? LookAtIn(string thingId, IHaveInventory container)
	{
		GameObject? foundItem = container.Locate(thingId);
		if (foundItem != null)
			return foundItem.FullDescription;
		return null;
	}
}
