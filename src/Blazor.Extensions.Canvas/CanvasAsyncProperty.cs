using Microsoft.AspNetCore.Blazor;
using Microsoft.JSInterop;
using System;
using System.Threading.Tasks;
using static Blazor.Extensions.Canvas2dContextConstants;

namespace Blazor.Extensions
{
    internal class CanvasAsyncProperty<TNet, TJs> : IAsyncProperty<TNet>
    {
        private readonly ElementRef canvas;
        private readonly string propertyName;
        private readonly Func<TNet, TJs> toJs;
        private readonly Func<TJs, TNet> toNet;

        internal CanvasAsyncProperty(ElementRef canvas, string propertyName, Func<TNet, TJs> toJs, Func<TJs, TNet> toNet)
        {
            this.canvas = canvas;
            this.propertyName = propertyName;
            this.toJs = toJs;
            this.toNet = toNet;
        }

        public async Task<TNet> GetAsync() => this.toNet(await JSRuntime.Current.InvokeAsync<TJs>(GET_CANVAS_PROPERTY_ACTION, this.canvas, this.propertyName));

        public Task SetAsync(TNet value) => JSRuntime.Current.InvokeAsync<object>(SET_CANVAS_PROPERTY_ACTION, this.canvas, this.propertyName, this.toJs(value));
    }
}
