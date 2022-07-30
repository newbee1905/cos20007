pub struct Counter {
	count: i32,
	pub name: String,
}

impl Counter {
	pub fn new(name: &str) -> Self {
		Self { count: 0, name: name.into() }
	}

	pub fn inc(&mut self) {
		self.count += 1;
	}

	pub fn dec(&mut self) {
		self.count -= 1;
	}

	pub fn reset(&mut self) {
		self.count = 0;
	}

	pub fn get_count(&self) -> i32 { self.count }
}
