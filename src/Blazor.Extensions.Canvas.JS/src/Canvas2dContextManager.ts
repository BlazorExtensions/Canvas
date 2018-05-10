import { BlazorType } from './BlazorTypes';

export class Canvas2dContextManager {
  private _canvasContexts: { [canvasId: string]: CanvasRenderingContext2D } = {};
  private Blazor: BlazorType = window["Blazor"];

  public add(canvas: HTMLCanvasElement) {
    if (!canvas) throw new Error('Invalid canvas.');

    if (this._canvasContexts[canvas.id]) return;

    const context = canvas.getContext('2d');

    if (!context) throw new Error('Invalid context.');

    this._canvasContexts[canvas.id] = context;
  }

  public remove(canvas: HTMLCanvasElement) {
    const context = this.getContext(canvas);
    if (this._canvasContexts[canvas.id]) {
      delete this._canvasContexts[canvas.id];
    }
  }

  public setProperty(canvas: HTMLCanvasElement, property: string, value: any) {
    const context = this.getContext(canvas);
    context[property] = value;
  }

  public call(canvas: HTMLCanvasElement, method: string, args: any) {
    const context = this.getContext(canvas);
    return CanvasRenderingContext2D.prototype[method].apply(context, args);
  }

  private getContext(canvas: HTMLCanvasElement) {
    if (!canvas) throw new Error('Invalid canvas.');

    const context = this._canvasContexts[canvas.id];
    if (!context) throw new Error('Invalid context.');

    return context;
  }

  public static initialize() {
    const Blazor: BlazorType = window["Blazor"];
    const contextManager = new Canvas2dContextManager();
    
    Blazor.registerFunction('Blazor.Extensions.Canvas2d.Add', (canvas: HTMLCanvasElement) => {
      contextManager.add(canvas);
    });

    Blazor.registerFunction('Blazor.Extensions.Canvas2d.Remove', (canvas: HTMLCanvasElement) => {
      contextManager.remove(canvas);
    });

    Blazor.registerFunction('Blazor.Extensions.Canvas2d.SetProperty', (canvas: HTMLCanvasElement, property: string, value: any) => {
      contextManager.setProperty(canvas, property, value);
    });

    Blazor.registerFunction('Blazor.Extensions.Canvas2d.Call', (canvas: HTMLCanvasElement, operation: string, args: any) => {
      return contextManager.call(canvas, operation, args);
    });
  }
}
