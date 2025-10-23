public class Parse {
	public string Command {get; set;}
	public string[] InputSplit {get; set;}

	Parse(string command) {
		Command = command;

		InputSplit = SplitCommand(Command);
	}

	public string[] SplitCommand(string input) {
		string[] inputSplit = input.Split(" ");

		return inputSplit;
	}
}