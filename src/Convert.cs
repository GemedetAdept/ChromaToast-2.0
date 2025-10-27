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
				float hue = input.Hue;
				float huePrime = (hue*360)/60;
				float saturation = input.Saturation;
				float value = input.Value;

				int primaryColor = (int)Math.Floor(huePrime);
				float secondaryColor = huePrime - primaryColor;

				float partA = (1-saturation)*input.Value;
				float partB = (1-(saturation * secondaryColor))*value;
				float partC = (1-(saturation * (1-secondaryColor)))*value;

				float redPrime = 0.0f;
				float greenPrime = 0.0f;
				float bluePrime = 0.0f;

				if (primaryColor==0) { redPrime=value; greenPrime=partC; bluePrime=partA; }
				else if (primaryColor==1) { redPrime=partB; greenPrime=value; bluePrime=partA; }
				else if (primaryColor==2) { redPrime=partA; greenPrime=value; bluePrime=partC; }
				else if (primaryColor==3) { redPrime=partA; greenPrime=partB; bluePrime=value; }
				else if (primaryColor==4) { redPrime=partC; greenPrime=partA; bluePrime=value; }
				else if (primaryColor==5) { redPrime=value; greenPrime=partA; bluePrime=partB; }

				Chroma.RGB output = new Chroma.RGB(redPrime, greenPrime, bluePrime);
				return output;
			}

			// ("HSV and HSL," 2025)
			public static Chroma.HSL ToHSL(Chroma.HSV input) {
				float hue = input.Hue;
				float saturation = input.Saturation;
				float value = input.Value;

				float huePrime = hue;
				float lightness = value*(1-(saturation/2));

				float saturationPrime = 0.0f;
				if (lightness==0 || lightness==1) { saturationPrime = 0; }
				else { saturationPrime = (value-lightness)/(Math.Min(lightness, 1-lightness)); }

				Chroma.HSL output = new Chroma.HSL(huePrime, saturationPrime, lightness);
				return output;
			}

			public static Chroma.HEX ToHEX(Chroma.HSV input) {
				Chroma.RGB step = ToRGB(input);

				Chroma.HEX output = Convert.RGB.ToHEX(step);

				return output;
			}
		}

		public class HSL {
			static HSL() { }

			// ("HSV and HSL," 2025)
			public static Chroma.RGB ToRGB(Chroma.HSL input) {
				float hue = input.Hue;
				float huePrime = (hue*360)/60;
				float saturation = input.Saturation;
				float lightness = input.Lightness;

				float chroma = (1 - Math.Abs((2*lightness)-1))*saturation;
				float median = chroma*(1 - Math.Abs((huePrime % 2)-1));

				float redPrime = 0.0f;
				float greenPrime = 0.0f;
				float bluePrime = 0.0f;

				if (0 <= huePrime && huePrime < 1) { redPrime=chroma; greenPrime=median; bluePrime=0; }
				else if (1 <= huePrime && huePrime < 2) { redPrime=median; greenPrime=chroma; bluePrime=0; }
				else if (2 <= huePrime && huePrime < 3) { redPrime=0; greenPrime=chroma; bluePrime=median; }
				else if (3 <= huePrime && huePrime < 4) { redPrime=0; greenPrime=median; bluePrime=chroma; }
				else if (4 <= huePrime && huePrime < 5) { redPrime=median; greenPrime=0; bluePrime=chroma; }
				else if (5 <= huePrime && huePrime < 6) { redPrime=chroma; greenPrime=0; bluePrime=median; }

				float mid = lightness - (chroma/2);
				float red = redPrime + mid;
				float green = greenPrime + mid;
				float blue = bluePrime +mid;

				Chroma.RGB output = new Chroma.RGB(red, green, blue);
				return output;
			}

			public static Chroma.HSV ToHSV(Chroma.HSL input) {
				float hue = input.Hue;
				float saturation = input.Saturation;
				float lightness = input.Lightness;

				float huePrime = hue;
				float value = lightness + saturation*Math.Min(lightness, 1-lightness);

				float saturationPrime = 0.0f;
				if (value==0) { saturationPrime = 0; }
				else { saturationPrime = 2 * (1-(lightness/value)); }

				Chroma.HSV output = new Chroma.HSV(huePrime, saturationPrime, value);
				return output;
			}

			public static Chroma.HEX ToHEX(Chroma.HSL input) {
				Chroma.RGB step = HSL.ToRGB(input);

				Chroma.HEX output = RGB.ToHEX(step);

				return output;
			}
		}

		public class HEX {
			static HEX() { }

			public static Chroma.RGB ToRGB(Chroma.HEX input) {
				string hexString = input.HexString;
				char[] charArray = hexString.ToCharArray();
				string[] splitHex = new string[3];

				int splitIter = 0;
				for (int i = 0; i < charArray.Length; i+=2) {
					char[] chars = { charArray[i], charArray[i+1] };
					string part = new string(chars);

					splitHex[splitIter] = part;
					splitIter++;
				}

				float[] colorValues = new float[3];
				for (int i = 0; i < splitHex.Length; i++) {
					int step = System.Convert.ToInt32(splitHex[i], 16);

					float part = step/255.0f;

					colorValues[i] = part;
				}

				float red = colorValues[0];
				float green = colorValues[1];
				float blue = colorValues[2];

				Chroma.RGB output = new Chroma.RGB(red, green, blue);
				return output;
			}
		}
	}
}