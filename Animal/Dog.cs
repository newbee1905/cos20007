namespace Animal;

public class Dog : Animal
{
	public Dog(string name, string color, int old) : base(name, color, old) {}

	public override string GetSound() => "Woof";
}
