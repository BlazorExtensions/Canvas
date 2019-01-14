export class ContextManager<TRenderingContext extends (WebGLRenderingContext | CanvasRenderingContext2D)> {
  private _contexts: Map<string, TRenderingContext> = new Map<string, TRenderingContext>();
  private _contextName: string;
  private _prototypes: (WebGLRenderingContext | CanvasRenderingContext2D);

  public constructor(contextName: string) {
    this._contextName = contextName;
    if (contextName === "2d")
      this._prototypes = CanvasRenderingContext2D.prototype;
    else if (contextName === "webgl" || contextName === "experimental-webgl")
      this._prototypes = WebGLRenderingContext.prototype;
    else
      throw new Error(`Invalid context name: ${contextName}`);
  }

  public Add = (canvas: HTMLCanvasElement) => {
    if (!canvas) throw new Error('Invalid canvas.');
    if (this._contexts.get(canvas.id)) return;

    const context = canvas.getContext(this._contextName);

    if (!context) throw new Error('Invalid context.');

    this._contexts.set(canvas.id, context as TRenderingContext);
  }

  public Remove = (canvas: HTMLCanvasElement) => {
    this._contexts.delete(canvas.id);
  }

  public SetProperty = (canvas: HTMLCanvasElement, property: string, value: any) => {
    const context = this.GetContext(canvas);
    context[property] = value;
  }

  public Call = (canvas: HTMLCanvasElement, method: string, args: any) => {
    const context = this.GetContext(canvas);
    return this._prototypes[method].apply(context, args);
  }

  private GetContext = (canvas: HTMLCanvasElement) => {
    if (!canvas) throw new Error('Invalid canvas.');

    const context = this._contexts.get(canvas.id);
    if (!context) throw new Error('Invalid context.');

    return context;
  }
}
