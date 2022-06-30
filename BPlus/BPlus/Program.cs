using System.Text.RegularExpressions;

namespace BPlus;

public class Program {
	private static Regex numberPattern = new Regex(@"[0-9]",
		RegexOptions.Compiled);

	public Program() {
		Operators.Add(new Operator("+", 2));
		Operators.Add(new Operator("-", 2));
		Operators.Add(new Operator("*", 3));
		Operators.Add(new Operator("/", 3));
		Operators.Add(new Operator("^", 4, Associativities.Right));
		Operators.Add(new Operator("%", 4));
	}

	/// <summary>
	/// Tokenize the specified expression.
	/// </summary>
	/// <param name="expression">The expression to tokenize.</param>
	public void Tokenize(string expression) {
		// place to accumulate digits
		string number = "";

		// loop through char
		foreach (char c in expression) {
			string _s = c.ToString();
			if (Operators.IsOperator(ref _s)
					|| c == '('
					|| c == ')') {

				if (number != "") {

				} else if (c == ' ') {
				} else if (numberPattern.Matches(_s).Count > 0) {
				} else {

				}
			}

			// check if ther is a left over last token
			if (number != "") {}
		}
	}

	public static void Main(string[] args) {
		var program = new Program();
	}
}
