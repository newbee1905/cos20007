using System;

namespace Clock {
	public class Counter {
		private int _count;

		public Counter(string name) => Name = name;

		public string Name { get; set; }
		public int Ticks { get => _count; set => _count = value; }

		public void Increment() => ++_count;
		public void Decrement() => --_count;
		public void Reset() => _count = 0;
	}
}
