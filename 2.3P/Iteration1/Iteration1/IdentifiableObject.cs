namespace Iteration1;

public class IdentifiableObject
{
	private List<string> _identifiers;

	public IdentifiableObject(string[] idents)
	{
		_identifiers = new List<string>();
		foreach (string s in idents)
		{
			AddIdentifier(s.ToLower());
		}
	}

	public bool AreYou(string id)
	{
		foreach (string s in _identifiers)
			if (id.ToLower() == s)
				return true;
		return false;
	}

	public void AddIdentifier(string id) => _identifiers.Add(id.ToLower());

	// read-only
	public string FirstId => (_identifiers.Count == 0 ? "" : _identifiers[0]);
}
