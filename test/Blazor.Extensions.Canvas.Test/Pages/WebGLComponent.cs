using Blazor.Extensions.Canvas.WebGL;
using Microsoft.AspNetCore.Blazor.Components;

namespace Blazor.Extensions.Canvas.Test.Pages
{
    public class WebGLComponent : BlazorComponent
    {
        protected BECanvasComponent canvasReference;

        protected override void OnAfterRender()
        {
            WebGLContext context = this.canvasReference.CreateWebGL(new WebGLContextAttributes
            {
                PowerPreference = WebGLContextAttributes.POWER_PREFERENCE_HIGH_PERFORMANCE
            });

            context.ClearColor(0, 1, 0, 1);
            context.Clear(BufferBits.COLOR_BUFFER_BIT);
        }
    }
}
