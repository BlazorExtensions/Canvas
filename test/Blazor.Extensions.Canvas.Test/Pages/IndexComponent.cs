using Blazor.Extensions.Canvas.Canvas2D;
using Microsoft.AspNetCore.Blazor.Components;
using System.Threading.Tasks;

namespace Blazor.Extensions.Canvas.Test.Pages
{
    public class IndexComponent : BlazorComponent
    {
        private Canvas2DContext _context;

        protected BECanvasComponent canvasReference;

        protected override async Task OnAfterRenderAsync()
        {
            this._context = await this.canvasReference.CreateCanvas2DAsync();
            await this._context.SetFillStyleAsync("green");

            await this._context.FillRectAsync(10, 100, 100, 100);

            await this._context.SetFontAsync("48px serif");
            await this._context.StrokeTextAsync("Hello Blazor!!!", 10, 100);
        }
    }
}
