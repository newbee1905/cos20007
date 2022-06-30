namespace DrawingProgram;

public abstract class Shape
{
	private Color _color;
	private double _x, _y;
	private bool _selected;

	public Shape(Color color, double x, double y)
	{
		_color = color;
		_x = x;
		_y = y;
		_selected = false;
	}
	public Shape(Color color) : this(color, 0, 0) { }
	public Shape() : this(Color.Gray, 0, 0) { }

	public Color Color { get => _color; set => _color = value; }
	public double X { get => _x; set => _x = value; }
	public double Y { get => _y; set => _y = value; }
	public bool Selected { get => _selected; set => _selected = value; }

	public abstract void Draw();
	public abstract void DrawOutline();
	public abstract bool IsAt(Point2D pt);
}
