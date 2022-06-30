using System.Text.RegularExpressions;
using NUnit.Framework;

namespace Clock.Tests
{
	public class ClockTests
	{
		private Clock _clock;

		[SetUp]
		public void Setup() => _clock = new Clock();

		[Test]
		public void TestInitialise() => Assert.AreEqual("00:00:00", _clock.Time);

		[Test]
		public void TestIncrementSecond()
		{
			_clock.Tick();
			Assert.AreEqual("00:00:01", _clock.Time);
		}

		[Test]
		public void TestIncrementMinute()
		{
			for (int i = 0; i++ < 60; _clock.Tick()) ;
			Assert.AreEqual("00:01:00", _clock.Time);
		}

		[Test]
		public void TestIncrementHour()
		{
			for (int i = 0; i++ < 3600; _clock.Tick()) ;
			Assert.AreEqual("01:00:00", _clock.Time);
		}

		[TestCase(86399, "23:59:59")]
		[TestCase(86401, "00:00:01")]
		[TestCase(172801, "00:00:01")]
		public void TestTickIncrementOutOfHoursLoops(int tick, string res)
		{
			for (int i = 0; i++ < tick; _clock.Tick()) ;
			Assert.AreEqual(res, _clock.Time);
		}

		[Test]
		public void TestClockReset()
		{
			_clock.Tick();
			_clock.Reset();
			Assert.AreEqual("00:00:00", _clock.Time);
		}

		[Test]
		public void TestTimeReturnsString() => Assert.IsInstanceOf<string>(_clock.Time);

		[Test]
		public void TestTimeStringFormatCorrect()
		{
			Regex regex = new Regex("^(2[0-3]|[01]?[0-9]):([0-5]?[0-9]):([0-5]?[0-9])$");
			Assert.True(regex.IsMatch(_clock.Time));
		}
	}
}
