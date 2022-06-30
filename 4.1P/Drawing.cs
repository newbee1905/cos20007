namespace DrawingProgram;

public class Drawing
{
	private List<Shape> _shapes;
	private Color _background;

	public Drawing(Color background)
	{
		_shapes = new List<Shape>();
		_background = background;
	}

	public Drawing() : this(Color.White) { }

	public List<Shape> SelectedShapes => _shapes.Where(s => s.Selected).ToList<Shape>();
	public int ShapeCount => _shapes.Count;
	public Color Background { get => _background; set => _background = value; }

	public void Draw(uint fps = 60)
	{
		SplashKit.ClearScreen(_background);
		foreach (Shape shape in _shapes)
			shape.Draw();
		SplashKit.RefreshScreen(fps);
	}

	public void SelectShapesAt(Point2D pt)
		=> _shapes = _shapes.Select(s =>
		{
			s.Selected = s.IsAt(pt);
			return s;
		}).ToList<Shape>();

	public void AddShape(Shape s) => _shapes.Add(s);
	public void RemoveShape(Shape s) => _shapes.Remove(s);

	public void RemoveSelectedShapes() =>
		_shapes = _shapes.Where(s => !s.Selected).ToList<Shape>();
}
