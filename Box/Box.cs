namespace Box;

public class Box
{
	private int _length, _width, _height;

	public Box(int length, int width, int height)
	{
		_length = length;
		_width = width;
		_height = height;
	}

	public int Length { get => _length; set => _length = value; }
	public int Width { get => _width; set => _width = value; }
	public int Height { get => _height; set => _height = value; }

	public static Box operator +(Box A, Box B) =>
		new Box(A.Length + B.Length, A.Width + B.Width, A.Height + B.Height);

	public override string ToString() => 
		$"Box:\n\tlength: {_length}\n\twidth: {_width}\n\theight: {_height}";
}
