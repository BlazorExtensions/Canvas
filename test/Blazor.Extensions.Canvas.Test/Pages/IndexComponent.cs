using Blazor.Extensions.Canvas.Canvas2D;
using Microsoft.AspNetCore.Blazor.Components;

namespace Blazor.Extensions.Canvas.Test.Pages
{
    public class IndexComponent : BlazorComponent
    {
        private Canvas2DContext _context;

        protected BECanvasComponent canvasReference;

        protected override void OnAfterRender()
        {
            this._context = this.canvasReference.CreateCanvas2D();
            this._context.FillStyle = "green";

            this._context.FillRect(10, 100, 100, 100);

            this._context.Font = "48px serif";
            this._context.StrokeText("Hello Blazor!!!", 10, 100);
        }
    }
}
