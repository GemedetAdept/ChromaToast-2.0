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
				Console.WriteLine(hue0);

				Card card1 = new Card();

				float hue1 = Math.Abs((hue0 + 0.5f) - 1.0f);
				Console.WriteLine(hue1);
				Chroma.HSV hsv1 = card1.HSV;
				hsv1.Hue = hue1;

				card1.InputChroma(hsv1);

				Card[] output = new Card[] { card0, card1 };
				return output;
			}
		}
	}
}
