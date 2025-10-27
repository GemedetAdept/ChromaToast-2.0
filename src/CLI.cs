namespace ChromaToast {
	
	public class CLI {
		static CLI() { }

		public class Display() {
			static Display() { }

			public static void PrintNormalized(Chroma.RGB input) {
				float red = input.Red;
				float green = input.Green;
				float blue = input.Blue;

				string label = "Chroma.RGB (Normalized)";
				string redPrime = red.ToString("F3");
				string greenPrime = green.ToString("F3");
				string bluePrime = blue.ToString("F3");

				Console.WriteLine("\n{0} : {1}, {2}, {3}", label, redPrime, greenPrime, bluePrime);
			}

			public static void PrintNormalized(Chroma.HSV input) {
				float hue = input.Hue;
				float saturation = input.Saturation;
				float value = input.Value;

				string label = "Chroma.HSV (Normalized)";
				string huePrime = hue.ToString("F3");
				string saturationPrime = saturation.ToString("F3");
				string valuePrime = value.ToString("F3");

				Console.WriteLine("\n{0} : {1}, {2}, {3}", label, huePrime, saturationPrime, valuePrime);
			}
		}
	}
}
