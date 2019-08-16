# Canvas
HTML5 Canvas API implementation for Microsoft Blazor

[![Build status](https://dotnet-ci.visualstudio.com/DotnetCI/_apis/build/status/Blazor-Extensions-Canvas-CI?branch=master)](https://dotnet-ci.visualstudio.com/DotnetCI/_build/latest?definitionId=15&branch=master)
[![Package Version](https://img.shields.io/nuget/v/Blazor.Extensions.Canvas.svg)](https://www.nuget.org/packages/Blazor.Extensions.Canvas)
[![NuGet Downloads](https://img.shields.io/nuget/dt/Blazor.Extensions.Canvas.svg)](https://www.nuget.org/packages/Blazor.Extensions.Canvas)
[![License](https://img.shields.io/github/license/BlazorExtensions/Canvas.svg)](https://github.com/BlazorExtensions/Canvas/blob/master/LICENSE)

# Blazor Extensions

Blazor Extensions are a set of packages with the goal of adding useful things to [Blazor](https://blazor.net).

# Blazor Extensions Canvas

This package wraps [HTML5 Canvas](https://developer.mozilla.org/en-US/docs/Web/HTML/Element/canvas) APIs. 

Both Canvas 2D and WebGL are supported.

Both client and server-side scenarios using either Blazor or Razor Components are supported.

**NOTE** Currently targets the v3.0.0-preview4 version of Blazor/Razor Components, which has a limitation regarding static files included in component libraries (aspnet/AspNetCore#6349). As a temporary workaround, manually add the `blazor.extensions.canvas.js` file to wwwroot and add a reference to it in a `<script>` tag in the `<head>` element of your project website (`_Host.cshtml`):
`<script src="blazor.extensions.canvas.js"></script>`

# Installation

```
Install-Package Blazor.Extensions.Canvas
```

# Sample

## Usage

On your .razor add a `BECanvas` and make sure you set the `@ref` to a field on your component:

```c#
@using Blazor.Extensions.Canvas
...
<BECanvas @ref="@_canvasReference"></BECanvas>
```

### 2D

On your component C# code (regardless if inline on .razor or in a .cs file), from a `BECanvasComponent` reference, create a `Canvas2DContext`, and then use the context methods to draw on the canvas:

```c#
using Blazor.Extensions;
using Blazor.Extensions.Canvas.Canvas2D;

private Canvas2DContext _context;

protected BECanvasComponent _canvasReference;

protected override async Task OnAfterRenderAsync()
{
    this._context = await this._canvasReference.CreateCanvas2DAsync();
    await this._context.SetFillStyleAsync("green");

    await this._context.FillRectAsync(10, 100, 100, 100);

    await this._context.SetFontAsync("48px serif");
    await this._context.StrokeTextAsync("Hello Blazor!!!", 10, 100);
}
```

**NOTE** You cannot call `CreateCanvas2DAsync` in `OnInitAsync`, because the underlying `<canvas>` element is not yet present in the generated markup.

### WebGL

On your component C# code (regardless if inline on .razor or in a .cs file), from a `BECanvasComponent` reference, create a `WebGLContext`, and then use the context methods to draw on the canvas:

```c#
using Blazor.Extensions;
using Blazor.Extensions.Canvas.WebGL;

private WebGLContext _context;

protected BECanvasComponent _canvasReference;

protected override async Task OnAfterRenderAsync()
{
    this._context = await this._canvasReference.CreateWebGLAsync();
    
    await this._context.ClearColorAsync(0, 0, 0, 1);
    await this._context.ClearAsync(BufferBits.COLOR_BUFFER_BIT);
}
```

**NOTE** You cannot call `CreateWebGLAsync` in `OnInitAsync`, because the underlying `<canvas>` element is not yet present in the generated markup.

### Call Batching

All javascript interop are batched as needed to improve performance. In high-performance scenarios this behavior will not have any effect: each call will execute immediately. In low-performance scenarios, consective calls to canvas APIs will be queued. JavaScript interop calls will be made with each batch of queued commands sequentially, to avoid the performance impact of multiple concurrent interop calls.

When using server-side Razor Components, because of the server-side rendering mechanism, only the last drawing operation executed will appear to render on the client, overwriting all previous operations. In the example code above, for example, drawing the triangles would appear to "erase" the black background drawn immediately before, leaving the canvas transparent.

To avoid this issue, all WebGL **drawing** operations should be explicitly preceded and followed by `BeginBatchAsync` and `EndBatchAsync` calls.

For example:

```c#
await this._context.ClearColorAsync(0, 0, 0, 1); // this call does not draw anything, so it does not need to be included in the explicit batch

await this._context.BeginBatchAsync(); // begin the explicit batch

await this._context.ClearAsync(BufferBits.COLOR_BUFFER_BIT);
await this._context.DrawArraysAsync(Primitive.TRIANGLES, 0, 3);

await this._context.EndBatchAsync(); // execute all currently batched calls
```

It is best to structure your code so that `BeginBatchAsync` and `EndBatchAsync` surround as few calls as possible. That will allow the automatic batching behavior to send calls in the most efficient manner possible, and avoid unnecessary performance impacts.

Methods which return values are never batched. Such methods may be called at any time, *even after calling `BeginBatchAsync`*, without interrupting the batching of other calls.

***NOTE*** The "overwriting" behavior of server-side code is unpredictable, and shouldn't be relied on as a feature. In low-performance situations calls can be batched automatically, even when you don't explicitly use `BeginBatchAsync` and `EndBatchAsync`.

# Contributions and feedback

Please feel free to use the component, open issues, fix bugs or provide feedback.

# Contributors

The following people are the maintainers of the Blazor Extensions projects:

- [Attila Hajdrik](https://github.com/attilah)
- [Gutemberg Ribiero](https://github.com/galvesribeiro)

