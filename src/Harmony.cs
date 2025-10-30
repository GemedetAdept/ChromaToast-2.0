using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChromaToast {
	public class Harmony {
		public class Hue {
			
			public static Card[] Complementary(Card card0) {

				Card card1 = Harmony.Offset(card0, 180);

				Card[] output = new Card[] { card0, card1 };

				return output;
			}

			public static Card[] SplitComplementary(Card card0) {
				
				int[] offsets = new int[] { 150, 210 };

				Card card1 = Harmony.Offset(card0, offsets[0]);
				Card card2 = Harmony.Offset(card0, offsets[1]);

				Card[] output = new Card[] { card0, card1, card2 };

				return output;
			}

			public static Card[] Analogous(Card card0) {
				
				int[] offsets = new int[] { 30, 330 };

				Card card1 = Harmony.Offset(card0, offsets[0]);
				Card card2 = Harmony.Offset(card0, offsets[1]);

				Card[] output = new Card[] { card0, card1, card2 };

				return output;
			}
		}

		public static Card Offset(Card input, int offset) {
			Chroma.HSV inputHSV = input.HSV;
			float inputHue = inputHSV.Hue;
			float inputSaturation = inputHSV.Saturation;
			float inputValue = inputHSV.Value;

			int inputHuePrime = (int)(inputHue * 360);
			int outputHue = Math.Abs((inputHuePrime + offset) - 360);

			float outputHuePrime = (float)(outputHue/360.0f);

			Card output = new Card();
			Chroma.HSV outputHSV = new Chroma.HSV(outputHuePrime, inputSaturation, inputValue);
			output.InputChroma(outputHSV);

			return output;
		}
	}
}
