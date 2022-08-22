use crate::counter::Counter;

pub struct Clock {
	hour: Counter,
	minute: Counter,
	second: Counter,
}

impl Clock {
	pub fn new() -> Self {
		Self {
			hour: Counter::new("Hour"),
			minute: Counter::new("Minute"),
			second: Counter::new("Second"),
		}
	}

	pub fn tick(&mut self) {
		self.second.inc();
		if self.get_second() == 0 {
			self.minute.inc();
			if self.get_minute() == 0 {
				self.hour.inc();
			}
		}
	}

	pub fn reset(&mut self) {
		self.hour.reset();
		self.minute.reset();
		self.second.reset();
	}

	pub fn get_hour(&self) -> i32 { self.hour.get_count() % 24 }
	pub fn get_minute(&self) -> i32 { self.minute.get_count() % 60 }
	pub fn get_second(&self) -> i32 { self.second.get_count() % 60 }
	pub fn get_ticks(&self) -> i32 { self.second.get_count() }

	pub fn time(&self) -> String {
		format!(
			"{:02}:{:02}:{:02}",
			self.get_hour(),
			self.get_minute(),
			self.get_second(),
		)
	}
}
