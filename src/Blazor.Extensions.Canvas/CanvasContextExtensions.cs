namespace Blazor.Extensions.Canvas
{
    public static class CanvasContextExtensions
    {
        public static Canvas2dContext CreateCanvas2D(this BECanvasComponent canvas)
        {
            return new Canvas2dContext(canvas);
        }

        public static WebGLContext CreateWebGL(this BECanvasComponent canvas)
        {
            return new WebGLContext(canvas);
        }
    }
}
