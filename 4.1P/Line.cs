namespace DrawingProgram;

public class Line : Shape
{
	private Point2D _start, _end;

	public Line(Color color, double startX, double startY, double endX, double endY) : base(color, startX, startY)
	{
		this.Color = color;
		_start = SplashKit.PointAt(startX, startY);
		_end = SplashKit.PointAt(endX, endY);
	}

	// line width 100 - default
	public Line(double startX, double startY) : this(Color.Lime, startX, startY, startX + 100, startY) { }
	public Line() : this(Color.Lime, 0, 0, 100, 0) { }

	public double EndX { get => _end.X; set => _end.X = value; }
	public double EndY { get => _end.Y; set => _end.Y = value; }

	public override void Draw()
	{
		if (this.Selected)
			DrawOutline();
		SplashKit.DrawLine(this.Color, _start, _end);
	}
	public override void DrawOutline()
	{
		SplashKit.DrawCircle(this.Color, _start.X, _start.Y, 5);
		SplashKit.DrawCircle(this.Color, _end.X, _end.Y, 5);
	}

	public override bool IsAt(Point2D pt) =>
		SplashKit.PointOnLine(pt, SplashKit.LineFrom(_start, _end));
}
