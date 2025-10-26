namespace ChromaToast.Chroma {

	public class Convert {
		/* Conversion equations referenced from:
		 * Ford, A. and Roberts, A. (1998) Color Space Conversions
		 * Travis, D. (1991) Effective Color Displays: Theory and Practice
		 *		(Computers and People). Academic Press. DOI 10.1016/0003-6870(92)90258-W
		 * Wikipedia - HSV and HSL
		 *		(https://web.archive.org/web/20251012000154/https://en.wikipedia.org/wiki/HSL_and_HSV)
		 * The Python Standard Library, colorsys.py
		*/
		static Convert() { }

		public class RGB {
			static RGB() { }

			public Chroma.HSV ToHSV(Chroma.RGB input) {
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

				float hue = huePrime * 60.0f;

				Chroma.HSV output = new Chroma.HSV(hue, saturation, value);
				return output;
			}
		}

		public class HSV {
			static HSV() { }
		}

		public class HSL {
			static HSL() { }
		}

		public class HEX {
			static HEX() { }
		}
	}
}