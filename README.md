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

> **NOTE**: Only Canvas 2d is supported. WebGL will come later (contributions are welcome!).

# Installation

```
Install-Package Blazor.Extensions.Canvas
```

# Sample

## Usage

The following snippet shows how to consume the Canvas API in a Blazor component.

On your `_ViewImports.cshtml` add the `using` and TagHelper entries:

```c#
@using Blazor.Extensions.Canvas
@addTagHelper *, Blazor.Extensions.Canvas
```

On your .cshtml add a `BECanvas` and make sure you set the `ref` to a field on your component:

```c#
@page "/"
@inherits IndexComponent

<h1>Canvas demo!!!</h1>

<BECanvas ref="@_canvasReference"></BECanvas>
```

On your component C# code (regardless if inline on .cshtml or in a .cs file), from a `BECanvasComponent` reference, create a `Canvas2dContext`, and then use the context methods to draw on the canvas: 

```c#
private Canvas2dContext _context;

protected BECanvasComponent _canvasReference;

protected override void OnAfterRender()
{
    this._context = this._canvasReference.CreateCanvas2d();
    this._context.FillStyle = "green";

    this._context.FillRect(10, 100, 100, 100);

    this._context.Font = "48px serif";
    this._context.StrokeText("Hello Blazor!!!", 10, 100);
}
```

# Contributions and feedback

Please feel free to use the component, open issues, fix bugs or provide feedback.

# Contributors

The following people are the maintainers of the Blazor Extensions projects:

- [Attila Hajdrik](https://github.com/attilah)
- [Gutemberg Ribiero](https://github.com/galvesribeiro)

