namespace CounterObject
{
	public class Counter
	{
		private int _count = 0;
		private string _name;

		public Counter(string name) => _name = name;

		public string Name { get => _name; set => _name = value; }
		public int Ticks => _count;

		public void Increment() => ++_count;
		public void Decrement() => --_count;
		public void Reset() => _count = 0;
	}
}
