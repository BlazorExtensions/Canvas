using Blazor.Extensions.Canvas.WebGL;
using Microsoft.AspNetCore.Blazor.Components;

namespace Blazor.Extensions.Canvas.Test.Pages
{
    public class WebGLComponent : BlazorComponent
    {
        protected BECanvasComponent canvasReference;

        protected override void OnAfterRender()
        {
            WebGLContext context = this.canvasReference.CreateWebGL();

            context.ClearColor(0, 0, 0, 1);
            context.Clear(BufferBits.COLOR_BUFFER_BIT);
        }
    }
}
