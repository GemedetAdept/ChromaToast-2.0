using ChromaToast.Color;

namespace ChromaToast.Tests {
	public class RGBTests {
		[Fact]
		public void RedValue_UnderFloor_ReturnsFloor() {

			float valueRed = -0.7f;
			float valueGreen = 1.0f;
			float valueBlue = 1.0f;
			float expected = 0.0f;

			var colorRGB = new Color.RGB(valueRed, valueGreen, valueBlue);
		}
	}
}
