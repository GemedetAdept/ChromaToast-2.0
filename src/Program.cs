String input = "convert rgb 50 50 50";
string[] inputSplit = Parse.SplitCommand(input);

foreach (string word in inputSplit) {
	Console.WriteLine(word);
}