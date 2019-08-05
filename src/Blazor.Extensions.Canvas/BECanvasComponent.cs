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

        [Parameter]
        protected string Id { get; set; } = Guid.NewGuid().ToString();

        protected ElementRef _canvasRef;

        internal ElementRef CanvasReference => this._canvasRef;

        [Inject]
        internal IJSRuntime JSRuntime { get; set; }

        [Parameter]
        protected Action<UIMouseEventArgs> OnClick { get; set; }
    }
}
