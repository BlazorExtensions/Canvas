using Microsoft.AspNetCore.Blazor;
using Microsoft.JSInterop;
using System;
using static Blazor.Extensions.Canvas2dContextConstants;

namespace Blazor.Extensions
{
    public class Canvas2dContext : IDisposable
    {
        #region Properties
        private string _fillStyle = "#000";

        public string FillStyle
        {
            get => this._fillStyle;
            set
            {
                this._fillStyle = value;

                this.SetProperty(FILL_STYLE_PROPERTY, value);
            }
        }

        private string _strokeStyle = "#000";

        public string StrokeStyle
        {
            get => this._strokeStyle;
            set
            {
                this._strokeStyle = value;
                this.SetProperty(STROKE_STYLE_PROPERTY, value);
            }
        }

        private string _font = "10px sans-serif";

        public string Font
        {
            get => this._font;
            set
            {
                this._font = value;
                this.SetProperty(FONT_PROPERTY, value);
            }
        }

        private TextAlign _textAlign;

        public TextAlign TextAlign
        {
            get => this._textAlign;
            set
            {
                this._textAlign = value;
                this.SetProperty(TEXT_ALIGN_PROPERTY, value.ToString().ToLowerInvariant());
            }
        }

        private TextDirection _direction;

        public TextDirection Direction
        {
            get => this._direction;
            set
            {
                this._direction = value;
                this.SetProperty(DIRECTION_PROPERTY, value.ToString().ToLowerInvariant());
            }
        }

        private TextBaseline _textBaseline;

        public TextBaseline TextBaseline
        {
            get => this._textBaseline;
            set
            {
                this._textBaseline = value;
                this.SetProperty(TEXT_BASELINE_PROPERTY, value.ToString().ToLowerInvariant());
            }
        }

        private float _lineWidth = 1.0f;

        public float LineWidth
        {
            get => this._lineWidth;
            set
            {
                this._lineWidth = value;
                this.SetProperty(LINE_WIDTH_PROPERTY, value);
            }
        }

        private LineCap _lineCap;

        public LineCap LineCap
        {
            get => this._lineCap;
            set
            {
                this._lineCap = value;
                this.SetProperty(LINE_CAP_PROPERTY, value.ToString().ToLowerInvariant());
            }
        }

        private LineJoin _lineJoin;

        public LineJoin LineJoin
        {
            get => this._lineJoin;
            set
            {
                this._lineJoin = value;
                this.SetProperty(LINE_JOIN_PROPERTY, value.ToString().ToLowerInvariant());
            }
        }

        private float _miterLimit = 10;

        public float MiterLimit
        {
            get => this._miterLimit;
            set
            {
                this._miterLimit = value;
                this.SetProperty(MITER_LIMIT_PROPERTY, value);
            }
        }

        private float _lineDashOffset;

        public float LineDashOffset
        {
            get => this._lineDashOffset;
            set
            {
                this._lineDashOffset = value;
                this.SetProperty(LINE_DASH_OFFSET_PROPERTY, value);
            }
        }

        private float _shadowBlur;

        public float ShadowBlur
        {
            get => this._shadowBlur;
            set
            {
                this._shadowBlur = value;
                this.SetProperty(SHADOW_BLUR_PROPERTY, value);
            }
        }

        private string _shadowColor = "black";

        public string ShadowColor
        {
            get => this._shadowColor;
            set
            {
                this._shadowColor = value;
                this.SetProperty(SHADOW_COLOR_PROPERTY, value);
            }
        }

        private float _shadowOffsetX;

        public float ShadowOffsetX
        {
            get => this._shadowOffsetX;
            set
            {
                this._shadowOffsetX = value;
                this.SetProperty(SHADOW_OFFSET_X_PROPERTY, value);
            }
        }

        private float _shadowOffsetY;

        public float ShadowOffsetY
        {
            get => this._shadowOffsetY;
            set
            {
                this._shadowOffsetY = value;
                this.SetProperty(SHADOW_OFFSET_Y_PROPERTY, value);
            }
        }

        private float _globalAlpha = 1.0f;

        public float GlobalAlpha
        {
            get => this._globalAlpha;
            set
            {
                this._globalAlpha = value;
                this.SetProperty(GLOBAL_ALPHA_PROPERTY, value);
            }
        }

        public ElementRef Canvas { get; private set; }
        #endregion

        internal Canvas2dContext(BECanvasComponent canvasReference)
        {
            this.Canvas = canvasReference.CanvasReference;
            ((IJSInProcessRuntime)JSRuntime.Current).Invoke<object>(ADD_CANVAS_ACTION, this.Canvas);
        }

        #region Methods
        public void FillRect(double x, double y, double width, double height) => this.CallMethod<object>(FILL_RECT_METHOD, new object[] { x, y, width, height });
        public void ClearRect(double x, double y, double width, double height) => this.CallMethod<object>(CLEAR_RECT_METHOD, new object[] { x, y, width, height });
        public void StrokeRect(double x, double y, double width, double height) => this.CallMethod<object>(STROKE_RECT_METHOD, new object[] { x, y, width, height });
        public void FillText(string text, double x, double y, double? maxWidth = null) => this.CallMethod<object>(FILL_TEXT_METHOD, maxWidth.HasValue ? new object[] { text, x, y, maxWidth.Value } : new object[] { text, x, y });
        public void StrokeText(string text, double x, double y, double? maxWidth = null) => this.CallMethod<object>(STROKE_TEXT_METHOD, maxWidth.HasValue ? new object[] { text, x, y, maxWidth.Value } : new object[] { text, x, y });
        public TextMetrics MeasureText(string text) => this.CallMethod<TextMetrics>(MEASURE_TEXT_METHOD, new object[] { text });
        public float[] GetLineDash() => this.CallMethod<float[]>(GET_LINE_DASH_METHOD);
        public void SetLineDash(float[] segments) => this.CallMethod<object>(SET_LINE_DASH_METHOD, new object[] { segments });
        public void BeginPath() => this.CallMethod<object>(BEGIN_PATH_METHOD);
        public void ClosePath() => this.CallMethod<object>(CLOSE_PATH_METHOD);
        public void MoveTo(double x, double y) => this.CallMethod<object>(MOVE_TO_METHOD, new object[] { x, y });
        public void LineTo(double x, double y) => this.CallMethod<object>(LINE_TO_METHOD, new object[] { x, y });
        public void BezierCurveTo(double cp1x, double cp1y, double cp2x, double cp2y, double x, double y) => this.CallMethod<object>(BEZIER_CURVE_TO_METHOD, new object[] { cp1x, cp1y, cp2x, cp2y, x, y });
        public void QuadraticCurveTo(double cpx, double cpy, double x, double y) => this.CallMethod<object>(QUADRATIC_CURVE_TO_METHOD, new object[] { cpx, cpy, x, y });
        public void Arc(double x, double y, double radius, double startAngle, double endAngle, bool? anticlockwise = null) => this.CallMethod<object>(ARC_METHOD, anticlockwise.HasValue ? new object[] { x, y, radius, startAngle, endAngle, anticlockwise.Value } : new object[] { x, y, radius, startAngle, endAngle });
        public void ArcTo(double x1, double y1, double x2, double y2, double radius) => this.CallMethod<object>(ARC_TO_METHOD, new object[] { x1, y1, x2, y2, radius });
        public void Rect(double x, double y, double width, double height) => this.CallMethod<object>(RECT_METHOD, new object[] { x, y, width, height });
        public void Fill() => this.CallMethod<object>(FILL_METHOD);
        public void Stroke() => this.CallMethod<object>(STROKE_METHOD);
        public void DrawFocusIfNeeded(ElementRef elementReference) => this.CallMethod<object>(DRAW_FOCUS_IF_NEEDED_METHOD, new object[] { elementReference });
        public void ScrollPathIntoView() => this.CallMethod<object>(SCROLL_PATH_INTO_VIEW_METHOD);
        public void Clip() => this.CallMethod<object>(CLIP_METHOD);
        public bool IsPointInPath(double x, double y) => this.CallMethod<bool>(IS_POINT_IN_PATH_METHOD, new object[] { x, y });
        public bool IsPointInStroke(double x, double y) => this.CallMethod<bool>(IS_POINT_IN_STROKE_METHOD, new object[] { x, y });
        public void Rotate(float angle) => this.CallMethod<object>(ROTATE_METHOD, new object[] { angle });
        public void Scale(double x, double y) => this.CallMethod<object>(SCALE_METHOD, new object[] { x, y });
        public void Translate(double x, double y) => this.CallMethod<object>(TRANSLATE_METHOD, new object[] { x, y });
        public void Transform(double m11, double m12, double m21, double m22, double dx, double dy) => this.CallMethod<object>(TRANSFORM_METHOD, new object[] { m11, m12, m21, m22, dx, dy });
        public void SetTransform(double m11, double m12, double m21, double m22, double dx, double dy) => this.CallMethod<object>(SET_TRANSFORM_METHOD, new object[] { m11, m12, m21, m22, dx, dy });
        public void Save() => this.CallMethod<object>(SAVE_METHOD);
        public void Restore() => this.CallMethod<object>(RESTORE_METHOD);
        #endregion

        #region Private Methods
        private void SetProperty(string property, object value)
        {
            ((IJSInProcessRuntime)JSRuntime.Current).Invoke<object>(SET_CANVAS_PROPERTY_ACTION, this.Canvas, property, value);
        }

        private T CallMethod<T>(string method)
        {
            return ((IJSInProcessRuntime)JSRuntime.Current).Invoke<T>(CALL_CANVAS_METHOD_ACTION, this.Canvas, method);
        }

        private T CallMethod<T>(string method, object value)
        {
            return ((IJSInProcessRuntime)JSRuntime.Current).Invoke<T>(CALL_CANVAS_METHOD_ACTION, this.Canvas, method, value);
        }

        public void Dispose()
        {
            ((IJSInProcessRuntime)JSRuntime.Current).Invoke<object>(REMOVE_CANVAS_ACTION, this.Canvas);
        } 
        #endregion
    }
}
