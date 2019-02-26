using Microsoft.AspNetCore.Blazor;
using Microsoft.AspNetCore.Blazor.Components;
using System;

namespace Blazor.Extensions
{
    public class BECanvasComponent : BlazorComponent
    {
        [Parameter]
        protected long Height { get; set; }

        [Parameter]
        protected long Width { get; set; }

        [Parameter]
        protected Action<UIMouseEventArgs> onclick { get; set; }

        protected readonly string Id = Guid.NewGuid().ToString();
        protected ElementRef canvasRef;

        internal ElementRef CanvasReference => this.canvasRef;
    }
}
