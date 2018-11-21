export class Canvas2dContextManager {
  private _canvasContexts: Map<string, CanvasRenderingContext2D> = new Map<string, CanvasRenderingContext2D>();

  public Add = (canvas: HTMLCanvasElement) => {
    if (!canvas) throw new Error('Invalid canvas.');
    if (this._canvasContexts.get(canvas.id)) return;

    const context = canvas.getContext('2d');

    if (!context) throw new Error('Invalid context.');

    this._canvasContexts.set(canvas.id, context);
  }

  public Remove = (canvas: HTMLCanvasElement) => {
    this._canvasContexts.delete(canvas.id);
  }

  public GetProperty = (canvas: HTMLCanvasElement, property: string) => {
    const context = this.GetContext(canvas);
    return context[property];
  }

  public SetProperty = (canvas: HTMLCanvasElement, property: string, value: any) => {
    const context = this.GetContext(canvas);
    context[property] = value;
  }

  public Call = (canvas: HTMLCanvasElement, method: string, args: any) => {
    const context = this.GetContext(canvas);
    return CanvasRenderingContext2D.prototype[method].apply(context, args);
  }

  private GetContext = (canvas: HTMLCanvasElement) => {
    if (!canvas) throw new Error('Invalid canvas.');

    const context = this._canvasContexts.get(canvas.id);
    if (!context) throw new Error('Invalid context.');

    return context;
  }
}
