export class ContextManager {
  private readonly contexts = new Map<string, any>();
  private readonly contextName: string;
  private readonly prototypes: any;

  public constructor(contextName: string) {
    this.contextName = contextName;
    if (contextName === "2d")
      this.prototypes = CanvasRenderingContext2D.prototype;
    else if (contextName === "webgl" || contextName === "experimental-webgl")
      this.prototypes = WebGLRenderingContext.prototype;
    else
      throw new Error(`Invalid context name: ${contextName}`);
  }

  public add = (canvas: HTMLCanvasElement) => {
    if (!canvas) throw new Error('Invalid canvas.');
    if (this.contexts.get(canvas.id)) return;

    const context = canvas.getContext(this.contextName);

    if (!context) throw new Error('Invalid context.');

    this.contexts.set(canvas.id, context);
  }

  public remove = (canvas: HTMLCanvasElement) => {
    this.contexts.delete(canvas.id);
  }

  public setProperty = (canvas: HTMLCanvasElement, property: string, value: any) => {
    const context = this.getContext(canvas);
    context[property] = value;
  }

  public call = (canvas: HTMLCanvasElement, method: string, args: any) => {
    const context = this.getContext(canvas);
    return this.prototypes[method].apply(context, args);
  }

  private getContext = (canvas: HTMLCanvasElement) => {
    if (!canvas) throw new Error('Invalid canvas.');

    const context = this.contexts.get(canvas.id);
    if (!context) throw new Error('Invalid context.');

    return context;
  }
}
