using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;

namespace Blazor.Extensions
{
    public class BECanvasComponent : ComponentBase
    {
        [Parameter]
        protected long Height { get; set; }

        [Parameter]
        protected long Width { get; set; }

        protected readonly string Id = Guid.NewGuid().ToString();
        protected ElementRef _canvasRef;

        internal ElementRef CanvasReference => this._canvasRef;

        [Inject]
        internal IJSRuntime JSRuntime { get; set; }
    }
}
