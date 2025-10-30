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

				float hue1 = Math.Abs((hue0 + 0.5f) - 1.0f);
				float saturation1 = saturation0;
				float value1 = value0;

				Chroma.HSV hsv1 = new Chroma.HSV(hue1, saturation1, value1);

				card1.InputChroma(hsv1);

				Card[] output = new Card[] { card0, card1 };
				return output;
			}
		}
	}
}
