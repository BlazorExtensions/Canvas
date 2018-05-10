using Microsoft.AspNetCore.Blazor;
using Microsoft.AspNetCore.Blazor.Browser.Interop;
using System;

namespace Blazor.Extensions
{
    public class Canvas2dContext : IDisposable
    {
        #region Constants
        private const string SET_CANVAS_PROPERTY_ACTION = "Blazor.Extensions.Canvas2d.SetProperty";
        private const string CALL_CANVAS_METHOD_ACTION = "Blazor.Extensions.Canvas2d.Call";
        private const string ADD_CANVAS_ACTION = "Blazor.Extensions.Canvas2d.Add";
        private const string REMOVE_CANVAS_ACTION = "Blazor.Extensions.Canvas2d.Remove";
        private const string FILL_STYLE_PROPERTY = "fillStyle";
        private const string STROKE_STYLE_PROPERTY = "strokeStyle";
        private const string FILL_RECT_METHOD = "fillRect";
        private const string CLEAR_RECT_METHOD = "clearRect";
        private const string STROKE_RECT_METHOD = "strokeRect";
        private const string FILL_TEXT_METHOD = "fillText";
        private const string STROKE_TEXT_METHOD = "strokeText";
        private const string MEASURE_TEXT_METHOD = "measureText";
        private const string LINE_WIDTH_PROPERTY = "lineWidth";
        private const string LINE_CAP_PROPERTY = "lineCap";
        private const string LINE_JOIN_PROPERTY = "lineJoin";
        private const string MITER_LIMIT_PROPERTY = "miterLimit";
        private const string GET_LINE_DASH_METHOD = "getLineDash";
        private const string SET_LINE_DASH_METHOD = "setLineDash";
        private const string LINE_DASH_OFFSET_PROPERTY = "lineDashOffset";
        private const string SHADOW_BLUR_PROPERTY = "shadowBlur";
        private const string SHADOW_COLOR_PROPERTY = "shadowColor";
        private const string SHADOW_OFFSET_X_PROPERTY = "shadowOffsetX";
        private const string SHADOW_OFFSET_Y_PROPERTY = "shadowOffsetY";
        private const string BEGIN_PATH_METHOD = "beginPath";
        private const string CLOSE_PATH_METHOD = "closePath";
        private const string MOVE_TO_METHOD = "moveTo";
        private const string LINE_TO_METHOD = "lineTo";
        private const string BEZIER_CURVE_TO_METHOD = "bezierCurveTo";
        private const string QUADRATIC_CURVE_TO_METHOD = "quadraticCurveTo";
        private const string ARC_METHOD = "arc";
        private const string ARC_TO_METHOD = "arcTo";
        private const string RECT_METHOD = "rect";
        private const string FILL_METHOD = "fill";
        private const string STROKE_METHOD = "stroke";
        private const string DRAW_FOCUS_IF_NEEDED_METHOD = "drawFocusIfNeeded";
        private const string SCROLL_PATH_INTO_VIEW_METHOD = "scrollPathIntoView";
        private const string CLIP_METHOD = "clip";
        private const string IS_POINT_IN_PATH_METHOD = "isPointInPath";
        private const string IS_POINT_IN_STROKE_METHOD = "isPointInStroke";
        private const string ROTATE_METHOD = "rotate";
        private const string SCALE_METHOD = "scale";
        private const string TRANSLATE_METHOD = "translate";
        private const string TRANSFORM_METHOD = "transform";
        private const string SET_TRANSFORM_METHOD = "setTransform";
        private const string GLOBAL_ALPHA_PROPERTY = "globalAlpha";
        private const string SAVE_METHOD = "save";
        private const string RESTORE_METHOD = "restore"; 
        #endregion

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
                this.SetProperty("font", value);
            }
        }

        private TextAlign _textAlign;

        public TextAlign TextAlign
        {
            get => this._textAlign;
            set
            {
                this._textAlign = value;
                this.SetProperty("textAlign", value.ToString().ToLowerInvariant());
            }
        }

        private TextDirection _direction;

        public TextDirection Direction
        {
            get => this._direction;
            set
            {
                this._direction = value;
                this.SetProperty("direction", value.ToString().ToLowerInvariant());
            }
        }

        private TextBaseline _textBaseline;

        public TextBaseline TextBaseline
        {
            get => this._textBaseline;
            set
            {
                this._textBaseline = value;
                this.SetProperty("textBaseline", value.ToString().ToLowerInvariant());
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
            RegisteredFunction.Invoke<object>(ADD_CANVAS_ACTION, this.Canvas);
        }

        #region Methods
        public void FillRect(long x, long y, long width, long height) => this.CallMethod<object>(FILL_RECT_METHOD, new object[] { x, y, width, height });
        public void ClearRect(long x, long y, long width, long height) => this.CallMethod<object>(CLEAR_RECT_METHOD, new object[] { x, y, width, height });
        public void StrokeRect(long x, long y, long width, long height) => this.CallMethod<object>(STROKE_RECT_METHOD, new object[] { x, y, width, height });
        public void FillText(string text, long x, long y, long? maxWidth = null) => this.CallMethod<object>(FILL_TEXT_METHOD, maxWidth.HasValue ? new object[] { text, x, y, maxWidth.Value } : new object[] { text, x, y });
        public void StrokeText(string text, long x, long y, long? maxWidth = null) => this.CallMethod<object>(STROKE_TEXT_METHOD, maxWidth.HasValue ? new object[] { text, x, y, maxWidth.Value } : new object[] { text, x, y });
        public TextMetrics MeasureText(string text) => this.CallMethod<TextMetrics>(MEASURE_TEXT_METHOD, new object[] { text });
        public float[] GetLineDash() => this.CallMethod<float[]>(GET_LINE_DASH_METHOD);
        public void SetLineDash(float[] segments) => this.CallMethod<object>(SET_LINE_DASH_METHOD, new object[] { segments });
        public void BeginPath() => this.CallMethod<object>(BEGIN_PATH_METHOD);
        public void ClosePath() => this.CallMethod<object>(CLOSE_PATH_METHOD);
        public void MoveTo(long x, long y) => this.CallMethod<object>(MOVE_TO_METHOD, new object[] { x, y });
        public void LineTo(long x, long y) => this.CallMethod<object>(LINE_TO_METHOD, new object[] { x, y });
        public void BezierCurveTo(long cp1x, long cp1y, long cp2x, long cp2y, long x, long y) => this.CallMethod<object>(BEZIER_CURVE_TO_METHOD, new object[] { cp1x, cp1y, cp2x, cp2y, x, y });
        public void QuadraticCurveTo(long cpx, long cpy, long x, long y) => this.CallMethod<object>(QUADRATIC_CURVE_TO_METHOD, new object[] { cpx, cpy, x, y });
        public void Arc(long x, long y, long radius, long startAngle, long endAngle, bool? anticlockwise = null) => this.CallMethod<object>(ARC_METHOD, anticlockwise.HasValue ? new object[] { x, y, radius, startAngle, endAngle, anticlockwise.Value } : new object[] { x, y, radius, startAngle, endAngle });
        public void ArcTo(long x1, long y1, long x2, long y2, long radius) => this.CallMethod<object>(ARC_TO_METHOD, new object[] { x1, y1, x2, y2, radius });
        public void Rect(long x, long y, long width, long height) => this.CallMethod<object>(RECT_METHOD, new object[] { x, y, width, height });
        public void Fill() => this.CallMethod<object>(FILL_METHOD);
        public void Stroke() => this.CallMethod<object>(STROKE_METHOD);
        public void DrawFocusIfNeeded(ElementRef elementReference) => this.CallMethod<object>(DRAW_FOCUS_IF_NEEDED_METHOD, new object[] { elementReference });
        public void ScrollPathIntoView() => this.CallMethod<object>(SCROLL_PATH_INTO_VIEW_METHOD);
        public void Clip() => this.CallMethod<object>(CLIP_METHOD);
        public bool IsPointInPath(long x, long y) => this.CallMethod<bool>(IS_POINT_IN_PATH_METHOD, new object[] { x, y });
        public bool IsPointInStroke(long x, long y) => this.CallMethod<bool>(IS_POINT_IN_STROKE_METHOD, new object[] { x, y });
        public void Rotate(float angle) => this.CallMethod<object>(ROTATE_METHOD, new object[] { angle });
        public void Scale(long x, long y) => this.CallMethod<object>(SCALE_METHOD, new object[] { x, y });
        public void Translate(long x, long y) => this.CallMethod<object>(TRANSLATE_METHOD, new object[] { x, y });
        public void Transform(long m11, long m12, long m21, long m22, long dx, long dy) => this.CallMethod<object>(TRANSFORM_METHOD, new object[] { m11, m12, m21, m22, dx, dy });
        public void SetTransform(long m11, long m12, long m21, long m22, long dx, long dy) => this.CallMethod<object>(SET_TRANSFORM_METHOD, new object[] { m11, m12, m21, m22, dx, dy });
        public void Save() => this.CallMethod<object>(SAVE_METHOD);
        public void Restore() => this.CallMethod<object>(RESTORE_METHOD);
        #endregion

        #region Private Methods
        private void SetProperty(string property, object value)
        {
            RegisteredFunction.Invoke<object>(SET_CANVAS_PROPERTY_ACTION, this.Canvas, property, value);
        }

        private T CallMethod<T>(string method)
        {
            return RegisteredFunction.Invoke<T>(CALL_CANVAS_METHOD_ACTION, this.Canvas, method);
        }

        private T CallMethod<T>(string method, object value)
        {
            return RegisteredFunction.Invoke<T>(CALL_CANVAS_METHOD_ACTION, this.Canvas, method, value);
        }

        public void Dispose()
        {
            RegisteredFunction.Invoke<object>(REMOVE_CANVAS_ACTION, this.Canvas);
        } 
        #endregion
    }
}
