namespace SwinAdventure;

public class IdentifiableObject
{
	private List<string> _identifiers;

	public IdentifiableObject(string[] idents)
	{
		_identifiers = new List<string>();
		foreach (string s in idents)
			AddIdentifier(s);
	}

	public bool AreYou(string id) => 
		_identifiers.Any(_id => _id.Equals(id, StringComparison.OrdinalIgnoreCase));

	public void AddIdentifier(string id) => _identifiers.Add(id);

	// read-only
	public string FirstId => (_identifiers.Count == 0 ? "" : _identifiers[0]);
}
