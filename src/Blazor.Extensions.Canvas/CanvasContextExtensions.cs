using System.Threading.Tasks;

namespace Blazor.Extensions
{
    public static class CanvasContextExtensions
    {
        public static Canvas2dContext CreateCanvas2d(this BECanvasComponent canvas)
        {
            return new Canvas2dContext(canvas);
        }

        public static async Task<Canvas2dContextAsync> CreateCanvas2dAsync(this BECanvasComponent canvas)
        {
            return await new Canvas2dContextAsync(canvas).AddCanvasAsync();
        }
    }
}
