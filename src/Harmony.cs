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

				Card card1 = new Card();
				card1.CloneFromCard(card0);

				card1.HSV.Hue = Math.Abs((hue0 + 0.5f) - 1.0f);

				card1.InputChroma(card1.HSV);

				Card[] output = new Card[] { card0, card1 };
				return output;
			}
		}
	}
}
