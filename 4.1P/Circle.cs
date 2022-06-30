namespace DrawingProgram;

public class Circle : Shape
{
	private double _radius;

	public Circle(Color color, float x, float y, double radius) : base(color, x, y) 
		=> _radius = radius;
	public Circle(float x, float y) : this(Color.LightBlue, x, y, 50) {}
	public Circle() : this(0, 0) { }

	public double Radius { get => _radius; set => _radius = value; }

	public override void Draw()
	{
		if (this.Selected)
			DrawOutline();
		SplashKit.FillCircle(this.Color, this.X, this.Y, _radius);
	}
	public override void DrawOutline() => SplashKit.FillCircle(Color.Black, this.X, this.Y, _radius + 2);
	public override bool IsAt(Point2D pt) => ((pt.X - this.X) * (pt.X - this.X) + (pt.Y - this.Y) * (pt.Y - this.Y)) <= (_radius * _radius);
}
