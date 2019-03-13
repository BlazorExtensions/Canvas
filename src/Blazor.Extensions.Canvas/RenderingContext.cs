using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Blazor;
using Microsoft.JSInterop;

namespace Blazor.Extensions
{
    public abstract class RenderingContext : IDisposable
    {
        private const string NAMESPACE_PREFIX = "BlazorExtensions";
        private const string SET_PROPERTY_ACTION = "setProperty";
        private const string GET_PROPERTY_ACTION = "getProperty";
        private const string CALL_METHOD_ACTION = "call";
        private const string CALL_BATCH_ACTION = "callBatch";
        private const string ADD_ACTION = "add";
        private const string REMOVE_ACTION = "remove";
        private readonly string _contextName;
        private readonly IJSRuntime _jsRuntime;
        private readonly object _parameters;

        private bool _awaitingBatchedCall;
        private List<CanvasBatchedCallInfo> _batchedCalls = new List<CanvasBatchedCallInfo>();
        private bool _initialized;
        private SemaphoreSlim _semaphoreSlim;

        public ElementRef Canvas { get; }

        internal RenderingContext(BECanvasComponent reference, string contextName, object parameters = null)
        {
            this.Canvas = reference.CanvasReference;
            this._contextName = contextName;
            this._jsRuntime = reference.JSRuntime;
            this._parameters = parameters;
        }

#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously; Reason: extension point for subclasses, which may do asynchronous work
        protected virtual async Task ExtendedInitializeAsync() { }
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously

        internal async Task<RenderingContext> InitializeAsync()
        {
            await this._semaphoreSlim.WaitAsync();
            if (!this._initialized)
            {
                await this._jsRuntime.InvokeAsync<object>($"{NAMESPACE_PREFIX}.{this._contextName}.{ADD_ACTION}", this.Canvas, this._parameters);
                await this.ExtendedInitializeAsync();
                this._initialized = true;
            }
            this._semaphoreSlim.Release();
            return this;
        }

        #region Protected Methods
        protected async Task SetPropertyAsync(string property, object value)
        {
            await this.BatchPropertySetAsync(property, value);
        }

        protected async Task<T> GetPropertyAsync<T>(string property)
        {
            return await this._jsRuntime.InvokeAsync<T>($"{NAMESPACE_PREFIX}.{this._contextName}.{GET_PROPERTY_ACTION}", this.Canvas, property);
        }

        protected T CallMethod<T>(string method)
        {
            return this.CallMethodAsync<T>(method).GetAwaiter().GetResult();
        }

        protected async Task<T> CallMethodAsync<T>(string method)
        {
            return await this._jsRuntime.InvokeAsync<T>($"{NAMESPACE_PREFIX}.{this._contextName}.{CALL_METHOD_ACTION}", this.Canvas, method);
        }

        protected async Task CallMethodAsync(string method)
        {
            await this.BatchMethodCallAsync(method);
        }

        protected T CallMethod<T>(string method, params object[] value)
        {
            return this.CallMethodAsync<T>(method, value).GetAwaiter().GetResult();
        }

        protected async Task<T> CallMethodAsync<T>(string method, params object[] value)
        {
            return await this._jsRuntime.InvokeAsync<T>($"{NAMESPACE_PREFIX}.{this._contextName}.{CALL_METHOD_ACTION}", this.Canvas, method, value);
        }

        protected async Task CallMethodAsync(string method, params object[] value)
        {
            await this.BatchMethodCallAsync(method, value);
        }

        private async Task BatchCallAsync(string call, string name, params object[] value)
        {
            this._batchedCalls.Add(new CanvasBatchedCallInfo(call, name, value));

            await this._semaphoreSlim.WaitAsync();
            if (this._awaitingBatchedCall)
            {
                this._semaphoreSlim.Release();
                return;
            }

            this._awaitingBatchedCall = true;
            var currentBatch = this._batchedCalls.ToArray();
            this._batchedCalls.Clear();
            this._semaphoreSlim.Release();

            await this._jsRuntime.InvokeAsync<object>($"{NAMESPACE_PREFIX}.{this._contextName}.{CALL_BATCH_ACTION}", this.Canvas, currentBatch);

            await this._semaphoreSlim.WaitAsync();
            this._awaitingBatchedCall = false;
            this._semaphoreSlim.Release();
        }

        private async Task BatchMethodCallAsync(string method, object[] value = null)
        {
            await this.BatchCallAsync(CALL_METHOD_ACTION, method, value);
        }

        private async Task BatchPropertySetAsync(string property, object value)
        {
            await this.BatchCallAsync(SET_PROPERTY_ACTION, property, value);
        }

        public void Dispose()
        {
            Task.Run(async () => await this._jsRuntime.InvokeAsync<object>($"{NAMESPACE_PREFIX}.{this._contextName}.{REMOVE_ACTION}", this.Canvas));
        }
        #endregion
    }
}
