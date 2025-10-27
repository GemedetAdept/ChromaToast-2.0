using ChromaToast;
using System;

// Value Clamping
void clamping() {
	Chroma.RGB newRGB = new Chroma.RGB(red: 1.5f, green: -0.5f, blue: 0.5f);
	Chroma.HSV newHSV = new Chroma.HSV(hue: 1.5f, saturation: -0.5f, value: 0.5f);
	Chroma.HSL newHSL = new Chroma.HSL(hue: 1.5f, saturation: -0.5f, lightness: 0.5f);
	Chroma.HEX newHEX = new Chroma.HEX("Gc9a5d");
}

// Conversion Testing
void conversion() {
	// RGB To...
	Console.WriteLine("RGB To...");
	Chroma.RGB newRGB = new Chroma.RGB(red: 0.505f, green: 0.827f, blue: 0.380f);
	Chroma.HSV outHSV_0 = ChromaToast.Convert.RGB.ToHSV(newRGB);
	Chroma.HSL outHSL_0 = ChromaToast.Convert.RGB.ToHSL(newRGB);
	Chroma.HEX outHEX_0 = ChromaToast.Convert.RGB.ToHEX(newRGB);

	// HSV To...
	Console.WriteLine("\nHSV To...");
	Chroma.HSV newHSV = new Chroma.HSV(hue: 0.286f, saturation: 0.540f, value: 0.827f);
	Chroma.RGB outRGB_1 = ChromaToast.Convert.HSV.ToRGB(newHSV);
	Chroma.HSL outHSL_1 = ChromaToast.Convert.HSV.ToHSL(newHSV);
	Chroma.HEX outHEX_1 = ChromaToast.Convert.HSV.ToHEX(newHSV);

	// HSL To...
	Console.WriteLine("\nHSL To...");
	Chroma.HSL newHSL = new Chroma.HSL(hue: 0.286f, saturation:0.563f, lightness:0.603f);
	Chroma.RGB outRGB_2 = ChromaToast.Convert.HSL.ToRGB(newHSL);
	Chroma.HSV outHSV_2 = ChromaToast.Convert.HSL.ToHSV(newHSL);
	Chroma.HEX outHEX_2 = ChromaToast.Convert.HSL.ToHEX(newHSL);

	// HEX To...
	Console.WriteLine("\nHEX To...");
	Chroma.HEX newHEX = new Chroma.HEX("81D361");
	Chroma.RGB outRGB_3 = ChromaToast.Convert.HEX.ToRGB(newHEX);
}

// Test Functions
//clamping();
conversion();