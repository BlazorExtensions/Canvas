import { ContextManager } from './CanvasContextManager';

namespace Canvas {
  const blazorExtensions: string = 'BlazorExtensions';
  // define what this extension adds to the window object inside BlazorExtensions
  const extensionObject = {
    Canvas2d: new ContextManager("2d"),
    WebGL: new ContextManager("webgl"),
    putImageData: (data, length, width, height, canvas, dx, dy) => {
      var uintClampledArray = new Uint8ClampedArray(length);
      for (var i = 0; i < length; i++) {
        uintClampledArray[i] = data[i];
      }
      var newImage = new ImageData(uintClampledArray, width, height)
      extensionObject.Canvas2d.call(canvas, "putImageData", [newImage, dx, dy])
    }
    };

  export function initialize(): void {
    if (typeof window !== 'undefined' && !window[blazorExtensions]) {
      // when the library is loaded in a browser via a <script> element, make the
      // following APIs available in global scope for invocation from JS
      window[blazorExtensions] = {
        ...extensionObject
      };
    } else {
      window[blazorExtensions] = {
        ...window[blazorExtensions],
        ...extensionObject
      };
    }
  }
}

Canvas.initialize();
