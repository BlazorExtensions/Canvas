using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;

namespace Blazor.Extensions
{
    public class BECanvasComponent : ComponentBase
    {
        [Parameter]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        [Parameter]
        public long Height { get; set; }

        [Parameter]
        public long Width { get; set; }

        protected ElementReference _canvasRef;

        public ElementReference CanvasReference => this._canvasRef;

        [Inject]
        internal IJSRuntime JSRuntime { get; set; }
    }
}
