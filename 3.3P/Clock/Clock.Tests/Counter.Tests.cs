using NUnit.Framework;

namespace Clock.Tests {
	public class CounterTests {
		private Counter _counter;

		[SetUp]
		public void Setup() => _counter = new Counter("TestCounter");

		[Test]
		public void TestInitialisedCounterIsZero() => Assert.AreEqual(0, _counter.Ticks);

		[Test]
		public void TestIncrementCounter() {
			int newTicks = _counter.Ticks + 1;
			_counter.Increment();
			Assert.AreEqual(newTicks, _counter.Ticks);
		}

		[Test]
		public void TestMultipleIncrement() {
			int newTicks = _counter.Ticks + 3;
			for (int i = 0; i++ < 3; _counter.Increment()) ;
			Assert.AreEqual(newTicks, _counter.Ticks);
		}

		[Test]
		public void TestCounterReset() {
			_counter.Reset();
			Assert.AreEqual(0, _counter.Ticks);
		}
	}
}
