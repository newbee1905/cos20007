using System;
using SplashKitSDK;

namespace ShapeDrawer
{
	public class Shape
	{
		private Color _color;
		private double _x, _y;
		private int _width, _height;

		public Shape()
		{
			_x = 0;
			_y = 0;
			_height = 100;
			_width = 100;
			_color = Color.Green;
		}

		public Color Color { get => _color; set => _color = value; }
		public double X { get => _x; set => _x = value; }
		public double Y { get => _y; set => _y = value; }
		public int Width { get => _width; set => _width = value; }
		public int Height { get => _height; set => _height = value; }

		public void Draw() => SplashKit.FillRectangle(_color, _x, _y, _width, _height);

		public bool IsAt(Point2D pt) =>
			(
				(
					(pt.X >= Math.Min(_x, _x + _width)) && (pt.X <= Math.Max(_x, _x + _width))
				)
				&& (
					(pt.Y >= Math.Min(_y, _y + _height)) && (pt.Y <= Math.Max(_y, _y + _height))
				)
			);
	}
}
