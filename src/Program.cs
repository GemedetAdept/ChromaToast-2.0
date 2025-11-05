using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChromaToast;
using ChromaToast.Exceptions;

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
	Chroma.HSV outHSV_3 = ChromaToast.Convert.HEX.ToHSV(newHEX);
	Chroma.HSL outHSL_3 = ChromaToast.Convert.HEX.ToHSL(newHEX);
}

void display() {
	Chroma.RGB newRGB = new Chroma.RGB(red: 0.505f, green: 0.827f, blue: 0.380f);
	Chroma.HSV newHSV = new Chroma.HSV(hue: 0.286f, saturation: 0.540f, value: 0.827f);
	Chroma.HSL newHSL = new Chroma.HSL(hue: 0.286f, saturation: 0.563f, lightness: 0.603f);
	Chroma.HEX newHEX = new Chroma.HEX(value: "81D361");

	Card newCard = new Card();
	newCard.InputAll(newRGB, newHSV, newHSL, newHEX);

	//Console.WriteLine("Normalized:");
	//CLI.Display.PrintNormalized(newRGB);
	//CLI.Display.PrintNormalized(newHSV);
	//CLI.Display.PrintNormalized(newHSL);
	//CLI.Display.PrintNormalized(newHEX);

	//Console.WriteLine("\nDisplay:");
	//CLI.Display.PrintDisplay(newRGB);
	//CLI.Display.PrintDisplay(newHSV);
	//CLI.Display.PrintDisplay(newHSL);
	//CLI.Display.PrintDisplay(newHEX);

	Console.WriteLine("Full");
	CLI.Display.PrintFull(newCard);
	//CLI.Display.PrintFull(newRGB);
	//CLI.Display.PrintFull(newHSV);
	//CLI.Display.PrintFull(newHSL);
	//CLI.Display.PrintFull(newHEX);
}

void generate() {
	Console.WriteLine("Generate.Random");

	Chroma.RGB newRGB = Generate.Random.RGB();
	CLI.Display.PrintFull(newRGB);

	Chroma.HSV newHSV = Generate.Random.HSV();
	CLI.Display.PrintFull(newHSV);

	Chroma.HSL newHSL = Generate.Random.HSL();
	CLI.Display.PrintFull(newHSL);

	Chroma.HEX newHEX = Generate.Random.HEX();
	CLI.Display.PrintFull(newHEX);

	Console.WriteLine("\nRandom Card");
	Card newCard = Generate.Random.Card();
	CLI.Display.PrintFull(newCard);
}

void card() {
	Console.WriteLine("\nBlank Card");
	Card newCard = new Card();
	CLI.Display.PrintFull(newCard);

	Console.WriteLine("\nGeneration of other chroma from one input");
	Chroma.RGB newRGB = Generate.Random.RGB();
	newCard.InputChroma(newRGB);
	CLI.Display.PrintFull(newCard);
}

void sanitize() {
	Chroma.HEX newHEX = new Chroma.HEX("#FFFFFF");
	CLI.Display.PrintFull(newHEX);

	newHEX = new Chroma.HEX("0xFFFFFF");
	CLI.Display.PrintFull(newHEX);
}

void exceptions() {
	int[] array1 = new int[] {2, 3};
	int[] array2 = new int[] {4, 5, 8};

	try {
		if (array1.Length != array2.Length) {
			throw new ArrayLengthMismatchException();
		}
	}

	catch (ArrayLengthMismatchException ex) {
		Console.WriteLine(ex.Message + " Array lengths: {0}, {1}.", array1.Length, array2.Length);
	}

	bool largestIndexMatches = false;
	int largest = Int32.MinValue;
	try {
		for (int i = 0; i < array2.Length; i++) {
			if (array2[i] > largest) { largest = array2[i]; }
		}

		if (array1.Length < largest) {
			throw new LargestIndexMismatchException();	
		}
		else { largestIndexMatches = true; }
	}

	catch(LargestIndexMismatchException ex) {
		Console.WriteLine(ex.Message + " Target array length: {0}. Largest index input: {1}.", 
			array1.Length, largest	
		);	
	}
}

void palette() {
	Palette newPalette = new Palette();

	Console.WriteLine("\n| Initial State |");
	Console.WriteLine(newPalette.Cards);
	Console.WriteLine("Card Count: {0}", newPalette.Count);

	Console.WriteLine("\n| Add Blank Card |");
	Card card0 = new Card();
	newPalette.AppendCard(card0);
	Console.WriteLine("Card Count: {0}", newPalette.Count);

	Console.WriteLine("\n| Add Random Card |");
	Card card1 = Generate.Random.Card();
	newPalette.AppendCard(card1);
	Console.WriteLine("Card Count: {0}", newPalette.Count);

	Console.WriteLine("\n| Print Card Details |");
	foreach (Card card in newPalette.Cards) {
		Console.WriteLine("\n");
		CLI.Display.PrintDisplay(card);
	}
}

void harmony() {
	Card card0 = new Card();
	Chroma.HEX newHex = new Chroma.HEX("E3405C");
	card0.InputChroma(newHex);

	Console.WriteLine("\n| Complementary Harmony Pattern |");
	//Card[] cards0 = Generate.Random.PureComplementary();
	Card[] cards0 = Generate.PurePalette.Complementary(card0);
	CLI.Display.PrintDisplay(cards0[0]);
	CLI.Display.PrintDisplay(cards0[1]);

	Console.WriteLine("\n| SplitComplementary Harmony Pattern |");
	//Card[] cards1 = Generate.Random.PureSplitComplementary();
	Card[] cards1 = Generate.PurePalette.SplitComplementary(card0);
	CLI.Display.PrintDisplay(cards1[0]);
	CLI.Display.PrintDisplay(cards1[1]);
	CLI.Display.PrintDisplay(cards1[2]);

	Console.WriteLine("\n| Analogous Harmony Pattern |");
	//Card[] cards2 = Generate.Random.PureAnalogous();
	Card[] cards2 = Generate.PurePalette.Analogous(card0);
	CLI.Display.PrintDisplay(cards2[0]);
	CLI.Display.PrintDisplay(cards2[1]);
	CLI.Display.PrintDisplay(cards2[2]);

	Console.WriteLine("\n| Triadic Harmony Pattern |");
	//Card[] cards3 = Generate.Random.PureTriadic();
	Card[] cards3 = Generate.PurePalette.Triadic(card0);
	CLI.Display.PrintDisplay(cards3[0]);
	CLI.Display.PrintDisplay(cards3[1]);
	CLI.Display.PrintDisplay(cards3[2]);

	Console.WriteLine("\n| Tetradic Harmony Pattern |");
	//Card[] cards4 = Generate.Random.PureTetradic();
	Card[] cards4 = Generate.PurePalette.Tetradic(card0);
	CLI.Display.PrintDisplay(cards4[0]);
	CLI.Display.PrintDisplay(cards4[1]);
	CLI.Display.PrintDisplay(cards4[2]);
	CLI.Display.PrintDisplay(cards4[3]);

	Console.WriteLine("\n| Square Harmony Pattern |");
	//Card[] cards5 = Generate.Random.PureSquare();
	Card[] cards5 = Generate.PurePalette.Square(card0);
	CLI.Display.PrintDisplay(cards5[0]);
	CLI.Display.PrintDisplay(cards5[1]);
	CLI.Display.PrintDisplay(cards5[2]);
	CLI.Display.PrintDisplay(cards5[3]);
}

// Test Functions
//clamping();
//conversion();
//display();
//generate();
//card();
//sanitize();
//exceptions();
//palette();
harmony();