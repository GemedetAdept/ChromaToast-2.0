namespace ChromaToast.Exceptions {
	public class LargestIndexMismatchException : Exception {
		public LargestIndexMismatchException() : base("Largest index is larger than target array length.") { }
	}
}