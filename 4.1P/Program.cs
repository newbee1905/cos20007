using System;

namespace DrawingProgram;

public class Program
{
	private enum ShapeKind
	{
		Rectangle,
		Circle,
		Line
	}

	private int width, height;
	private string title;
	private Shape shape;
	private ShapeKind kindToAdd;
	private Drawing drawing;

	public Program()
	{
		height = 600;
		width = 800;
		title = "Drawing Program";
		shape = new Circle();
		kindToAdd = ShapeKind.Circle;
		drawing = new Drawing(Color.DarkSlateBlue);
	}

	public static void Main()
	{
		Program _ = new Program();
		new Window(_.title, _.width, _.height);

		SplashKit.RegisterCallbackOnKeyTyped(delegate (int code)
		{
			_.kindToAdd = code switch
			{
				(int)KeyCode.RKey => ShapeKind.Rectangle,
				(int)KeyCode.CKey => ShapeKind.Circle,
				(int)KeyCode.LKey => ShapeKind.Line,
				_ => _.kindToAdd
			};
		});

		do
		{
			SplashKit.ProcessEvents();
			// Already Clear from _.drawing.Draw()
			// SplashKit.ClearScreen();

			if (SplashKit.KeyTyped(KeyCode.QKey) || SplashKit.KeyTyped(KeyCode.EscapeKey))
				break;

			if (SplashKit.MouseClicked(MouseButton.LeftButton))
			{
				float curPosX = SplashKit.MouseX();
				float curPosY = SplashKit.MouseY();
				_.shape = _.kindToAdd switch
				{
					ShapeKind.Rectangle => new Rectangle(curPosX, curPosY),
					ShapeKind.Circle => new Circle(curPosX, curPosY),
					ShapeKind.Line => new Line(curPosX, curPosY),
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
