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
	}
}
