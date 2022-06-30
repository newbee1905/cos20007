using System;

namespace Clock
{
	public class Clock
	{
		private Counter _hour;
		private Counter _minute;
		private Counter _second;

		public Clock()
		{
			_hour = new Counter("Hour");
			_minute = new Counter("Minute");
			_second = new Counter("Second");
		}

		public int Hour => _hour.Ticks % 24;
		public int Minute => _minute.Ticks % 60;
		public int Second => _second.Ticks % 60;

		public void Tick()
		{
			_second.Increment();
			if (Second == 0)
			{
				_minute.Increment();
				if (Minute == 0)
					_hour.Increment();
			}
		}

		public void Reset()
		{
			_hour.Reset();
			_minute.Reset();
			_second.Reset();
		}

		public string Time => $"{Hour:00}:{Minute:00}:{Second:00}";
	}
}
