namespace Box;

public class Program
{
	public static void Main(string[] args)
	{
		Box box1 = new Box(100, 200, 300);
		Box box2 = new Box(150, 240, 320);
		Console.WriteLine(box1 + box2);
	}
}

