import { Canvas2dContextManager } from './Canvas2dContextManager';

const blazorExtensions = 'BlazorExtensions';

function initialize() {
  "use strict";

  if (typeof window !== 'undefined' && !window[blazorExtensions]) {
    // When the library is loaded in a browser via a <script> element, make the
    // following APIs available in global scope for invocation from JS
    window[blazorExtensions] = {
      Canvas2d: new Canvas2dContextManager()
    };
  } else {
    window[blazorExtensions] = {
      ...window[blazorExtensions],
      Canvas2d: new Canvas2dContextManager()
    };
  }
}

initialize();
