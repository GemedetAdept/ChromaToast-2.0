using ChromaToast.Chroma;

namespace ChromaToast.Tests {
	public class RGBTests {
		[Fact]
		public void RedValue_UnderFloor_ReturnsFloor() {

			float valueRed = -0.7f;
			float valueGreen = 1.0f;
			float valueBlue = 1.0f;
			float expected = 0.0f;

			var colorRGB = new ChromaToast.Chroma.Chroma.RGB(valueRed, valueGreen, valueBlue);
			float result = colorRGB.Red;

			Assert.Equal(expected, result);
		}

		[Fact]
		public void RedValue_AboveCeiling_ReturnsCeiling() {
			
			float valueRed = 1.7f;
			float valueGreen = 1.0f;
			float valueBlue = 1.0f;
			float expected = 1.0f;

			var colorRGB = new ChromaToast.Chroma.Chroma.RGB(valueRed, valueGreen,valueBlue);
			float result = colorRGB.Red;

			Assert.Equal(expected, result);
		}
	}

}
