using System;

namespace ChromaToast {

	public class Chroma {
		public Chroma() {}

		internal static float ClampValues(float floor, float input, float ceiling) {
			float clampedValue = 0.0f;

			if (input < floor) { clampedValue = floor; }
			else if (input > ceiling) { clampedValue = ceiling; }
			else { clampedValue = input; }

			return clampedValue;
		}

		internal static string ClampValues(string hexString) {
			string clampedHEX;
			char[] clampedCharArray = new char[6];
			char[] inputCharArray = hexString.ToCharArray();
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

		public static void PrintValues(string valueType, float value1, float value2, float value3) {

			Console.WriteLine("{0} : {1}, {2}, {3}", valueType, value1, value2, value3);
		}

		public static void PrintValues(string valueType, string value1) {

            Console.WriteLine("{0} : {1}", valueType, value1);
		}

		public static void PrintValues(string valueType, int[] values) {
			string outputString = "";
			
			foreach(int intValue in values) {
				string intString = System.Convert.ToString(intValue);

				outputString += $"{intString} ";
			}

			Console.WriteLine("{0} : {1}", valueType, outputString);
		}

		public class RGB {
			public float Red {get; set;}
			public float Green {get; set;}
			public float Blue {get; set;}

			public RGB(float red, float green, float blue) {
				Red = ClampValues(0.0f, red, 1.0f);
				Green = ClampValues(0.0f, green, 1.0f);
				Blue = ClampValues(0.0f, blue, 1.0f);

				PrintValues("RGB", Red, Green, Blue);
			}
		}

		public class HSV {
			public float Hue {get; set;}
			public float Saturation {get; set;}
			public float ValueHSV {get; set;}

			public HSV(float hue, float saturation, float valueHSV) {
				Hue = ClampValues(0.0f, hue, 1.0f);
				Saturation = ClampValues(0.0f, saturation, 1.0f);
				ValueHSV = ClampValues(0.0f, valueHSV, 1.0f);

				PrintValues("HSV", Hue, Saturation, ValueHSV);
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

				PrintValues("HSL", Hue, Saturation, Lightness);
			}
		}

		public class HEX {
			public int[] HexInt {get; set;}
			public string HexString {get; set;}

			public HEX(string hexString) {
				hexString = hexString.ToUpper();
				HexString = ClampValues(hexString);

				HexInt = HexStringtoHexInt(HexString);

				PrintValues("HexString", HexString);
				PrintValues("HexInt", HexInt);
			}

			private static int[] HexStringtoHexInt(string hexString) {
				char[] charArray = hexString.ToCharArray();
				int[] intArray = new int[6];

				for (int i=0; i < charArray.Length; i++) { 
					intArray[i] = System.Convert.ToInt32(charArray[i]);
				}

				return intArray;
			}
		}
	}
}