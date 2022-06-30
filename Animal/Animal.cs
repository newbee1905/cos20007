namespace Animal;

public abstract class Animal
{
	private string _name;
	private string _color;
	private int _old;

	public Animal(string name, string color, int old)
	{
		_name = name;
		_color = color;
		_old = old;
	}

	public string Name { get => _name; set => _name = value; }
	public string Color { get => _color; set => _color = value; }
	public string Old
	{
		get => $"{_old}";
		set
		{
			if (Int32.TryParse(value, out int _old)) { }
			else Console.Error.Write("Please give old an integer value!");
		}
	}

	public abstract string GetSound();
	public void makeSound() => Console.WriteLine($"{_name} says {this.GetSound()}");
}
