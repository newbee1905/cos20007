using System;

namespace DrawingProgram;

public class Rectangle : Shape
{
	private int _width, _height;

	public Rectangle(Color color, float x, float y, int width, int height) : base(color, x, y)
	{
		_width = width;
		_height = height;
	}

	public Rectangle(float x, float y) : this(Color.AliceBlue, x, y, 100, 100) { }
	public Rectangle() : this(Color.AliceBlue, 0, 0, 100, 100) { }

	public int Width { get => _width; set => _width = value; }
	public int Height { get => _height; set => _height = value; }

	public override void Draw()
	{
		if (this.Selected)
			DrawOutline();
		SplashKit.FillRectangle(this.Color, this.X, this.Y, _width, _height);
	}
	public override void DrawOutline() => SplashKit.FillRectangle(Color.Black, this.X - 2, this.Y - 2, _width + 4, _height + 4);

	public override bool IsAt(Point2D pt) =>
		(
			(pt.X >= X && pt.X <= X + _width)
			&& (pt.Y >= Y && pt.Y <= Y + _height)
		);
}
