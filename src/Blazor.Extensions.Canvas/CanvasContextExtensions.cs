namespace Blazor.Extensions
{
    public static class CanvasContextExtensions
    {
        public static Canvas2dContext CreateCanvas2d(this BECanvasComponent canvas)
        {
            return new Canvas2dContext(canvas);
        }
    }
}
