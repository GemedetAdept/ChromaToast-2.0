namespace ChromaToast {

	public class Convert {
		/* Conversion equations referenced from:
		 * Ford, A. & Roberts, A. (1998) Color Space Conversions
		 * Travis, D. (1991) Effective Color Displays: Theory and Practice
		 *		(Computers and People). Academic Press. DOI 10.1016/0003-6870(92)90258-W
		 * HSL and HSV. (2025, October 09). In Wikipedia.
		 *		(https://en.wikipedia.org/w/index.php?title=HSL_and_HSV&oldid=1315916974)
		 * The Python Standard Library, colorsys.py
		*/
		static Convert() { }

		public class RGB {
			static RGB() { }

			// (Ford & Roberts, 1998, pg. 15) & (Travis, 1991, pg. 211)
			public static Chroma.HSV ToHSV(Chroma.RGB input) {
				float red = input.Red;
				float green = input.Green;
				float blue = input.Blue;

				float max = Math.Max(red, Math.Max(green, blue));
				float min = Math.Min(red, Math.Min(green, blue));

				float chroma = (max-min);
				float saturation = chroma/(float)max;
				float value = max;

				float redPrime = (max-red)/chroma;
				float greenPrime = (max-green)/chroma;
				float bluePrime = (max-blue)/chroma;

				float huePrime;
				if (chroma == 0) { huePrime = 0; }
				else if (red == max && green == min) { huePrime = 5+bluePrime; }
				else if (red == max && green != min) { huePrime = 1-greenPrime; }
				else if (green == max && blue == min) { huePrime = redPrime+1; }
				else if (green == max && blue != min) { huePrime = 3-bluePrime; }
				else if (red == max) { huePrime = 3+greenPrime; }
				else { huePrime = 5-redPrime; }

				float hue = (huePrime * 60)/360;

				Chroma.HSV output = new Chroma.HSV(hue, saturation, value);
				return output;
			}

			// ("HSV and HSL," 2025) & (Travis, 1991, pg. 211)
			public static Chroma.HSL ToHSL(Chroma.RGB input) {
				float red = input.Red;
				float green = input.Green;
				float blue = input.Blue;

				float max = Math.Max(red, Math.Max(green, blue));
				float min = Math.Min(red, Math.Min(green, blue));

				float chroma = (max-min);
				float lightness = (max+min)/2;

				float redPrime = (max-red)/chroma;
				float greenPrime = (max-green)/chroma;
				float bluePrime = (max-blue)/chroma;

				float huePrime;
				if (chroma==0) { huePrime=0; }
				else if (red==max&&green==min) { huePrime=5+bluePrime; }
				else if (red==max&&green!=min) { huePrime=1-greenPrime; }
				else if (green==max&&blue==min) { huePrime=redPrime+1; }
				else if (green==max&&blue!=min) { huePrime=3-bluePrime; }
				else if (red==max) { huePrime=3+greenPrime; }
				else { huePrime=5-redPrime; }

				float hue = (huePrime*60)/360;

				float saturation;
				if (lightness == 0 || lightness == 1) { saturation = 0; }
				else { saturation = (max-lightness)/Math.Min(lightness, 1-lightness); }

				Chroma.HSL output = new Chroma.HSL(hue, saturation, lightness);
				return output;
			}

			public static Chroma.HEX ToHEX(Chroma.RGB input) {
				int red = (int)Math.Ceiling(input.Red*255);
				int green = (int)Math.Ceiling(input.Green*255);
				int blue = (int)Math.Ceiling(input.Blue*255);

				string[] components = new string[3];
				components[0] = red.ToString("X");
				components[1] = green.ToString("X");
				components[2] = blue.ToString("X");

				string output = String.Join("", components);
				Chroma.HEX outputPrime = new Chroma.HEX(output);

				return outputPrime;
			}
		}

		public class HSV {
			static HSV() { }

			// ("HSV and HSL," 2025) & (Travis, 1991, pg. 211)
			public static Chroma.RGB ToRGB(Chroma.HSV input) {
					
			}
		}

		public class HSL {
			static HSL() { }
		}

		public class HEX {
			static HEX() { }
		}
	}
}