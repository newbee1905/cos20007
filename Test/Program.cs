
namespace Test;

public class Program
{
    public enum Direction
    {
        north,
        south,
        east,
        west
    }

    public static void Main()
    {
			Direction a = Direction.north;
        Console.WriteLine(a.ToString());

    }
}

