namespace BPlus;

public enum Associativities { Left, Right };

public class Operator {
	private string _representation;
	private byte _priority;
	private Associativities _associativity;

	public Operator(string representation, byte priority, Associativities associativity) {
		_representation = representation;
		_priority = priority;
		_associativity = associativity;
	}

	public Operator(string representation, byte priority) 
		: this(representation, priority, Associativities.Left) {}

	public string Representation => _representation;
	public byte Priority => _priority;
	public Associativities Associativity => _associativity;
}

public class Operators {
	private static List<Operator> _operators = new List<Operator>();

	public static Boolean IsOperator(ref string s) {
		foreach (Operator op in _operators)
			if (s.Equals(op.Representation))
				return true;
		return false;
	}

	public static void Add(Operator op)
		=> _operators.Add(op);
}
