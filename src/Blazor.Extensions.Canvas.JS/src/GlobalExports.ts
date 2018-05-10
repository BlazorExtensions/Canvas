if (typeof window !== 'undefined' && !window['BlazorExtensions']) {
    // When the library is loaded in a browser via a <script> element, make the
    // following APIs available in global scope for invocation from JS
    window['BlazorExtensions'] = {
    };
  }
  