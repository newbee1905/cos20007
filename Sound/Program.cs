using System;
using SplashKitSDK;

public class Program
{
	public static void Main()
	{
		SplashKit.LoadSoundEffect("hello_there", @"test.mp3");
		var helloThere = SplashKit.SoundEffectNamed("hello_there");
		helloThere.Play();
		Console.ReadKey();
	}
}
