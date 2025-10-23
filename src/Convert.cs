namespace ChromaToast.Convert {
	public class Convert {
		internal Convert() {}

		public class RGB {
			public int Red {get; set;}
			public int Green {get; set;}
			public int Blue {get; set;}

			public static RGB(int red, int green, int blue) {
				Red = red;
				Green = green;
				Blue = blue;
			}
		}
	}
}