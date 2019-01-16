using Blazor.Extensions.Canvas.Canvas2D;
using Blazor.Extensions.Canvas.WebGL;

namespace Blazor.Extensions
{
    public static class CanvasContextExtensions
    {
        public static Canvas2DContext CreateCanvas2D(this BECanvasComponent canvas)
        {
            return new Canvas2DContext(canvas);
        }

        public static WebGLContext CreateWebGL(this BECanvasComponent canvas)
        {
            return new WebGLContext(canvas);
        }
    }
}
