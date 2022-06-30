namespace SwinAdventure;

public abstract class GameObject : IdentifiableObject
{
	private string _name, _description;

	public GameObject(string[] ids, string name, string desc) : base(ids)
	{
		_name = name;
		_description = desc;
	}

	public string Name => _name;
	public string ShortDescription => $"a {_name} ({this.FirstId})";
	public string Description => _description;
	public virtual string FullDescription => _description;
}
