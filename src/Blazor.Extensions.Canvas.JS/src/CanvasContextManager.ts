export class ContextManager {
  private readonly contexts = new Map<string, any>();
  private readonly webGLObject = new Map<string, Map<number, any>>();
  private readonly contextName: string;
  private readonly prototypes: any;
  private readonly webGLTypes = [
    WebGLBuffer, WebGLShader, WebGLProgram, WebGLFramebuffer, WebGLRenderbuffer, WebGLTexture, WebGLUniformLocation
  ];

  public constructor(contextName: string) {
    this.contextName = contextName;
    if (contextName === "2d")
      this.prototypes = CanvasRenderingContext2D.prototype;
    else if (contextName === "webgl" || contextName === "experimental-webgl")
      this.prototypes = WebGLRenderingContext.prototype;
    else
      throw new Error(`Invalid context name: ${contextName}`);

    this.webGLTypes.forEach((type) => this.webGLObject.set(type.name, new Map<number, any>()));
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
    context[property] = value;
    context[property] = this.deserialize(value);
  }

  public getProperty = (canvas: HTMLCanvasElement, property: string) => {
    const context = this.getContext(canvas);
    return this.serialize(context[property]);
  }

  public call = (canvas: HTMLCanvasElement, method: string, args: any) => {
    console.log("calling: " + method);
    const context = this.getContext(canvas);
    return this.serialize(this.prototypes[method].apply(context, args != undefined ? args.map((value) => this.deserialize(value)) : []));
  }

  private getContext = (canvas: HTMLCanvasElement) => {
    if (!canvas) throw new Error('Invalid canvas.');

    const context = this.contexts.get(canvas.id);
    if (!context) throw new Error('Invalid context.');

    return context;
  }

  private deserialize = (object: any) => {
    console.log("argument: " + JSON.stringify(object));

    if (object.hasOwnProperty("webGLType") && object.hasOwnProperty("id")) {
      return (this.webGLObject.get(object["webGLType"]) as Map<number, any>).get(object["id"]);
    } else if (Array.isArray(object)) {
      return Float32Array.of(...(object as number[]));
    } else
      return object;
  }

  private serialize = (object: any) => {
    const type = this.webGLTypes.find((type) => object instanceof type);
    if (type != undefined) {
      const objectMap = this.webGLObject.get(type.name) as Map<number, any>;
      const id = objectMap.size;
      objectMap.set(id, object);

      return {
        webGLType: type.name,
        id: id
      };
    } else
      return object;
  }
}
