using Blazor.Extensions.Canvas.Canvas2D;
using Microsoft.AspNetCore.Components;
using System;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace Blazor.Extensions.Canvas.Test.ClientSide.Pages
{
    public class IndexComponent : ComponentBase
    {
        private Canvas2DContext _context;

        protected BECanvasComponent _canvasReference;

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            this._context = await this._canvasReference.CreateCanvas2DAsync();
            await this._context.SetFillStyleAsync("green");

            await this._context.FillRectAsync(0, 0, 100, 100);

            await this._context.SetFontAsync("48px serif");
            await this._context.StrokeTextAsync("Hello Blazor!!!", 10, 100);

            var ImageData = await this._context.GetImageDataAsync(0, 0, 100, 100);

            ImageData.Data = new byte[2];

            await this._context.PutImageDataAsync(ImageData, 0, 0);
            
        }
    }
}
