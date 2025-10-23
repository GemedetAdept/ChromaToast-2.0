using ChromaToast.Color;

namespace ChromaToast.Tests {
    public class RGBTests {

        [Fact]
        public void RedValue_UnderFloor_ReturnsFloor() {
			float redValue = -0.7f;
			float greenValue = 1.0f;
			float blueValue = 1.0f;
			float expected = 0.0f;

			var colorRGB = new Color.RGB(redValue, greenValue, blueValue);
			float result = colorRGB.Red;

			Assert.Equal(expected, result);
        }
    }
}