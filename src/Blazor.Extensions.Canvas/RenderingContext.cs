using System;
using Microsoft.AspNetCore.Blazor;
using Microsoft.JSInterop;

namespace Blazor.Extensions.Canvas
{
    public abstract class RenderingContext : IDisposable
    {
        private const string NamespacePrefix = "BlazorExtensions";
        private const string SET_PROPERTY_ACTION = "SetProperty";
        private const string CALL_METHOD_ACTION = "Call";
        private const string ADD_ACTION = "Add";
        private const string REMOVE_ACTION = "Remove";

        protected abstract string ContextName { get; }

        public ElementRef Canvas { get; private set; }

        internal RenderingContext(BECanvasComponent canvasReference)
        {
            this.Canvas = canvasReference.CanvasReference;
            ((IJSInProcessRuntime)JSRuntime.Current).Invoke<object>($"{NamespacePrefix}.{this.ContextName}.{ADD_ACTION}", this.Canvas);
        }

        #region Private Methods
        protected void SetProperty(string property, object value)
        {
            ((IJSInProcessRuntime)JSRuntime.Current).Invoke<object>($"{NamespacePrefix}.{this.ContextName}.{SET_PROPERTY_ACTION}", this.Canvas, property, value);
        }

        protected T CallMethod<T>(string method)
        {
            return ((IJSInProcessRuntime)JSRuntime.Current).Invoke<T>($"{NamespacePrefix}.{this.ContextName}.{CALL_METHOD_ACTION}", this.Canvas, method);
        }

        protected T CallMethod<T>(string method, object value)
        {
            return ((IJSInProcessRuntime)JSRuntime.Current).Invoke<T>($"{NamespacePrefix}.{this.ContextName}.{CALL_METHOD_ACTION}", this.Canvas, method, value);
        }

        public void Dispose()
        {
            ((IJSInProcessRuntime)JSRuntime.Current).Invoke<object>($"{NamespacePrefix}.{this.ContextName}.{REMOVE_ACTION}", this.Canvas);
        }
        #endregion
    }
}
