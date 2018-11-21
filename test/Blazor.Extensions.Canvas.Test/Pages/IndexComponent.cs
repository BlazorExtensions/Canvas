using System.Threading.Tasks;
using Microsoft.AspNetCore.Blazor.Components;

namespace Blazor.Extensions.Canvas.Test.Pages
{
    public class IndexComponent : BlazorComponent
    {
        private Canvas2dContext _context;

        protected BECanvasComponent _canvasReference;

        protected override void OnAfterRender()
        {
            this._context = this._canvasReference.CreateCanvas2d();
            this._context.FillStyle = "green";

            this._context.FillRect(10, 100, 100, 100);

            this._context.Font = "48px serif";
            this._context.StrokeText("Hello Blazor!!!", 10, 100);
        }

        protected override async Task OnAfterRenderAsync()
        {
            using (var asyncContext = await this._canvasReference.CreateCanvas2dAsync())
            {
                await asyncContext.FillStyle.SetAsync("red");
                await asyncContext.FillRectAsync(110, 100, 100, 100);
                
                var color = await asyncContext.FillStyle.GetAsync();
                await asyncContext.StrokeTextAsync(color, 110, 200);
            }
        }
    }
}
