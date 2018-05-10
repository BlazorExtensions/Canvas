using Microsoft.AspNetCore.Blazor.Components;
using System;

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
            this._context.StrokeText("Hello Attila!!!", 10, 100);
        }
    }
}
