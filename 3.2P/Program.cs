using System;

namespace DrawingProgram;

public class Program
{
	private int width, height;
	private string title;
	private Shape shape;
	private int type;
	private Drawing drawing;

	public Program()
	{
		height = 600;
		width = 800;
		title = "Drawing Program";
		shape = new Rectangle();
		drawing = new Drawing(Color.DarkSlateBlue);
	}

	public static void Main()
	{
		Program _ = new Program();
		new Window(_.title, _.width, _.height);

		SplashKit.RegisterCallbackOnKeyTyped(delegate (int code)
		{
			_.type = code switch
			{
				(int)KeyCode.RKey => 0,
				(int)KeyCode.CKey => 1,
				// Shape type = -1 -> quit
				(int)KeyCode.QKey or (int)KeyCode.EscapeKey => -1,
				// No real usage -> just for no warnings
				_ => _.type
			};
		});

		do
		{
			SplashKit.ProcessEvents();
			// Already Clear from _.drawing.Draw()
			// SplashKit.ClearScreen();

			if (_.type == -1)
				break;

			if (SplashKit.MouseClicked(MouseButton.LeftButton))
			{
				float curPosX = SplashKit.MouseX();
				float curPosY = SplashKit.MouseY();
				_.shape = _.type switch
				{
					0 => new Rectangle(curPosX, curPosY),
					1 => new Circle(curPosX, curPosY),
					// No real usage -> just for no warnings
					_ => _.shape
				};
				_.drawing.AddShape(_.shape);
			}

			if (SplashKit.MouseClicked(MouseButton.RightButton))
				_.drawing.SelectShapesAt(SplashKit.MousePosition());

			if (SplashKit.KeyTyped(KeyCode.DeleteKey) || SplashKit.KeyTyped(KeyCode.BackspaceKey))
				_.drawing.RemoveSelectedShapes();

			if (SplashKit.KeyTyped(KeyCode.SpaceKey))
				_.drawing.Background = SplashKit.RandomRGBColor(255);

			_.drawing.Draw();
			// SplashKit.RefreshScreen(60);
		} while (!SplashKit.WindowCloseRequested(_.title));

		Console.WriteLine("Closing Shape Drawer...");
	}
}
