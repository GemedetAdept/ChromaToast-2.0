using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChromaToast {
	public class Card { 
		public Chroma.RGB RGB {get;set;}
		public Chroma.HSV HSV {get;set;}
		public Chroma.HSL HSL {get;set;}
		public Chroma.HEX HEX {get;set;}

		public Card() {
			RGB = new Chroma.RGB(0.0f, 0.0f, 0.0f);	
			HSV = new Chroma.HSV(0.0f, 0.0f, 0.0f);
			HSL = new Chroma.HSL(0.0f, 0.0f, 0.0f);
			HEX = new Chroma.HEX("000000");
		}

		public void InputAll(Chroma.RGB rgb, Chroma.HSV hsv, Chroma.HSL hsl, Chroma.HEX hex) {
			RGB = rgb;
			HSV = hsv;
			HSL = hsl;
			HEX = hex;
		}

		public void InputChroma(Chroma.RGB input) {
			RGB = input;
			HSV = Convert.RGB.ToHSV(input);
			HSL = Convert.RGB.ToHSL(input);
			HEX = Convert.RGB.ToHEX(input);
		}

		public void InputChroma(Chroma.HSV input) {
			RGB = Convert.HSV.ToRGB(input);
			HSV = input;
			HSL = Convert.HSV.ToHSL(input);
			HEX = Convert.HSV.ToHEX(input);
		}

		public void InputChroma(Chroma.HSL input) {
			RGB = Convert.HSL.ToRGB(input);
			HSV = Convert.HSL.ToHSV(input);
			HSL = input;
			HEX = Convert.HSL.ToHEX(input);
		}

		public void InputChroma(Chroma.HEX input) {
			RGB = Convert.HEX.ToRGB(input);
			HSV = Convert.HEX.ToHSV(input);
			HSL = Convert.HEX.ToHSL(input);
			HEX = input;
		}
	}
}
