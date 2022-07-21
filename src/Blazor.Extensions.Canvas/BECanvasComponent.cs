using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.JSInterop;
using System;
using System.Threading.Tasks;

namespace Blazor.Extensions
{
    public class BECanvasComponent : ComponentBase
    {
        [Parameter]
        public long Height { get; set; }

        [Parameter]
        public long Width { get; set; }

        [Parameter]
        public bool ContextMenuPreventDefault { get; set; } = false;

        [Parameter]
        public bool ContextMenuStopPropagation { get; set; } = false;

        [Parameter]
        public EventCallback<MouseEventArgs> Click { get; set; }

        [Parameter]
        public EventCallback<MouseEventArgs> ContextMenu { get; set; }

        [Parameter]
        public EventCallback<WheelEventArgs> MouseWheel { get; set; }

        protected readonly string Id = Guid.NewGuid().ToString();
        protected ElementReference _canvasRef;

        public ElementReference CanvasReference => this._canvasRef;

        [Inject]
        internal IJSRuntime JSRuntime { get; set; }

        protected async Task OnClicked(MouseEventArgs args)
        {
          await this.Click.InvokeAsync(args);
        }

        protected async Task OnContextMenu(MouseEventArgs args)
        {
            await this.ContextMenu.InvokeAsync(args);
        }
    }
}
