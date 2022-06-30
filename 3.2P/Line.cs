using System;

namespace DrawingProgram;

public class Line : Shape
{
	private Point2D _start, _end;
	private Quad _outlineQuad;

	public Line(Color color, double startX, double startY, double endX, double endY) : base(color, startX, startY)
	{
		this.Color = color;
		_start = SplashKit.PointAt(startX, startY);
		_end = SplashKit.PointAt(endX, endY);
		_outlineQuad = SplashKit.QuadFrom(
			SplashKit.PointAt(startX + 1, startY + 1),
			SplashKit.PointAt(startX - 1, startY - 1),
			SplashKit.PointAt(endX + 1, endY + 1),
			SplashKit.PointAt(endX - 1, endY - 1)
		);
	}

	// line width 100 - default
	public Line() : this(Color.Lime, 0, 0, 100, 0) { }


	public override void Draw()
	{
		if (this.Selected)
			DrawOutline();
		SplashKit.DrawLine(this.Color, _start, _end);
	}
	public override void DrawOutline() => SplashKit.FillQuad(Color.Black, _outlineQuad);

	public override bool IsAt(Point2D pt) =>
		(
			(
			 (SplashKit.PointPointDistance(pt, _start) * SplashKit.PointPointDistance(pt, _start))
			 + (SplashKit.PointPointDistance(pt, _end) * SplashKit.PointPointDistance(pt, _end))
			)
			== (SplashKit.PointPointDistance(_start, _end) * SplashKit.PointPointDistance(_start, _end))
		);
}
