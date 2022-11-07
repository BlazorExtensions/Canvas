import { v4 as uuidv4 } from 'uuid';

export class ContextManager {
  private readonly contexts = new Map<string, any>();
  private readonly webGLObject = new Array<any>();
  private readonly contextName: string;
  private webGLContext = false;
  private readonly prototypes: any;

  private readonly patterns = new Map<string, any>();

  private readonly webGLTypes = [
    WebGLBuffer, WebGLShader, WebGLProgram, WebGLFramebuffer, WebGLRenderbuffer, WebGLTexture, WebGLUniformLocation
  ];

  public constructor(contextName: string) {
    this.contextName = contextName;
    if (contextName === "2d")
      this.prototypes = CanvasRenderingContext2D.prototype;
    else if (contextName === "webgl" || contextName === "experimental-webgl") {
      this.prototypes = WebGLRenderingContext.prototype;
      this.webGLContext = true;
    } else
      throw new Error(`Invalid context name: ${contextName}`);
  }

  public add = (canvas: HTMLCanvasElement, parameters: any) => {
    if (!canvas) throw new Error('Invalid canvas.');
    if (this.contexts.get(canvas.id)) return;

    var context;
    if (parameters)
      context = canvas.getContext(this.contextName, parameters);
    else
      context = canvas.getContext(this.contextName);

    if (!context) throw new Error('Invalid context.');

    this.contexts.set(canvas.id, context);
  }

  public remove = (canvas: HTMLCanvasElement) => {
    this.contexts.delete(canvas.id);
  }

  public setProperty = (canvas: HTMLCanvasElement, property: string, value: any) => {
    const context = this.getContext(canvas);
    this.setPropertyWithContext(context, property, value);
  }

  public getProperty = (canvas: HTMLCanvasElement, property: string) => {
    const context = this.getContext(canvas);
    return this.serialize(context[property]);
  }

  public call = (canvas: HTMLCanvasElement, method: string, args: any) => {
    const context = this.getContext(canvas);
    return this.callWithContext(context, method, args);
  }

  public callBatch = (canvas: HTMLCanvasElement, batchedCalls: any[][]) => {
    const context = this.getContext(canvas);
    for (let i = 0; i < batchedCalls.length; i++) {
      let params = batchedCalls[i].slice(2);
      if (batchedCalls[i][1]) {
        this.callWithContext(context, batchedCalls[i][0], params);
      } else {
        this.setPropertyWithContext(
          context,
          batchedCalls[i][0],
          Array.isArray(params) && params.length > 0 ? params[0] : null);
      }
    }
  }

  private callWithContext = (context: any, method: string, args: any) => {
    const result = this.prototypes[method].apply(context, args != undefined ? args.map((value) => this.deserialize(method, value)) : []);

    if (method == 'createPattern') {
      const key = uuidv4(); 
      this.patterns.set(key, result);
      return key;
    }

    return this.serialize(result);
  }

  private setPropertyWithContext = (context: any, property: string, value: any) => {

    if (property == 'fillStyle') {
      value = this.patterns.get(value) || value;
    }

    context[property] = this.deserialize(property, value);
  }

  private getContext = (canvas: HTMLCanvasElement) => {
    if (!canvas) throw new Error('Invalid canvas.');

    const context = this.contexts.get(canvas.id);
    if (!context) throw new Error('Invalid context.');

    return context;
  }

  private deserialize = (method: string, object: any) => {
    if (!this.webGLContext || object == undefined) return object; //deserialization only needs to happen for webGL

    if (object.hasOwnProperty("webGLType") && object.hasOwnProperty("id")) {
      return (this.webGLObject[object["id"]]);
    } else if (Array.isArray(object) && !method.endsWith("v")) {
      return Int8Array.of(...(object as number[]));
    } else if (typeof(object) === "string" && (method === "bufferData" || method === "bufferSubData")) {
      let binStr = window.atob(object);
      let length = binStr.length;
      let bytes = new Uint8Array(length);
      for (var i = 0; i < length; i++) {
          bytes[i] = binStr.charCodeAt(i);
      }
      return bytes;
    } else
      return object;
  }

  private serialize = (object: any) => {
    if (object instanceof TextMetrics) {
        return { width: object.width };
    }

    if (!this.webGLContext || object == undefined) return object; //serialization only needs to happen for webGL

    const type = this.webGLTypes.find((type) => object instanceof type);
    if (type != undefined) {
      const id = this.webGLObject.length;
      this.webGLObject.push(object);

      return {
        webGLType: type.name,
        id: id
        };
    } else
      return object;
  }
}
