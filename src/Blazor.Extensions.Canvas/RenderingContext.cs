using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace Blazor.Extensions
{
    public abstract class RenderingContext : IDisposable
    {
        private const string NAMESPACE_PREFIX = "BlazorExtensions";
        private const string GET_PROPERTY_ACTION = "getProperty";
        private const string CALL_METHOD_ACTION = "call";
        private const string CALL_BATCH_ACTION = "callBatch";
        private const string ADD_ACTION = "add";
        private const string REMOVE_ACTION = "remove";
        private readonly List<object[]> _batchedCallObjects = new List<object[]>();
        private readonly string _contextName;
        private readonly IJSRuntime _jsRuntime;
        private readonly object _parameters;
        private readonly SemaphoreSlim _semaphoreSlim = new SemaphoreSlim(1, 1);

        private bool _awaitingBatchedCall;
        private bool _batching;
        private bool _initialized;

        public ElementReference Canvas { get; }

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

        public async Task BeginBatchAsync()
        {
            await this._semaphoreSlim.WaitAsync();
            this._batching = true;
            this._semaphoreSlim.Release();
        }

        public async Task EndBatchAsync()
        {
            await this._semaphoreSlim.WaitAsync();

            await this.BatchCallInnerAsync();
        }

        protected async Task BatchCallAsync(string name, bool isMethodCall, params object[] value)
        {
            await this._semaphoreSlim.WaitAsync();

            var callObject = new object[value.Length + 2];
            callObject[0] = name;
            callObject[1] = isMethodCall;
            Array.Copy(value, 0, callObject, 2, value.Length);
            this._batchedCallObjects.Add(callObject);

            if (this._batching || this._awaitingBatchedCall)
            {
                this._semaphoreSlim.Release();
            }
            else
            {
                await this.BatchCallInnerAsync();
            }
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

        protected T CallMethod<T>(string method, params object[] value)
        {
            return this.CallMethodAsync<T>(method, value).GetAwaiter().GetResult();
        }

        protected async Task<T> CallMethodAsync<T>(string method, params object[] value)
        {
            return await this._jsRuntime.InvokeAsync<T>($"{NAMESPACE_PREFIX}.{this._contextName}.{CALL_METHOD_ACTION}", this.Canvas, method, value);
        }

        private async Task BatchCallInnerAsync()
        {
            this._awaitingBatchedCall = true;
            var currentBatch = this._batchedCallObjects.ToArray();
            this._batchedCallObjects.Clear();
            this._semaphoreSlim.Release();

            _ = await this._jsRuntime.InvokeAsync<object>($"{NAMESPACE_PREFIX}.{this._contextName}.{CALL_BATCH_ACTION}", this.Canvas, currentBatch);

            await this._semaphoreSlim.WaitAsync();
            this._awaitingBatchedCall = false;
            this._batching = false;
            this._semaphoreSlim.Release();
        }

        public void Dispose()
        {
            Task.Run(async () => await this._jsRuntime.InvokeAsync<object>($"{NAMESPACE_PREFIX}.{this._contextName}.{REMOVE_ACTION}", this.Canvas));
        }

        #endregion
    }
}
