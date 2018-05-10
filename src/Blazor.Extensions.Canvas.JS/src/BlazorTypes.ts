// Declare types here until we've Blazor.d.ts
export interface System_Object { System_Object__DO_NOT_IMPLEMENT: any };
export interface System_String extends System_Object { System_String__DO_NOT_IMPLEMENT: any }

export interface Platform {
  toJavaScriptString(dotNetString: System_String): string;
}

export type BlazorType = {
  registerFunction(identifier: string, implementation: Function),
  platform: Platform
};
