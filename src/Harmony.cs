using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChromaToast {
	public class Harmony {
		public class Hue {
			
			public static Card[] Complementary(Card card0) {
				Chroma.HSV hsv0 = card0.HSV;
				float hue0 = hsv0.Hue;
				float saturation0 = hsv0.Saturation;
				float value0 = hsv0.Value;

				Card card1 = new Card();

				float[] harmonyAngles = new float[] { (float)(180/360.0f) };

				float hue1 = Math.Abs((hue0 + harmonyAngles[0]) - 1.0f);
				float saturation1 = saturation0;
				float value1 = value0;

				Chroma.HSV hsv1 = new Chroma.HSV(hue1, saturation1, value1);
				card1.InputChroma(hsv1);

				Card[] output = new Card[] { card0, card1 };
				return output;
			}

			public static Card[] SplitComplementary(Card card0) {
				Chroma.HSV hsv0 = card0.HSV;
				float hue0 = hsv0.Hue;
				float saturation0 = hsv0.Saturation;
				float value0 = hsv0.Value;

				Card card1 = new Card();
				Card card2 = new Card();

				float[] harmonyAngles = new float[] {
					(float)(150/360.0f), (float)(210/360.0f)
				};

				Card[] output = new Card[3];
				for (int i = 0; i < output.Length; i++) {
					if (i == 0) { continue; }
					else {
						float hue = Math.Abs((hue0 + harmonyAngles[i-1]) - 1.0f);
						float saturation = saturation0;
						float value = value0;

						Chroma.HSV hsv = new Chroma.HSV(hue, saturation, value);
						output[i] = new Card();
						output[i].InputChroma(hsv);
					}
				}

				output[0] = card0;
				return output;
			}
		}

		public static Card Offset(Card input, int offset) {
			Chroma.HSV inputHSV = input.HSV;
			float inputHue = inputHSV.Hue;
			float inputSaturation = inputHSV.Saturation;
			float inputValue = inputHSV.Value;

			int inputHuePrime = (int)inputHue * 360;
			int outputHue = Math.Abs((inputHuePrime + offset) - 360);
			float outputHuePrime = (float)outputHue/360.0f;

			Card output = new Card();
			Chroma.HSV outputHSV = new Chroma.HSV(outputHuePrime, inputSaturation, inputValue);
			output.InputChroma(outputHSV);

			return output;
		}
	}
}
