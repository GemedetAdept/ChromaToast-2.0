using System;

namespace ChromaToast {

	public class Chroma {

		internal static float ClampValues(float floor, float input, float ceiling) {
			float clampedValue = 0.0f;

			if (input < floor) { clampedValue = floor; }
			else if (input > ceiling) { clampedValue = ceiling; }
			else { clampedValue = input; }

			return clampedValue;
		}

		internal static string ClampValues(string value) {
			string clampedHEX;
			char[] clampedCharArray = new char[6];
			char[] inputCharArray = value.ToCharArray();
			int[] inputIntArray = new int[6];

			for (int i=0; i < inputCharArray.Length; i++) {
				inputIntArray[i] = System.Convert.ToInt32(inputCharArray[i]);
			}

			int hexFloor = System.Convert.ToInt32('0');
			int hexCeiling = System.Convert.ToInt32('F');

			for (int i=0; i < inputIntArray.Length; i++) { 
				if (inputIntArray[i] < hexFloor) { inputIntArray[i] = hexFloor; }
				if (inputIntArray[i] > hexCeiling) { inputIntArray[i] = hexCeiling;}
			}

			for (int i=0; i < inputIntArray.Length; i++) {
				clampedCharArray[i] = System.Convert.ToChar(inputIntArray[i]);
			}

			clampedHEX = new string(clampedCharArray);
			return clampedHEX;
		}

		public class RGB {
			public float Red {get; set;}
			public float Green {get; set;}
			public float Blue {get; set;}

			public RGB(float red, float green, float blue) {
				Red = ClampValues(0.0f, red, 1.0f);
				Green = ClampValues(0.0f, green, 1.0f);
				Blue = ClampValues(0.0f, blue, 1.0f);
			}
		}

		public class HSV {
			public float Hue {get; set;}
			public float Saturation {get; set;}
			public float Value {get; set;}

			public HSV(float hue, float saturation, float value) {
				Hue = ClampValues(0.0f, hue, 1.0f);
				Saturation = ClampValues(0.0f, saturation, 1.0f);
				Value = ClampValues(0.0f, value, 1.0f);
			}
		}

		public class HSL {
			public float Hue {get; set;}
			public float Saturation {get; set;}
			public float Lightness {get; set;}

			public HSL(float hue, float saturation, float lightness) {
				Hue = ClampValues(0.0f, hue, 1.0f);
				Saturation = ClampValues(0.0f, saturation, 1.0f);
				Lightness = ClampValues(0.0f, lightness, 1.0f);
			}
		}

		public class HEX {
			public int[] Integers {get; set;}
			public string Value {get; set;}

			public HEX(string value) {
				value = value.ToUpper();
				Value = ClampValues(value);

				Integers = ValueToIntegers(Value);
			}

			private static int[] ValueToIntegers(string value) {
				string[] values = new string[3];

				int valuesIter = 0;
				for (int i = 0; i < value.Length; i+=2) {
					values[valuesIter] = string.Concat(value[i], value[i+1]);

					valuesIter++;
				}

				int[] output = new int[3];
				for (int i = 0; i < values.Length; i++) {
					output[i] = int.Parse(values[i], System.Globalization.NumberStyles.HexNumber);
				}

				return output;
			}
		}
	}
}