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
	// RGB To
	Console.WriteLine("RGB To...");
	Chroma.RGB newRGB = new Chroma.RGB(red: 0.505f, green: 0.827f, blue: 0.380f);
	Chroma.HSV outHSV = ChromaToast.Convert.RGB.ToHSV(newRGB);
	Chroma.HSL outHSL = ChromaToast.Convert.RGB.ToHSL(newRGB);
	Chroma.HEX outHEX = ChromaToast.Convert.RGB.ToHEX(newRGB);

	// HSV To
	Console.WriteLine("\nHSV To...");
	Chroma.HSV newHSV = new Chroma.HSV(hue: 0.286f, saturation: 0.540f, value: 0.827f);
	Chroma.RGB outRGB = ChromaToast.Convert.HSV.ToRGB(newHSV);
}

// Test Functions
//clamping();
conversion();