namespace ChromaToast.Color {

	public class Color {
		public Color() {}

		internal float ClampValue(float floor, float input, float ceiling) {
			float clampedValue = 0.0;

			if (input < floor) { clampedValue = floor; }
			if (input > ceiling) { clampedValue = ceiling; }
			else { clampedValue = input; }

			return clampedValue;
		}

		public class RGB {
			public float Red {get; set;}
			public float Green {get; set;}
			public float Blue {get; set;}

			public RGB(float red, float green, float blue) {
				Red = ClampValue(0.0, red, 1.0);
				Green = ClampValue(0.0, green, 1.0);
				Blue = ClampValue(0.0, blue, 1.0);
			}
		}

		public class HSV {
			public float Hue {get; set;}
			public float Saturation {get; set;}
			public float ValueHSV {get; set;}

			public HSV(float hue, float saturation, float valueHSV) {
				Hue = ClampValue(0.0, hue, 1.0);
				Saturation = ClampValue(0.0, saturation, 1.0);
				ValueHSV = ClampValue(0.0, valueHSV, 1.0);
			}
		}

		public class HSL {
			public float Hue {get; set;}
			public float Saturation {get; set;}
			public float Lightness {get; set;}

			public HSL(float hue, float saturation, float lightness) {
				Hue = ClampValue(0.0, hue, 1.0);
				Saturation = ClampValue(0.0, saturation, 1.0);
				Lightness = ClampValue(0.0, lightness, 1.0);
			}
		}

		public class HEX {
			public int IntHEX {get; set;}
			public string StringHEX {get; set;}

			public HEX(string stringHEX) {
				StringHEX = stringHEX;
				// convert StringHEX into IntHEX
			}
		}
	}
}