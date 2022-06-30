using System;
using SplashKitSDK;

namespace ShapeDrawer;

public class Program
{
	private int width, height;
	private string title;
	private Shape shape;

	public Program()
	{
		height = 600;
		width = 800;
		title = "Shape Drawer";
		shape = new Shape();
	}

	public static void Main()
	{
		Program _ = new Program();
		new Window(_.title, _.width, _.height);
		do
		{
			SplashKit.ProcessEvents();
			SplashKit.ClearScreen();

			if (SplashKit.KeyDown(KeyCode.QKey))
				break;

			if (SplashKit.MouseClicked(MouseButton.LeftButton))
			{
				_.shape.X = SplashKit.MouseX();
				_.shape.Y = SplashKit.MouseY();
			}

			if (SplashKit.MouseDown(MouseButton.RightButton))
			{
				Point2D end = SplashKit.MousePosition();
				_.shape.Width = (int)(end.X - _.shape.X);
				_.shape.Height = (int)(end.Y - _.shape.Y);
			}


			if (SplashKit.KeyTyped(KeyCode.SpaceKey))
			{
				if (_.shape.IsAt(SplashKit.MousePosition()))
				{
					_.shape.Color = SplashKit.RandomRGBColor(255);
				}
			}

			_.shape.Draw();
			SplashKit.RefreshScreen(24);
		} while (!SplashKit.WindowCloseRequested("Shape Drawer"));

		Console.WriteLine("Closing Shape Drawer...");
	}
}
