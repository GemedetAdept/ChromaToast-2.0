namespace ChromaToast {
	
	public class CLI {
		static CLI() { }

		public class Display() {

			// PrintNormalized (decimal/unit values)
			public static void PrintNormalized(Card input) {
				PrintNormalized(input.RGB);
				PrintNormalized(input.HSV);
				PrintNormalized(input.HSL);
				PrintNormalized(input.HEX);
			}

			public static void PrintNormalized(Chroma.RGB input) {
				float red = input.Red;
				float green = input.Green;
				float blue = input.Blue;

				string label = "Chroma.RGB (Normalized)";
				string redPrime = red.ToString("F3");
				string greenPrime = green.ToString("F3");
				string bluePrime = blue.ToString("F3");

				Console.WriteLine("{0} : {1}, {2}, {3}", label, redPrime, greenPrime, bluePrime);
			}

			public static void PrintNormalized(Chroma.HSV input) {
				float hue = input.Hue;
				float saturation = input.Saturation;
				float value = input.Value;

				string label = "Chroma.HSV (Normalized)";
				string huePrime = hue.ToString("F3");
				string saturationPrime = saturation.ToString("F3");
				string valuePrime = value.ToString("F3");

				Console.WriteLine("{0} : {1}, {2}, {3}", label, huePrime, saturationPrime, valuePrime);
			}

			public static void PrintNormalized(Chroma.HSL input) {
				float hue = input.Hue;
				float saturation = input.Saturation;
				float lightness = input.Lightness;

				string label = "Chroma.HSV (Normalized)";
				string huePrime = hue.ToString("F3");
				string saturationPrime = saturation.ToString("F3");
				string lightnessPrime = lightness.ToString("F3");

				Console.WriteLine("{0} : {1}, {2}, {3}", label, huePrime, saturationPrime, lightnessPrime);
			}

			public static void PrintNormalized(Chroma.HEX input) {
				int[] integers = input.Integers;

				string label = "Chroma.HEX (Normalized)";

				Console.WriteLine("{0} : {1} {2} {3} {4} {5} {6}", label,
					integers[0], integers[1], integers[2], integers[3], integers[4], integers[5]);
			}

			// PrintDisplay (conventional values for color spaces i.e., 255 for RGB instead of 1.0)
			public static void PrintDisplay(Card input) {
				PrintDisplay(input.RGB);
				PrintDisplay(input.HSV);
				PrintDisplay(input.HSL);
				PrintDisplay(input.HEX);
			}

			public static void PrintDisplay(Chroma.RGB input) {
				int red = (int)Math.Ceiling(input.Red*255);
				int green = (int)Math.Ceiling(input.Green*255);
				int blue = (int)Math.Ceiling(input.Blue*255);

				string label = "Chroma.RGB (Display)";

				Console.WriteLine("{0} : {1}, {2}, {3}", label, red, green, blue);
			}

			public static void PrintDisplay(Chroma.HSV input) {
				int hue = (int)Math.Ceiling(input.Hue*360);
				int saturation = (int)Math.Floor(input.Saturation*100);
				int value = (int)Math.Floor(input.Value*100);

				string label = "Chroma.HSV (Display)";

				Console.WriteLine("{0} : {1}°, {2}%, {3}%", label, hue, saturation, value);
			}

			public static void PrintDisplay(Chroma.HSL input) {
				int hue = (int)Math.Ceiling(input.Hue*360);
				int saturation = (int)Math.Floor(input.Saturation*100);
				int lightness = (int)Math.Floor(input.Lightness*100);

				string label = "Chroma.HSL (Display)";

				Console.WriteLine("{0} : {1}°, {2}%, {3}%", label, hue, saturation, lightness);
			}

			public static void PrintDisplay(Chroma.HEX input) {
				string value = input.Value;

				string label = "Chroma.HEX (Display)";

				Console.WriteLine("{0} : #{1}", label, value);
			}
		}
	}
}
