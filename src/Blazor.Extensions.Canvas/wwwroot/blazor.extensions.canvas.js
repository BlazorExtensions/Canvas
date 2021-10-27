!function(t){var e={};function n(r){if(e[r])return e[r].exports;var i=e[r]={i:r,l:!1,exports:{}};return t[r].call(i.exports,i,i.exports,n),i.l=!0,i.exports}n.m=t,n.c=e,n.d=function(t,e,r){n.o(t,e)||Object.defineProperty(t,e,{enumerable:!0,get:r})},n.r=function(t){"undefined"!=typeof Symbol&&Symbol.toStringTag&&Object.defineProperty(t,Symbol.toStringTag,{value:"Module"}),Object.defineProperty(t,"__esModule",{value:!0})},n.t=function(t,e){if(1&e&&(t=n(t)),8&e)return t;if(4&e&&"object"==typeof t&&t&&t.__esModule)return t;var r=Object.create(null);if(n.r(r),Object.defineProperty(r,"default",{enumerable:!0,value:t}),2&e&&"string"!=typeof t)for(var i in t)n.d(r,i,function(e){return t[e]}.bind(null,i));return r},n.n=function(t){var e=t&&t.__esModule?function(){return t.default}:function(){return t};return n.d(e,"a",e),e},n.o=function(t,e){return Object.prototype.hasOwnProperty.call(t,e)},n.p="",n(n.s=0)}([function(t,e,n){"use strict";Object.defineProperty(e,"__esModule",{value:!0});const r=n(1);var i;!function(t){const e="BlazorExtensions",n={Canvas2d:new r.ContextManager("2d"),WebGL:new r.ContextManager("webgl")};t.initialize=function(){"undefined"==typeof window||window[e]?window[e]=Object.assign({},window[e],n):window[e]=Object.assign({},n)}}(i||(i={})),i.initialize()},function(t,e,n){"use strict";Object.defineProperty(e,"__esModule",{value:!0});e.ContextManager=class{constructor(t){if(this.contexts=new Map,this.webGLObject=new Array,this.webGLContext=!1,this.webGLTypes=[WebGLBuffer,WebGLShader,WebGLProgram,WebGLFramebuffer,WebGLRenderbuffer,WebGLTexture,WebGLUniformLocation],this.add=((t,e)=>{if(!t)throw new Error("Invalid canvas.");if(!this.contexts.get(t.id)){var n;if(!(n=e?t.getContext(this.contextName,e):t.getContext(this.contextName)))throw new Error("Invalid context.");this.contexts.set(t.id,n)}}),this.remove=(t=>{this.contexts.delete(t.id)}),this.setProperty=((t,e,n)=>{const r=this.getContext(t);this.setPropertyWithContext(r,e,n)}),this.getProperty=((t,e)=>{const n=this.getContext(t);return this.serialize(n[e])}),this.call=((t,e,n)=>{const r=this.getContext(t);return this.callWithContext(r,e,n)}),this.callBatch=((t,e)=>{const n=this.getContext(t);for(let t=0;t<e.length;t++){let r=e[t].slice(2);e[t][1]?this.callWithContext(n,e[t][0],r):this.setPropertyWithContext(n,e[t][0],Array.isArray(r)&&r.length>0?r[0]:null)}}),this.callWithContext=((t,e,n)=>this.serialize(this.prototypes[e].apply(t,void 0!=n?n.map(t=>this.deserialize(e,t)):[]))),this.setPropertyWithContext=((t,e,n)=>{t[e]=this.deserialize(e,n)}),this.getContext=(t=>{if(!t)throw new Error("Invalid canvas.");const e=this.contexts.get(t.id);if(!e)throw new Error("Invalid context.");return e}),this.deserialize=((t,e)=>{if(!this.webGLContext||void 0==e)return e;if(e.hasOwnProperty("webGLType")&&e.hasOwnProperty("id"))return this.webGLObject[e.id];if(Array.isArray(e)&&!t.endsWith("v"))return Int8Array.of(...e);if("string"!=typeof e||"bufferData"!==t&&"bufferSubData"!==t)return e;{let t=window.atob(e),r=t.length,i=new Uint8Array(r);for(var n=0;n<r;n++)i[n]=t.charCodeAt(n);return i}}),this.serialize=(t=>{if(t instanceof TextMetrics)return{width:t.width};if(!this.webGLContext||void 0==t)return t;const e=this.webGLTypes.find(e=>t instanceof e);if(void 0!=e){const n=this.webGLObject.length;return this.webGLObject.push(t),{webGLType:e.name,id:n}}return t}),this.contextName=t,"2d"===t)this.prototypes=CanvasRenderingContext2D.prototype;else{if("webgl"!==t&&"experimental-webgl"!==t)throw new Error(`Invalid context name: ${t}`);this.prototypes=WebGLRenderingContext.prototype,this.webGLContext=!0}}}}]);
//# sourceMappingURL=data:application/json;charset=utf-8;base64,eyJ2ZXJzaW9uIjozLCJzb3VyY2VzIjpbIndlYnBhY2s6Ly8vd2VicGFjay9ib290c3RyYXAiLCJ3ZWJwYWNrOi8vLy4vc3JjL0luaXRpYWxpemVDYW52YXMudHMiLCJ3ZWJwYWNrOi8vLy4vc3JjL0NhbnZhc0NvbnRleHRNYW5hZ2VyLnRzIl0sIm5hbWVzIjpbImluc3RhbGxlZE1vZHVsZXMiLCJfX3dlYnBhY2tfcmVxdWlyZV9fIiwibW9kdWxlSWQiLCJleHBvcnRzIiwibW9kdWxlIiwiaSIsImwiLCJtb2R1bGVzIiwiY2FsbCIsIm0iLCJjIiwiZCIsIm5hbWUiLCJnZXR0ZXIiLCJvIiwiT2JqZWN0IiwiZGVmaW5lUHJvcGVydHkiLCJlbnVtZXJhYmxlIiwiZ2V0IiwiciIsIlN5bWJvbCIsInRvU3RyaW5nVGFnIiwidmFsdWUiLCJ0IiwibW9kZSIsIl9fZXNNb2R1bGUiLCJucyIsImNyZWF0ZSIsImtleSIsImJpbmQiLCJuIiwib2JqZWN0IiwicHJvcGVydHkiLCJwcm90b3R5cGUiLCJoYXNPd25Qcm9wZXJ0eSIsInAiLCJzIiwiQ2FudmFzQ29udGV4dE1hbmFnZXJfMSIsIkNhbnZhcyIsImJsYXpvckV4dGVuc2lvbnMiLCJleHRlbnNpb25PYmplY3QiLCJDYW52YXMyZCIsIkNvbnRleHRNYW5hZ2VyIiwiV2ViR0wiLCJpbml0aWFsaXplIiwid2luZG93IiwiYXNzaWduIiwiW29iamVjdCBPYmplY3RdIiwiY29udGV4dE5hbWUiLCJ0aGlzIiwiY29udGV4dHMiLCJNYXAiLCJ3ZWJHTE9iamVjdCIsIkFycmF5Iiwid2ViR0xDb250ZXh0Iiwid2ViR0xUeXBlcyIsIldlYkdMQnVmZmVyIiwiV2ViR0xTaGFkZXIiLCJXZWJHTFByb2dyYW0iLCJXZWJHTEZyYW1lYnVmZmVyIiwiV2ViR0xSZW5kZXJidWZmZXIiLCJXZWJHTFRleHR1cmUiLCJXZWJHTFVuaWZvcm1Mb2NhdGlvbiIsImFkZCIsImNhbnZhcyIsInBhcmFtZXRlcnMiLCJFcnJvciIsImlkIiwiY29udGV4dCIsImdldENvbnRleHQiLCJzZXQiLCJyZW1vdmUiLCJkZWxldGUiLCJzZXRQcm9wZXJ0eSIsInNldFByb3BlcnR5V2l0aENvbnRleHQiLCJnZXRQcm9wZXJ0eSIsInNlcmlhbGl6ZSIsIm1ldGhvZCIsImFyZ3MiLCJjYWxsV2l0aENvbnRleHQiLCJjYWxsQmF0Y2giLCJiYXRjaGVkQ2FsbHMiLCJsZW5ndGgiLCJwYXJhbXMiLCJzbGljZSIsImlzQXJyYXkiLCJwcm90b3R5cGVzIiwiYXBwbHkiLCJ1bmRlZmluZWQiLCJtYXAiLCJkZXNlcmlhbGl6ZSIsImVuZHNXaXRoIiwiSW50OEFycmF5Iiwib2YiLCJiaW5TdHIiLCJhdG9iIiwiYnl0ZXMiLCJVaW50OEFycmF5IiwiY2hhckNvZGVBdCIsIlRleHRNZXRyaWNzIiwid2lkdGgiLCJ0eXBlIiwiZmluZCIsInB1c2giLCJ3ZWJHTFR5cGUiLCJDYW52YXNSZW5kZXJpbmdDb250ZXh0MkQiLCJXZWJHTFJlbmRlcmluZ0NvbnRleHQiXSwibWFwcGluZ3MiOiJhQUNBLElBQUFBLEtBR0EsU0FBQUMsRUFBQUMsR0FHQSxHQUFBRixFQUFBRSxHQUNBLE9BQUFGLEVBQUFFLEdBQUFDLFFBR0EsSUFBQUMsRUFBQUosRUFBQUUsSUFDQUcsRUFBQUgsRUFDQUksR0FBQSxFQUNBSCxZQVVBLE9BTkFJLEVBQUFMLEdBQUFNLEtBQUFKLEVBQUFELFFBQUFDLElBQUFELFFBQUFGLEdBR0FHLEVBQUFFLEdBQUEsRUFHQUYsRUFBQUQsUUFLQUYsRUFBQVEsRUFBQUYsRUFHQU4sRUFBQVMsRUFBQVYsRUFHQUMsRUFBQVUsRUFBQSxTQUFBUixFQUFBUyxFQUFBQyxHQUNBWixFQUFBYSxFQUFBWCxFQUFBUyxJQUNBRyxPQUFBQyxlQUFBYixFQUFBUyxHQUEwQ0ssWUFBQSxFQUFBQyxJQUFBTCxLQUsxQ1osRUFBQWtCLEVBQUEsU0FBQWhCLEdBQ0Esb0JBQUFpQixlQUFBQyxhQUNBTixPQUFBQyxlQUFBYixFQUFBaUIsT0FBQUMsYUFBd0RDLE1BQUEsV0FFeERQLE9BQUFDLGVBQUFiLEVBQUEsY0FBaURtQixPQUFBLEtBUWpEckIsRUFBQXNCLEVBQUEsU0FBQUQsRUFBQUUsR0FFQSxHQURBLEVBQUFBLElBQUFGLEVBQUFyQixFQUFBcUIsSUFDQSxFQUFBRSxFQUFBLE9BQUFGLEVBQ0EsS0FBQUUsR0FBQSxpQkFBQUYsUUFBQUcsV0FBQSxPQUFBSCxFQUNBLElBQUFJLEVBQUFYLE9BQUFZLE9BQUEsTUFHQSxHQUZBMUIsRUFBQWtCLEVBQUFPLEdBQ0FYLE9BQUFDLGVBQUFVLEVBQUEsV0FBeUNULFlBQUEsRUFBQUssVUFDekMsRUFBQUUsR0FBQSxpQkFBQUYsRUFBQSxRQUFBTSxLQUFBTixFQUFBckIsRUFBQVUsRUFBQWUsRUFBQUUsRUFBQSxTQUFBQSxHQUFnSCxPQUFBTixFQUFBTSxJQUFxQkMsS0FBQSxLQUFBRCxJQUNySSxPQUFBRixHQUlBekIsRUFBQTZCLEVBQUEsU0FBQTFCLEdBQ0EsSUFBQVMsRUFBQVQsS0FBQXFCLFdBQ0EsV0FBMkIsT0FBQXJCLEVBQUEsU0FDM0IsV0FBaUMsT0FBQUEsR0FFakMsT0FEQUgsRUFBQVUsRUFBQUUsRUFBQSxJQUFBQSxHQUNBQSxHQUlBWixFQUFBYSxFQUFBLFNBQUFpQixFQUFBQyxHQUFzRCxPQUFBakIsT0FBQWtCLFVBQUFDLGVBQUExQixLQUFBdUIsRUFBQUMsSUFHdEQvQixFQUFBa0MsRUFBQSxHQUlBbEMsSUFBQW1DLEVBQUEsbUZDbEZBLE1BQUFDLEVBQUFwQyxFQUFBLEdBRUEsSUFBVXFDLEdBQVYsU0FBVUEsR0FDUixNQUFNQyxFQUEyQixtQkFFM0JDLEdBQ0pDLFNBQVUsSUFBSUosRUFBQUssZUFBZSxNQUM3QkMsTUFBTyxJQUFJTixFQUFBSyxlQUFlLFVBR1pKLEVBQUFNLFdBQWhCLFdBQ3dCLG9CQUFYQyxRQUEyQkEsT0FBT04sR0FPM0NNLE9BQU9OLEdBQWlCeEIsT0FBQStCLFVBQ25CRCxPQUFPTixHQUNQQyxHQU5MSyxPQUFPTixHQUFpQnhCLE9BQUErQixVQUNuQk4sSUFiWCxDQUFVRixXQXdCVkEsRUFBT00sNEZDMUJQekMsRUFBQXVDLHFCQVVFSyxZQUFtQkMsR0FFakIsR0FYZUMsS0FBQUMsU0FBVyxJQUFJQyxJQUNmRixLQUFBRyxZQUFjLElBQUlDLE1BRTNCSixLQUFBSyxjQUFlLEVBRU5MLEtBQUFNLFlBQ2ZDLFlBQWFDLFlBQWFDLGFBQWNDLGlCQUFrQkMsa0JBQW1CQyxhQUFjQyxzQkFjdEZiLEtBQUFjLElBQU0sRUFBQ0MsRUFBMkJDLEtBQ3ZDLElBQUtELEVBQVEsTUFBTSxJQUFJRSxNQUFNLG1CQUM3QixJQUFJakIsS0FBS0MsU0FBU2hDLElBQUk4QyxFQUFPRyxJQUE3QixDQUVBLElBQUlDLEVBTUosS0FKRUEsRUFERUgsRUFDUUQsRUFBT0ssV0FBV3BCLEtBQUtELFlBQWFpQixHQUVwQ0QsRUFBT0ssV0FBV3BCLEtBQUtELGNBRXJCLE1BQU0sSUFBSWtCLE1BQU0sb0JBRTlCakIsS0FBS0MsU0FBU29CLElBQUlOLEVBQU9HLEdBQUlDLE1BR3hCbkIsS0FBQXNCLE9BQVMsQ0FBQ1AsSUFDZmYsS0FBS0MsU0FBU3NCLE9BQU9SLEVBQU9HLE1BR3ZCbEIsS0FBQXdCLFlBQWMsRUFBQ1QsRUFBMkJoQyxFQUFrQlYsS0FDakUsTUFBTThDLEVBQVVuQixLQUFLb0IsV0FBV0wsR0FDaENmLEtBQUt5Qix1QkFBdUJOLEVBQVNwQyxFQUFVVixLQUcxQzJCLEtBQUEwQixZQUFjLEVBQUNYLEVBQTJCaEMsS0FDL0MsTUFBTW9DLEVBQVVuQixLQUFLb0IsV0FBV0wsR0FDaEMsT0FBT2YsS0FBSzJCLFVBQVVSLEVBQVFwQyxNQUd6QmlCLEtBQUF6QyxLQUFPLEVBQUN3RCxFQUEyQmEsRUFBZ0JDLEtBQ3hELE1BQU1WLEVBQVVuQixLQUFLb0IsV0FBV0wsR0FDaEMsT0FBT2YsS0FBSzhCLGdCQUFnQlgsRUFBU1MsRUFBUUMsS0FHeEM3QixLQUFBK0IsVUFBWSxFQUFDaEIsRUFBMkJpQixLQUM3QyxNQUFNYixFQUFVbkIsS0FBS29CLFdBQVdMLEdBQ2hDLElBQUssSUFBSTNELEVBQUksRUFBR0EsRUFBSTRFLEVBQWFDLE9BQVE3RSxJQUFLLENBQzVDLElBQUk4RSxFQUFTRixFQUFhNUUsR0FBRytFLE1BQU0sR0FDL0JILEVBQWE1RSxHQUFHLEdBQ2xCNEMsS0FBSzhCLGdCQUFnQlgsRUFBU2EsRUFBYTVFLEdBQUcsR0FBSThFLEdBRWxEbEMsS0FBS3lCLHVCQUNITixFQUNBYSxFQUFhNUUsR0FBRyxHQUNoQmdELE1BQU1nQyxRQUFRRixJQUFXQSxFQUFPRCxPQUFTLEVBQUlDLEVBQU8sR0FBSyxTQUt6RGxDLEtBQUE4QixnQkFBa0IsRUFBQ1gsRUFBY1MsRUFBZ0JDLElBQ2hEN0IsS0FBSzJCLFVBQVUzQixLQUFLcUMsV0FBV1QsR0FBUVUsTUFBTW5CLE9BQWlCb0IsR0FBUlYsRUFBb0JBLEVBQUtXLElBQUtuRSxHQUFVMkIsS0FBS3lDLFlBQVliLEVBQVF2RCxVQUd4SDJCLEtBQUF5Qix1QkFBeUIsRUFBQ04sRUFBY3BDLEVBQWtCVixLQUNoRThDLEVBQVFwQyxHQUFZaUIsS0FBS3lDLFlBQVkxRCxFQUFVVixLQUd6QzJCLEtBQUFvQixXQUFhLENBQUNMLElBQ3BCLElBQUtBLEVBQVEsTUFBTSxJQUFJRSxNQUFNLG1CQUU3QixNQUFNRSxFQUFVbkIsS0FBS0MsU0FBU2hDLElBQUk4QyxFQUFPRyxJQUN6QyxJQUFLQyxFQUFTLE1BQU0sSUFBSUYsTUFBTSxvQkFFOUIsT0FBT0UsSUFHRG5CLEtBQUF5QyxZQUFjLEVBQUNiLEVBQWdCOUMsS0FDckMsSUFBS2tCLEtBQUtLLG1CQUEwQmtDLEdBQVZ6RCxFQUFxQixPQUFPQSxFQUV0RCxHQUFJQSxFQUFPRyxlQUFlLGNBQWdCSCxFQUFPRyxlQUFlLE1BQzlELE9BQVFlLEtBQUtHLFlBQVlyQixFQUFXLElBQy9CLEdBQUlzQixNQUFNZ0MsUUFBUXRELEtBQVk4QyxFQUFPYyxTQUFTLEtBQ25ELE9BQU9DLFVBQVVDLE1BQU85RCxHQUNuQixHQUF1QixpQkFBYixHQUFxQyxlQUFYOEMsR0FBc0Msa0JBQVhBLEVBU3BFLE9BQU85QyxFQVQwRixDQUNqRyxJQUFJK0QsRUFBU2pELE9BQU9rRCxLQUFLaEUsR0FDckJtRCxFQUFTWSxFQUFPWixPQUNoQmMsRUFBUSxJQUFJQyxXQUFXZixHQUMzQixJQUFLLElBQUk3RSxFQUFJLEVBQUdBLEVBQUk2RSxFQUFRN0UsSUFDeEIyRixFQUFNM0YsR0FBS3lGLEVBQU9JLFdBQVc3RixHQUVqQyxPQUFPMkYsS0FLSC9DLEtBQUEyQixVQUFZLENBQUM3QyxJQUNuQixHQUFJQSxhQUFrQm9FLFlBQ2xCLE9BQVNDLE1BQU9yRSxFQUFPcUUsT0FHM0IsSUFBS25ELEtBQUtLLG1CQUEwQmtDLEdBQVZ6RCxFQUFxQixPQUFPQSxFQUV0RCxNQUFNc0UsRUFBT3BELEtBQUtNLFdBQVcrQyxLQUFNRCxHQUFTdEUsYUFBa0JzRSxHQUM5RCxRQUFZYixHQUFSYSxFQUFtQixDQUNyQixNQUFNbEMsRUFBS2xCLEtBQUtHLFlBQVk4QixPQUc1QixPQUZBakMsS0FBS0csWUFBWW1ELEtBQUt4RSxJQUdwQnlFLFVBQVdILEVBQUt6RixLQUNoQnVELEdBQUlBLEdBR04sT0FBT3BDLElBaEhUa0IsS0FBS0QsWUFBY0EsRUFDQyxPQUFoQkEsRUFDRkMsS0FBS3FDLFdBQWFtQix5QkFBeUJ4RSxjQUN4QyxJQUFvQixVQUFoQmUsR0FBMkMsdUJBQWhCQSxFQUlsQyxNQUFNLElBQUlrQiwrQkFBK0JsQixLQUh6Q0MsS0FBS3FDLFdBQWFvQixzQkFBc0J6RSxVQUN4Q2dCLEtBQUtLLGNBQWUiLCJmaWxlIjoiYmxhem9yLmV4dGVuc2lvbnMuY2FudmFzLmpzIiwic291cmNlc0NvbnRlbnQiOlsiIFx0Ly8gVGhlIG1vZHVsZSBjYWNoZVxuIFx0dmFyIGluc3RhbGxlZE1vZHVsZXMgPSB7fTtcblxuIFx0Ly8gVGhlIHJlcXVpcmUgZnVuY3Rpb25cbiBcdGZ1bmN0aW9uIF9fd2VicGFja19yZXF1aXJlX18obW9kdWxlSWQpIHtcblxuIFx0XHQvLyBDaGVjayBpZiBtb2R1bGUgaXMgaW4gY2FjaGVcbiBcdFx0aWYoaW5zdGFsbGVkTW9kdWxlc1ttb2R1bGVJZF0pIHtcbiBcdFx0XHRyZXR1cm4gaW5zdGFsbGVkTW9kdWxlc1ttb2R1bGVJZF0uZXhwb3J0cztcbiBcdFx0fVxuIFx0XHQvLyBDcmVhdGUgYSBuZXcgbW9kdWxlIChhbmQgcHV0IGl0IGludG8gdGhlIGNhY2hlKVxuIFx0XHR2YXIgbW9kdWxlID0gaW5zdGFsbGVkTW9kdWxlc1ttb2R1bGVJZF0gPSB7XG4gXHRcdFx0aTogbW9kdWxlSWQsXG4gXHRcdFx0bDogZmFsc2UsXG4gXHRcdFx0ZXhwb3J0czoge31cbiBcdFx0fTtcblxuIFx0XHQvLyBFeGVjdXRlIHRoZSBtb2R1bGUgZnVuY3Rpb25cbiBcdFx0bW9kdWxlc1ttb2R1bGVJZF0uY2FsbChtb2R1bGUuZXhwb3J0cywgbW9kdWxlLCBtb2R1bGUuZXhwb3J0cywgX193ZWJwYWNrX3JlcXVpcmVfXyk7XG5cbiBcdFx0Ly8gRmxhZyB0aGUgbW9kdWxlIGFzIGxvYWRlZFxuIFx0XHRtb2R1bGUubCA9IHRydWU7XG5cbiBcdFx0Ly8gUmV0dXJuIHRoZSBleHBvcnRzIG9mIHRoZSBtb2R1bGVcbiBcdFx0cmV0dXJuIG1vZHVsZS5leHBvcnRzO1xuIFx0fVxuXG5cbiBcdC8vIGV4cG9zZSB0aGUgbW9kdWxlcyBvYmplY3QgKF9fd2VicGFja19tb2R1bGVzX18pXG4gXHRfX3dlYnBhY2tfcmVxdWlyZV9fLm0gPSBtb2R1bGVzO1xuXG4gXHQvLyBleHBvc2UgdGhlIG1vZHVsZSBjYWNoZVxuIFx0X193ZWJwYWNrX3JlcXVpcmVfXy5jID0gaW5zdGFsbGVkTW9kdWxlcztcblxuIFx0Ly8gZGVmaW5lIGdldHRlciBmdW5jdGlvbiBmb3IgaGFybW9ueSBleHBvcnRzXG4gXHRfX3dlYnBhY2tfcmVxdWlyZV9fLmQgPSBmdW5jdGlvbihleHBvcnRzLCBuYW1lLCBnZXR0ZXIpIHtcbiBcdFx0aWYoIV9fd2VicGFja19yZXF1aXJlX18ubyhleHBvcnRzLCBuYW1lKSkge1xuIFx0XHRcdE9iamVjdC5kZWZpbmVQcm9wZXJ0eShleHBvcnRzLCBuYW1lLCB7IGVudW1lcmFibGU6IHRydWUsIGdldDogZ2V0dGVyIH0pO1xuIFx0XHR9XG4gXHR9O1xuXG4gXHQvLyBkZWZpbmUgX19lc01vZHVsZSBvbiBleHBvcnRzXG4gXHRfX3dlYnBhY2tfcmVxdWlyZV9fLnIgPSBmdW5jdGlvbihleHBvcnRzKSB7XG4gXHRcdGlmKHR5cGVvZiBTeW1ib2wgIT09ICd1bmRlZmluZWQnICYmIFN5bWJvbC50b1N0cmluZ1RhZykge1xuIFx0XHRcdE9iamVjdC5kZWZpbmVQcm9wZXJ0eShleHBvcnRzLCBTeW1ib2wudG9TdHJpbmdUYWcsIHsgdmFsdWU6ICdNb2R1bGUnIH0pO1xuIFx0XHR9XG4gXHRcdE9iamVjdC5kZWZpbmVQcm9wZXJ0eShleHBvcnRzLCAnX19lc01vZHVsZScsIHsgdmFsdWU6IHRydWUgfSk7XG4gXHR9O1xuXG4gXHQvLyBjcmVhdGUgYSBmYWtlIG5hbWVzcGFjZSBvYmplY3RcbiBcdC8vIG1vZGUgJiAxOiB2YWx1ZSBpcyBhIG1vZHVsZSBpZCwgcmVxdWlyZSBpdFxuIFx0Ly8gbW9kZSAmIDI6IG1lcmdlIGFsbCBwcm9wZXJ0aWVzIG9mIHZhbHVlIGludG8gdGhlIG5zXG4gXHQvLyBtb2RlICYgNDogcmV0dXJuIHZhbHVlIHdoZW4gYWxyZWFkeSBucyBvYmplY3RcbiBcdC8vIG1vZGUgJiA4fDE6IGJlaGF2ZSBsaWtlIHJlcXVpcmVcbiBcdF9fd2VicGFja19yZXF1aXJlX18udCA9IGZ1bmN0aW9uKHZhbHVlLCBtb2RlKSB7XG4gXHRcdGlmKG1vZGUgJiAxKSB2YWx1ZSA9IF9fd2VicGFja19yZXF1aXJlX18odmFsdWUpO1xuIFx0XHRpZihtb2RlICYgOCkgcmV0dXJuIHZhbHVlO1xuIFx0XHRpZigobW9kZSAmIDQpICYmIHR5cGVvZiB2YWx1ZSA9PT0gJ29iamVjdCcgJiYgdmFsdWUgJiYgdmFsdWUuX19lc01vZHVsZSkgcmV0dXJuIHZhbHVlO1xuIFx0XHR2YXIgbnMgPSBPYmplY3QuY3JlYXRlKG51bGwpO1xuIFx0XHRfX3dlYnBhY2tfcmVxdWlyZV9fLnIobnMpO1xuIFx0XHRPYmplY3QuZGVmaW5lUHJvcGVydHkobnMsICdkZWZhdWx0JywgeyBlbnVtZXJhYmxlOiB0cnVlLCB2YWx1ZTogdmFsdWUgfSk7XG4gXHRcdGlmKG1vZGUgJiAyICYmIHR5cGVvZiB2YWx1ZSAhPSAnc3RyaW5nJykgZm9yKHZhciBrZXkgaW4gdmFsdWUpIF9fd2VicGFja19yZXF1aXJlX18uZChucywga2V5LCBmdW5jdGlvbihrZXkpIHsgcmV0dXJuIHZhbHVlW2tleV07IH0uYmluZChudWxsLCBrZXkpKTtcbiBcdFx0cmV0dXJuIG5zO1xuIFx0fTtcblxuIFx0Ly8gZ2V0RGVmYXVsdEV4cG9ydCBmdW5jdGlvbiBmb3IgY29tcGF0aWJpbGl0eSB3aXRoIG5vbi1oYXJtb255IG1vZHVsZXNcbiBcdF9fd2VicGFja19yZXF1aXJlX18ubiA9IGZ1bmN0aW9uKG1vZHVsZSkge1xuIFx0XHR2YXIgZ2V0dGVyID0gbW9kdWxlICYmIG1vZHVsZS5fX2VzTW9kdWxlID9cbiBcdFx0XHRmdW5jdGlvbiBnZXREZWZhdWx0KCkgeyByZXR1cm4gbW9kdWxlWydkZWZhdWx0J107IH0gOlxuIFx0XHRcdGZ1bmN0aW9uIGdldE1vZHVsZUV4cG9ydHMoKSB7IHJldHVybiBtb2R1bGU7IH07XG4gXHRcdF9fd2VicGFja19yZXF1aXJlX18uZChnZXR0ZXIsICdhJywgZ2V0dGVyKTtcbiBcdFx0cmV0dXJuIGdldHRlcjtcbiBcdH07XG5cbiBcdC8vIE9iamVjdC5wcm90b3R5cGUuaGFzT3duUHJvcGVydHkuY2FsbFxuIFx0X193ZWJwYWNrX3JlcXVpcmVfXy5vID0gZnVuY3Rpb24ob2JqZWN0LCBwcm9wZXJ0eSkgeyByZXR1cm4gT2JqZWN0LnByb3RvdHlwZS5oYXNPd25Qcm9wZXJ0eS5jYWxsKG9iamVjdCwgcHJvcGVydHkpOyB9O1xuXG4gXHQvLyBfX3dlYnBhY2tfcHVibGljX3BhdGhfX1xuIFx0X193ZWJwYWNrX3JlcXVpcmVfXy5wID0gXCJcIjtcblxuXG4gXHQvLyBMb2FkIGVudHJ5IG1vZHVsZSBhbmQgcmV0dXJuIGV4cG9ydHNcbiBcdHJldHVybiBfX3dlYnBhY2tfcmVxdWlyZV9fKF9fd2VicGFja19yZXF1aXJlX18ucyA9IDApO1xuIiwiaW1wb3J0IHsgQ29udGV4dE1hbmFnZXIgfSBmcm9tICcuL0NhbnZhc0NvbnRleHRNYW5hZ2VyJztcblxubmFtZXNwYWNlIENhbnZhcyB7XG4gIGNvbnN0IGJsYXpvckV4dGVuc2lvbnM6IHN0cmluZyA9ICdCbGF6b3JFeHRlbnNpb25zJztcbiAgLy8gZGVmaW5lIHdoYXQgdGhpcyBleHRlbnNpb24gYWRkcyB0byB0aGUgd2luZG93IG9iamVjdCBpbnNpZGUgQmxhem9yRXh0ZW5zaW9uc1xuICBjb25zdCBleHRlbnNpb25PYmplY3QgPSB7XG4gICAgQ2FudmFzMmQ6IG5ldyBDb250ZXh0TWFuYWdlcihcIjJkXCIpLFxuICAgIFdlYkdMOiBuZXcgQ29udGV4dE1hbmFnZXIoXCJ3ZWJnbFwiKVxuICB9O1xuXG4gIGV4cG9ydCBmdW5jdGlvbiBpbml0aWFsaXplKCk6IHZvaWQge1xuICAgIGlmICh0eXBlb2Ygd2luZG93ICE9PSAndW5kZWZpbmVkJyAmJiAhd2luZG93W2JsYXpvckV4dGVuc2lvbnNdKSB7XG4gICAgICAvLyB3aGVuIHRoZSBsaWJyYXJ5IGlzIGxvYWRlZCBpbiBhIGJyb3dzZXIgdmlhIGEgPHNjcmlwdD4gZWxlbWVudCwgbWFrZSB0aGVcbiAgICAgIC8vIGZvbGxvd2luZyBBUElzIGF2YWlsYWJsZSBpbiBnbG9iYWwgc2NvcGUgZm9yIGludm9jYXRpb24gZnJvbSBKU1xuICAgICAgd2luZG93W2JsYXpvckV4dGVuc2lvbnNdID0ge1xuICAgICAgICAuLi5leHRlbnNpb25PYmplY3RcbiAgICAgIH07XG4gICAgfSBlbHNlIHtcbiAgICAgIHdpbmRvd1tibGF6b3JFeHRlbnNpb25zXSA9IHtcbiAgICAgICAgLi4ud2luZG93W2JsYXpvckV4dGVuc2lvbnNdLFxuICAgICAgICAuLi5leHRlbnNpb25PYmplY3RcbiAgICAgIH07XG4gICAgfVxuICB9XG59XG5cbkNhbnZhcy5pbml0aWFsaXplKCk7XG4iLCJleHBvcnQgY2xhc3MgQ29udGV4dE1hbmFnZXIge1xuICBwcml2YXRlIHJlYWRvbmx5IGNvbnRleHRzID0gbmV3IE1hcDxzdHJpbmcsIGFueT4oKTtcbiAgcHJpdmF0ZSByZWFkb25seSB3ZWJHTE9iamVjdCA9IG5ldyBBcnJheTxhbnk+KCk7XG4gIHByaXZhdGUgcmVhZG9ubHkgY29udGV4dE5hbWU6IHN0cmluZztcbiAgcHJpdmF0ZSB3ZWJHTENvbnRleHQgPSBmYWxzZTtcbiAgcHJpdmF0ZSByZWFkb25seSBwcm90b3R5cGVzOiBhbnk7XG4gIHByaXZhdGUgcmVhZG9ubHkgd2ViR0xUeXBlcyA9IFtcbiAgICBXZWJHTEJ1ZmZlciwgV2ViR0xTaGFkZXIsIFdlYkdMUHJvZ3JhbSwgV2ViR0xGcmFtZWJ1ZmZlciwgV2ViR0xSZW5kZXJidWZmZXIsIFdlYkdMVGV4dHVyZSwgV2ViR0xVbmlmb3JtTG9jYXRpb25cbiAgXTtcblxuICBwdWJsaWMgY29uc3RydWN0b3IoY29udGV4dE5hbWU6IHN0cmluZykge1xuICAgIHRoaXMuY29udGV4dE5hbWUgPSBjb250ZXh0TmFtZTtcbiAgICBpZiAoY29udGV4dE5hbWUgPT09IFwiMmRcIilcbiAgICAgIHRoaXMucHJvdG90eXBlcyA9IENhbnZhc1JlbmRlcmluZ0NvbnRleHQyRC5wcm90b3R5cGU7XG4gICAgZWxzZSBpZiAoY29udGV4dE5hbWUgPT09IFwid2ViZ2xcIiB8fCBjb250ZXh0TmFtZSA9PT0gXCJleHBlcmltZW50YWwtd2ViZ2xcIikge1xuICAgICAgdGhpcy5wcm90b3R5cGVzID0gV2ViR0xSZW5kZXJpbmdDb250ZXh0LnByb3RvdHlwZTtcbiAgICAgIHRoaXMud2ViR0xDb250ZXh0ID0gdHJ1ZTtcbiAgICB9IGVsc2VcbiAgICAgIHRocm93IG5ldyBFcnJvcihgSW52YWxpZCBjb250ZXh0IG5hbWU6ICR7Y29udGV4dE5hbWV9YCk7XG4gIH1cblxuICBwdWJsaWMgYWRkID0gKGNhbnZhczogSFRNTENhbnZhc0VsZW1lbnQsIHBhcmFtZXRlcnM6IGFueSkgPT4ge1xuICAgIGlmICghY2FudmFzKSB0aHJvdyBuZXcgRXJyb3IoJ0ludmFsaWQgY2FudmFzLicpO1xuICAgIGlmICh0aGlzLmNvbnRleHRzLmdldChjYW52YXMuaWQpKSByZXR1cm47XG5cbiAgICB2YXIgY29udGV4dDtcbiAgICBpZiAocGFyYW1ldGVycylcbiAgICAgIGNvbnRleHQgPSBjYW52YXMuZ2V0Q29udGV4dCh0aGlzLmNvbnRleHROYW1lLCBwYXJhbWV0ZXJzKTtcbiAgICBlbHNlXG4gICAgICBjb250ZXh0ID0gY2FudmFzLmdldENvbnRleHQodGhpcy5jb250ZXh0TmFtZSk7XG5cbiAgICBpZiAoIWNvbnRleHQpIHRocm93IG5ldyBFcnJvcignSW52YWxpZCBjb250ZXh0LicpO1xuXG4gICAgdGhpcy5jb250ZXh0cy5zZXQoY2FudmFzLmlkLCBjb250ZXh0KTtcbiAgfVxuXG4gIHB1YmxpYyByZW1vdmUgPSAoY2FudmFzOiBIVE1MQ2FudmFzRWxlbWVudCkgPT4ge1xuICAgIHRoaXMuY29udGV4dHMuZGVsZXRlKGNhbnZhcy5pZCk7XG4gIH1cblxuICBwdWJsaWMgc2V0UHJvcGVydHkgPSAoY2FudmFzOiBIVE1MQ2FudmFzRWxlbWVudCwgcHJvcGVydHk6IHN0cmluZywgdmFsdWU6IGFueSkgPT4ge1xuICAgIGNvbnN0IGNvbnRleHQgPSB0aGlzLmdldENvbnRleHQoY2FudmFzKTtcbiAgICB0aGlzLnNldFByb3BlcnR5V2l0aENvbnRleHQoY29udGV4dCwgcHJvcGVydHksIHZhbHVlKTtcbiAgfVxuXG4gIHB1YmxpYyBnZXRQcm9wZXJ0eSA9IChjYW52YXM6IEhUTUxDYW52YXNFbGVtZW50LCBwcm9wZXJ0eTogc3RyaW5nKSA9PiB7XG4gICAgY29uc3QgY29udGV4dCA9IHRoaXMuZ2V0Q29udGV4dChjYW52YXMpO1xuICAgIHJldHVybiB0aGlzLnNlcmlhbGl6ZShjb250ZXh0W3Byb3BlcnR5XSk7XG4gIH1cblxuICBwdWJsaWMgY2FsbCA9IChjYW52YXM6IEhUTUxDYW52YXNFbGVtZW50LCBtZXRob2Q6IHN0cmluZywgYXJnczogYW55KSA9PiB7XG4gICAgY29uc3QgY29udGV4dCA9IHRoaXMuZ2V0Q29udGV4dChjYW52YXMpO1xuICAgIHJldHVybiB0aGlzLmNhbGxXaXRoQ29udGV4dChjb250ZXh0LCBtZXRob2QsIGFyZ3MpO1xuICB9XG5cbiAgcHVibGljIGNhbGxCYXRjaCA9IChjYW52YXM6IEhUTUxDYW52YXNFbGVtZW50LCBiYXRjaGVkQ2FsbHM6IGFueVtdW10pID0+IHtcbiAgICBjb25zdCBjb250ZXh0ID0gdGhpcy5nZXRDb250ZXh0KGNhbnZhcyk7XG4gICAgZm9yIChsZXQgaSA9IDA7IGkgPCBiYXRjaGVkQ2FsbHMubGVuZ3RoOyBpKyspIHtcbiAgICAgIGxldCBwYXJhbXMgPSBiYXRjaGVkQ2FsbHNbaV0uc2xpY2UoMik7XG4gICAgICBpZiAoYmF0Y2hlZENhbGxzW2ldWzFdKSB7XG4gICAgICAgIHRoaXMuY2FsbFdpdGhDb250ZXh0KGNvbnRleHQsIGJhdGNoZWRDYWxsc1tpXVswXSwgcGFyYW1zKTtcbiAgICAgIH0gZWxzZSB7XG4gICAgICAgIHRoaXMuc2V0UHJvcGVydHlXaXRoQ29udGV4dChcbiAgICAgICAgICBjb250ZXh0LFxuICAgICAgICAgIGJhdGNoZWRDYWxsc1tpXVswXSxcbiAgICAgICAgICBBcnJheS5pc0FycmF5KHBhcmFtcykgJiYgcGFyYW1zLmxlbmd0aCA+IDAgPyBwYXJhbXNbMF0gOiBudWxsKTtcbiAgICAgIH1cbiAgICB9XG4gIH1cblxuICBwcml2YXRlIGNhbGxXaXRoQ29udGV4dCA9IChjb250ZXh0OiBhbnksIG1ldGhvZDogc3RyaW5nLCBhcmdzOiBhbnkpID0+IHtcbiAgICByZXR1cm4gdGhpcy5zZXJpYWxpemUodGhpcy5wcm90b3R5cGVzW21ldGhvZF0uYXBwbHkoY29udGV4dCwgYXJncyAhPSB1bmRlZmluZWQgPyBhcmdzLm1hcCgodmFsdWUpID0+IHRoaXMuZGVzZXJpYWxpemUobWV0aG9kLCB2YWx1ZSkpIDogW10pKTtcbiAgfVxuXG4gIHByaXZhdGUgc2V0UHJvcGVydHlXaXRoQ29udGV4dCA9IChjb250ZXh0OiBhbnksIHByb3BlcnR5OiBzdHJpbmcsIHZhbHVlOiBhbnkpID0+IHtcbiAgICBjb250ZXh0W3Byb3BlcnR5XSA9IHRoaXMuZGVzZXJpYWxpemUocHJvcGVydHksIHZhbHVlKTtcbiAgfVxuXG4gIHByaXZhdGUgZ2V0Q29udGV4dCA9IChjYW52YXM6IEhUTUxDYW52YXNFbGVtZW50KSA9PiB7XG4gICAgaWYgKCFjYW52YXMpIHRocm93IG5ldyBFcnJvcignSW52YWxpZCBjYW52YXMuJyk7XG5cbiAgICBjb25zdCBjb250ZXh0ID0gdGhpcy5jb250ZXh0cy5nZXQoY2FudmFzLmlkKTtcbiAgICBpZiAoIWNvbnRleHQpIHRocm93IG5ldyBFcnJvcignSW52YWxpZCBjb250ZXh0LicpO1xuXG4gICAgcmV0dXJuIGNvbnRleHQ7XG4gIH1cblxuICBwcml2YXRlIGRlc2VyaWFsaXplID0gKG1ldGhvZDogc3RyaW5nLCBvYmplY3Q6IGFueSkgPT4ge1xuICAgIGlmICghdGhpcy53ZWJHTENvbnRleHQgfHwgb2JqZWN0ID09IHVuZGVmaW5lZCkgcmV0dXJuIG9iamVjdDsgLy9kZXNlcmlhbGl6YXRpb24gb25seSBuZWVkcyB0byBoYXBwZW4gZm9yIHdlYkdMXG5cbiAgICBpZiAob2JqZWN0Lmhhc093blByb3BlcnR5KFwid2ViR0xUeXBlXCIpICYmIG9iamVjdC5oYXNPd25Qcm9wZXJ0eShcImlkXCIpKSB7XG4gICAgICByZXR1cm4gKHRoaXMud2ViR0xPYmplY3Rbb2JqZWN0W1wiaWRcIl1dKTtcbiAgICB9IGVsc2UgaWYgKEFycmF5LmlzQXJyYXkob2JqZWN0KSAmJiAhbWV0aG9kLmVuZHNXaXRoKFwidlwiKSkge1xuICAgICAgcmV0dXJuIEludDhBcnJheS5vZiguLi4ob2JqZWN0IGFzIG51bWJlcltdKSk7XG4gICAgfSBlbHNlIGlmICh0eXBlb2Yob2JqZWN0KSA9PT0gXCJzdHJpbmdcIiAmJiAobWV0aG9kID09PSBcImJ1ZmZlckRhdGFcIiB8fCBtZXRob2QgPT09IFwiYnVmZmVyU3ViRGF0YVwiKSkge1xuICAgICAgbGV0IGJpblN0ciA9IHdpbmRvdy5hdG9iKG9iamVjdCk7XG4gICAgICBsZXQgbGVuZ3RoID0gYmluU3RyLmxlbmd0aDtcbiAgICAgIGxldCBieXRlcyA9IG5ldyBVaW50OEFycmF5KGxlbmd0aCk7XG4gICAgICBmb3IgKHZhciBpID0gMDsgaSA8IGxlbmd0aDsgaSsrKSB7XG4gICAgICAgICAgYnl0ZXNbaV0gPSBiaW5TdHIuY2hhckNvZGVBdChpKTtcbiAgICAgIH1cbiAgICAgIHJldHVybiBieXRlcztcbiAgICB9IGVsc2VcbiAgICAgIHJldHVybiBvYmplY3Q7XG4gIH1cblxuICBwcml2YXRlIHNlcmlhbGl6ZSA9IChvYmplY3Q6IGFueSkgPT4ge1xuICAgIGlmIChvYmplY3QgaW5zdGFuY2VvZiBUZXh0TWV0cmljcykge1xuICAgICAgICByZXR1cm4geyB3aWR0aDogb2JqZWN0LndpZHRoIH07XG4gICAgfVxuXG4gICAgaWYgKCF0aGlzLndlYkdMQ29udGV4dCB8fCBvYmplY3QgPT0gdW5kZWZpbmVkKSByZXR1cm4gb2JqZWN0OyAvL3NlcmlhbGl6YXRpb24gb25seSBuZWVkcyB0byBoYXBwZW4gZm9yIHdlYkdMXG5cbiAgICBjb25zdCB0eXBlID0gdGhpcy53ZWJHTFR5cGVzLmZpbmQoKHR5cGUpID0+IG9iamVjdCBpbnN0YW5jZW9mIHR5cGUpO1xuICAgIGlmICh0eXBlICE9IHVuZGVmaW5lZCkge1xuICAgICAgY29uc3QgaWQgPSB0aGlzLndlYkdMT2JqZWN0Lmxlbmd0aDtcbiAgICAgIHRoaXMud2ViR0xPYmplY3QucHVzaChvYmplY3QpO1xuXG4gICAgICByZXR1cm4ge1xuICAgICAgICB3ZWJHTFR5cGU6IHR5cGUubmFtZSxcbiAgICAgICAgaWQ6IGlkXG4gICAgICAgIH07XG4gICAgfSBlbHNlXG4gICAgICByZXR1cm4gb2JqZWN0O1xuICB9XG59XG4iXSwic291cmNlUm9vdCI6IiJ9 