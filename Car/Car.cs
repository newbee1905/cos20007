namespace Car;

public abstract class Car
{
	private string _brand, _color;

	public Car(string brand, string color)
	{
		_brand = brand;
		_color = color;
	}

	public string Brand => _brand;
	public string Color { get => _color; set => _color = value; }
	public override string ToString() => $"This {_brand} has {_color} color";
}
