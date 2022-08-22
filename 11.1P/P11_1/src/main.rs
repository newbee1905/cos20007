mod clock;
mod counter;

use crate::clock::Clock;

fn main() {
	let mut clock = Clock::new();

	for _ in 0..(86400 + 48265) {
		clock.tick();
		println!("{}", clock.time());
	}
}
