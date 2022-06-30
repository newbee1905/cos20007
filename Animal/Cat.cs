namespace Animal;

public class Cat : Animal
{
	public Cat(string name, string color, int old) : base(name, color, old) {}

	public override string GetSound() => "Meow";
}
