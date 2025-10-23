namespace ChromaToast.Color {

	public class Color {
		public Color() {}

		internal static float ClampValue(float floor, float input, float ceiling) {
			float clampedValue = 0.0f;

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
				Red = ClampValue(0.0f, red, 1.0f);
				Green = ClampValue(0.0f, green, 1.0f);
				Blue = ClampValue(0.0f, blue, 1.0f);
			}
		}

		public class HSV {
			public float Hue {get; set;}
			public float Saturation {get; set;}
			public float ValueHSV {get; set;}

			public HSV(float hue, float saturation, float valueHSV) {
				Hue = ClampValue(0.0f, hue, 1.0f);
				Saturation = ClampValue(0.0f, saturation, 1.0f);
				ValueHSV = ClampValue(0.0f, valueHSV, 1.0f);
			}
		}

		public class HSL {
			public float Hue {get; set;}
			public float Saturation {get; set;}
			public float Lightness {get; set;}

			public HSL(float hue, float saturation, float lightness) {
				Hue = ClampValue(0.0f, hue, 1.0f);
				Saturation = ClampValue(0.0f, saturation, 1.0f);
				Lightness = ClampValue(0.0f, lightness, 1.0f);
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