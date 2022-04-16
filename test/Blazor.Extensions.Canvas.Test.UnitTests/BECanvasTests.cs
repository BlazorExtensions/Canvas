using Bunit;
using System.Threading.Tasks;
using Xunit;

namespace Blazor.Extensions.Canvas.Test.UnitTests
{
    public class BECanvasTests
    {
        [Fact]
        public void TagName_Should_Be_CANVAS()
        {
            // Arrange
            using var ctx = new TestContext();
            var cut = ctx.RenderComponent<BECanvas>();
            var paraElm = cut.Find("canvas");

            // Assert
            Assert.Equal("CANVAS", paraElm.TagName);
        }

        [Fact]
        public void Instance_Defaults()
        {
            // Arrange
            using var ctx = new TestContext();
            var cut = ctx.RenderComponent<BECanvas>();

            // Act
            var inst = cut.Instance;

            // Assert
            Assert.Equal(0, inst.Width);
            Assert.Equal(0, inst.Height);
            Assert.False(string.IsNullOrEmpty(inst.CanvasReference.Id));
        }

        [Fact]
        public async Task MeasureTextAsync()
        {
            // Arrange
            using var ctx = new TestContext();
            var cut = ctx.RenderComponent<BECanvas>();
            ctx.JSInterop.Mode = JSRuntimeMode.Loose;

            // Act
            var moduleJsInterop = ctx.JSInterop.SetupModule("blazor.extensions.canvas.js");
            var canvasCtx = await cut.Instance.CreateCanvas2DAsync();
            await canvasCtx.SetFontAsync("16px Courier");
            var txtMtr = await canvasCtx.MeasureTextAsync("t");

            // Assert
            Assert.Null(txtMtr);
        }

    }
}