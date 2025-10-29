public class ArrayIndexMismatchException : Exception {
	public ArrayIndexMismatchException(int index1, int index2) : 
		base("Indices do not match: {0}, {1}") { }
}
