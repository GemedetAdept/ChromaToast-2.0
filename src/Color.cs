namespace ChromaToast.Color {

	public class Color {
		public Color() {}

		public class RGB {
			public float Red {get; set;}
			public float Green {get; set;}
			public float Blue {get; set;}

			public RGB(float red, float green, float blue) {
				Red = red;
				Green = green;
				Blue = blue;
			}
		}

		public class HSV {
			public float Hue {get; set;}
			public float Saturation {get; set;}
			public float ValueHSV {get; set;}

			public HSV(float hue, float saturation, float valueHSV) {
				Hue = hue;
				Saturation = saturation;
				ValueHSV = valueHSV;
			}
		}
	}
}