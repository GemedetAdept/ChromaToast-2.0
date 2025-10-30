using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChromaToast {
	public class Harmony {
		public class Hue {
			
			public Card[] Complementary(Card card0) {
				Chroma.HSV hsv0 = card0.HSV;
				float hue0 = hsv0.Hue;

				Chroma.HSV hsv1 = hsv0;
				float hue1 = Math.Abs((hue0 + 0.5f) - 1.0f);
				hsv1.Hue = hue1;

				Card card1 = new Card();
				card1.InputChroma(hsv1);

				Card[] output = new Card[] { card0, card1 };
				return output;
			}
		}
	}
}
