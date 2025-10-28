namespace ChromaToast {
	public class Generate {
		
		public class Random {
			public static Chroma.RGB RGB() {
				int[] values = new int[3];

				System.Random random = new System.Random();
				for (int i = 0; i < values.Length; i++) {
					int value = random.Next(0, 256);

					values[i] = value;
				}

				float[] valuesRGB = new float[3];
				for (int i = 0;i < valuesRGB.Length; i++) {
					float value = (float)(values[i]/255.0f);
					
					valuesRGB[i] = value;
				}

				float red = valuesRGB[0];
				float green = valuesRGB[1];
				float blue = valuesRGB[2];

				Chroma.RGB output = new Chroma.RGB(red, green, blue);
				return output;
			}

			public static Chroma.HSV HSV() {
				System.Random random = new System.Random();

				int hue = random.Next(0, 361);
				int saturation = random.Next(0, 101);
				int value = random.Next(0, 101);

				float huePrime = (float)(hue/360.0f);
				float saturationPrime = (float)(saturation/100.0f);
				float valuePrime = (float)(value/100.0f);

				Chroma.HSV output = new Chroma.HSV(huePrime, saturationPrime, valuePrime);
				return output;
			}

			public static Chroma.HSL HSL() {
				System.Random random = new System.Random();
				
				int hue = random.Next(0, 361);
				int saturation = random.Next(0, 101);
				int lightness = random.Next(0, 101);

				float huePrime = (float)(hue/360.0f);
				float saturationPrime = (float)(saturation/100.0f);
				float lightnessPrime = (float)(lightness/100.0f);

				Chroma.HSL output = new Chroma.HSL(huePrime, saturationPrime, lightnessPrime);
				return output;
			}
		}
	}
}
