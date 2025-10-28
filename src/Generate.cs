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
					float value = (float)(values[i]/255.0);
					
					valuesRGB[i] = value;
				}

				float red = valuesRGB[0];
				float green = valuesRGB[1];
				float blue = valuesRGB[2];

				Chroma.RGB output = new Chroma.RGB(red, green, blue);
				return output;
			}	
		}
	}
}
