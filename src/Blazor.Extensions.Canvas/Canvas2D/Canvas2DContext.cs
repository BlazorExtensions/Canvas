using Blazor.Extensions.Canvas.Model;
using Microsoft.AspNetCore.Components;
using System;
using System.Threading.Tasks;

namespace Blazor.Extensions.Canvas.Canvas2D
{
    public class Canvas2DContext : RenderingContext
    {
        #region Constants
        private const string CONTEXT_NAME = "Canvas2d";
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
        private const string DRAW_IMAGE_METHOD = "drawImage";
        #endregion

        #region Properties

        public string FillStyle { get; private set; } = "#000";

        public string StrokeStyle { get; private set; } = "#000";

        public string Font { get; private set; } = "10px sans-serif";

        public TextAlign TextAlign { get; private set; }

        public TextDirection Direction { get; private set; }

        public TextBaseline TextBaseline { get; private set; }

        public float LineWidth { get; private set; } = 1.0f;

        public LineCap LineCap { get; private set; }

        public LineJoin LineJoin { get; private set; }

        public float MiterLimit { get; private set; } = 10;

        public float LineDashOffset { get; private set; }

        public float ShadowBlur { get; private set; }

        public string ShadowColor { get; private set; } = "black";

        public float ShadowOffsetX { get; private set; }

        public float ShadowOffsetY { get; private set; }

        public float GlobalAlpha { get; private set; } = 1.0f;

        #endregion Properties

        internal Canvas2DContext(BECanvasComponent reference) : base(reference, CONTEXT_NAME)
        {
        }

        #region Property Setters

        public async Task SetFillStyleAsync(string value)
        {
            this.FillStyle = value;
            await this.BatchCallAsync(FILL_STYLE_PROPERTY, isMethodCall: false, value);
        }

        public async Task SetStrokeStyleAsync(string value)
        {
            this.StrokeStyle = value;
            await this.BatchCallAsync(STROKE_STYLE_PROPERTY, isMethodCall: false, value);
        }

        public async Task SetFontAsync(string value)
        {
            this.Font = value;
            await this.BatchCallAsync("font", isMethodCall: false, value);
        }

        public async Task SetTextAlignAsync(TextAlign value)
        {
            this.TextAlign = value;
            await this.BatchCallAsync("textAlign", isMethodCall: false, value.ToString().ToLowerInvariant());
        }

        public async Task SetDirectionAsync(TextDirection value)
        {
            this.Direction = value;
            await this.BatchCallAsync("direction", isMethodCall: false, value.ToString().ToLowerInvariant());
        }

        public async Task SetTextBaselineAsync(TextBaseline value)
        {
            this.TextBaseline = value;
            await this.BatchCallAsync("textBaseline", isMethodCall: false, value.ToString().ToLowerInvariant());
        }

        public async Task SetLineWidthAsync(float value)
        {
            this.LineWidth = value;
            await this.BatchCallAsync(LINE_WIDTH_PROPERTY, isMethodCall: false, value);
        }

        public async Task SetLineCapAsync(LineCap value)
        {
            this.LineCap = value;
            await this.BatchCallAsync(LINE_CAP_PROPERTY, isMethodCall: false, value.ToString().ToLowerInvariant());
        }

        public async Task SetLineJoinAsync(LineJoin value)
        {
            this.LineJoin = value;
            await this.BatchCallAsync(LINE_JOIN_PROPERTY, isMethodCall: false, value.ToString().ToLowerInvariant());
        }

        public async Task SetMiterLimitAsync(float value)
        {
            this.MiterLimit = value;
            await this.BatchCallAsync(MITER_LIMIT_PROPERTY, isMethodCall: false, value.ToString().ToLowerInvariant());
        }

        public async Task SetLineDashOffsetAsync(float value)
        {
            this.LineDashOffset = value;
            await this.BatchCallAsync(LINE_DASH_OFFSET_PROPERTY, isMethodCall: false, value);
        }

        public async Task SetShadowBlurAsync(float value)
        {
            this.ShadowBlur = value;
            await this.BatchCallAsync(SHADOW_BLUR_PROPERTY, isMethodCall: false, value);
        }

        public async Task SetShadowColorAsync(string value)
        {
            this.ShadowColor = value;
            await this.BatchCallAsync(SHADOW_COLOR_PROPERTY, isMethodCall: false, value);
        }

        public async Task SetShadowOffsetXAsync(float value)
        {
            this.ShadowOffsetX = value;
            await this.BatchCallAsync(SHADOW_OFFSET_X_PROPERTY, isMethodCall: false, value);
        }

        public async Task SetShadowOffsetYAsync(float value)
        {
            this.ShadowOffsetY = value;
            await this.BatchCallAsync(SHADOW_OFFSET_Y_PROPERTY, isMethodCall: false, value);
        }

        public async Task SetGlobalAlphaAsync(float value)
        {
            this.GlobalAlpha = value;
            await this.BatchCallAsync(GLOBAL_ALPHA_PROPERTY, isMethodCall: false, value);
        }

        #endregion Property Setters

        #region Methods
        [Obsolete("Use the async version instead, which is already called internally.")]
        public void FillRect(double x, double y, double width, double height) => this.CallMethod<object>(FILL_RECT_METHOD, x, y, width, height);
        public async Task FillRectAsync(double x, double y, double width, double height) => await this.BatchCallAsync(FILL_RECT_METHOD, isMethodCall: true, x, y, width, height);

        [Obsolete("Use the async version instead, which is already called internally.")]
        public void ClearRect(double x, double y, double width, double height) => this.CallMethod<object>(CLEAR_RECT_METHOD, x, y, width, height);
        public async Task ClearRectAsync(double x, double y, double width, double height) => await this.BatchCallAsync(CLEAR_RECT_METHOD, isMethodCall: true, x, y, width, height);

        [Obsolete("Use the async version instead, which is already called internally.")]
        public void StrokeRect(double x, double y, double width, double height) => this.CallMethod<object>(STROKE_RECT_METHOD, x, y, width, height);
        public async Task StrokeRectAsync(double x, double y, double width, double height) => await this.BatchCallAsync(STROKE_RECT_METHOD, isMethodCall: true, x, y, width, height);

        [Obsolete("Use the async version instead, which is already called internally.")]
        public void FillText(string text, double x, double y, double? maxWidth = null) => this.CallMethod<object>(FILL_TEXT_METHOD, maxWidth.HasValue ? new object[] { text, x, y, maxWidth.Value } : new object[] { text, x, y });
        public async Task FillTextAsync(string text, double x, double y, double? maxWidth = null) => await this.BatchCallAsync(FILL_TEXT_METHOD, isMethodCall: true, maxWidth.HasValue ? new object[] { text, x, y, maxWidth.Value } : new object[] { text, x, y });

        [Obsolete("Use the async version instead, which is already called internally.")]
        public void StrokeText(string text, double x, double y, double? maxWidth = null) => this.CallMethod<object>(STROKE_TEXT_METHOD, maxWidth.HasValue ? new object[] { text, x, y, maxWidth.Value } : new object[] { text, x, y });
        public async Task StrokeTextAsync(string text, double x, double y, double? maxWidth = null) => await this.BatchCallAsync(STROKE_TEXT_METHOD, isMethodCall: true, maxWidth.HasValue ? new object[] { text, x, y, maxWidth.Value } : new object[] { text, x, y });

        [Obsolete("Use the async version instead, which is already called internally.")]
        public TextMetrics MeasureText(string text) => this.CallMethod<TextMetrics>(MEASURE_TEXT_METHOD, text);
        public async Task<TextMetrics> MeasureTextAsync(string text) => await this.CallMethodAsync<TextMetrics>(MEASURE_TEXT_METHOD, text);

        [Obsolete("Use the async version instead, which is already called internally.")]
        public float[] GetLineDash() => this.CallMethod<float[]>(GET_LINE_DASH_METHOD);
        public async Task<float[]> GetLineDashAsync() => await this.CallMethodAsync<float[]>(GET_LINE_DASH_METHOD);

        [Obsolete("Use the async version instead, which is already called internally.")]
        public void SetLineDash(float[] segments) => this.CallMethod<object>(SET_LINE_DASH_METHOD, segments);
        public async Task SetLineDashAsync(float[] segments) => await this.BatchCallAsync(SET_LINE_DASH_METHOD, isMethodCall: true, segments);

        [Obsolete("Use the async version instead, which is already called internally.")]
        public void BeginPath() => this.CallMethod<object>(BEGIN_PATH_METHOD);
        public async Task BeginPathAsync() => await this.BatchCallAsync(BEGIN_PATH_METHOD, isMethodCall: true);

        [Obsolete("Use the async version instead, which is already called internally.")]
        public void ClosePath() => this.CallMethod<object>(CLOSE_PATH_METHOD);
        public async Task ClosePathAsync() => await this.BatchCallAsync(CLOSE_PATH_METHOD, isMethodCall: true);

        [Obsolete("Use the async version instead, which is already called internally.")]
        public void MoveTo(double x, double y) => this.CallMethod<object>(MOVE_TO_METHOD, x, y);
        public async Task MoveToAsync(double x, double y) => await this.BatchCallAsync(MOVE_TO_METHOD, isMethodCall: true, x, y);

        [Obsolete("Use the async version instead, which is already called internally.")]
        public void LineTo(double x, double y) => this.CallMethod<object>(LINE_TO_METHOD, x, y);
        public async Task LineToAsync(double x, double y) => await this.BatchCallAsync(LINE_TO_METHOD, isMethodCall: true, x, y);

        [Obsolete("Use the async version instead, which is already called internally.")]
        public void BezierCurveTo(double cp1X, double cp1Y, double cp2X, double cp2Y, double x, double y) => this.CallMethod<object>(BEZIER_CURVE_TO_METHOD, cp1X, cp1Y, cp2X, cp2Y, x, y);
        public async Task BezierCurveToAsync(double cp1X, double cp1Y, double cp2X, double cp2Y, double x, double y) => await this.BatchCallAsync(BEZIER_CURVE_TO_METHOD, isMethodCall: true, cp1X, cp1Y, cp2X, cp2Y, x, y);

        [Obsolete("Use the async version instead, which is already called internally.")]
        public void QuadraticCurveTo(double cpx, double cpy, double x, double y) => this.CallMethod<object>(QUADRATIC_CURVE_TO_METHOD, cpx, cpy, x, y);
        public async Task QuadraticCurveToAsync(double cpx, double cpy, double x, double y) => await this.BatchCallAsync(QUADRATIC_CURVE_TO_METHOD, isMethodCall: true, cpx, cpy, x, y);

        [Obsolete("Use the async version instead, which is already called internally.")]
        public void Arc(double x, double y, double radius, double startAngle, double endAngle, bool? anticlockwise = null) => this.CallMethod<object>(ARC_METHOD, anticlockwise.HasValue ? new object[] { x, y, radius, startAngle, endAngle, anticlockwise.Value } : new object[] { x, y, radius, startAngle, endAngle });
        public async Task ArcAsync(double x, double y, double radius, double startAngle, double endAngle, bool? anticlockwise = null) => await this.BatchCallAsync(ARC_METHOD, isMethodCall: true, anticlockwise.HasValue ? new object[] { x, y, radius, startAngle, endAngle, anticlockwise.Value } : new object[] { x, y, radius, startAngle, endAngle });

        [Obsolete("Use the async version instead, which is already called internally.")]
        public void ArcTo(double x1, double y1, double x2, double y2, double radius) => this.CallMethod<object>(ARC_TO_METHOD, x1, y1, x2, y2, radius);
        public async Task ArcToAsync(double x1, double y1, double x2, double y2, double radius) => await this.BatchCallAsync(ARC_TO_METHOD, isMethodCall: true, x1, y1, x2, y2, radius);

        [Obsolete("Use the async version instead, which is already called internally.")]
        public void Rect(double x, double y, double width, double height) => this.CallMethod<object>(RECT_METHOD, x, y, width, height);
        public async Task RectAsync(double x, double y, double width, double height) => await this.BatchCallAsync(RECT_METHOD, isMethodCall: true, x, y, width, height);

        [Obsolete("Use the async version instead, which is already called internally.")]
        public void Fill() => this.CallMethod<object>(FILL_METHOD);
        public async Task FillAsync() => await this.BatchCallAsync(FILL_METHOD, isMethodCall: true);

        [Obsolete("Use the async version instead, which is already called internally.")]
        public void Stroke() => this.CallMethod<object>(STROKE_METHOD);
        public async Task StrokeAsync() => await this.BatchCallAsync(STROKE_METHOD, isMethodCall: true);

        [Obsolete("Use the async version instead, which is already called internally.")]
        public void DrawFocusIfNeeded(ElementReference elementReference) => this.CallMethod<object>(DRAW_FOCUS_IF_NEEDED_METHOD, elementReference);
        public async Task DrawFocusIfNeededAsync(ElementReference elementReference) => await this.BatchCallAsync(DRAW_FOCUS_IF_NEEDED_METHOD, isMethodCall: true, elementReference);

        [Obsolete("Use the async version instead, which is already called internally.")]
        public void ScrollPathIntoView() => this.CallMethod<object>(SCROLL_PATH_INTO_VIEW_METHOD);
        public async Task ScrollPathIntoViewAsync() => await this.BatchCallAsync(SCROLL_PATH_INTO_VIEW_METHOD, isMethodCall: true);

        [Obsolete("Use the async version instead, which is already called internally.")]
        public void Clip() => this.CallMethod<object>(CLIP_METHOD);
        public async Task ClipAsync() => await this.BatchCallAsync(CLIP_METHOD, isMethodCall: true);

        [Obsolete("Use the async version instead, which is already called internally.")]
        public bool IsPointInPath(double x, double y) => this.CallMethod<bool>(IS_POINT_IN_PATH_METHOD, x, y);
        public async Task<bool> IsPointInPathAsync(double x, double y) => await this.CallMethodAsync<bool>(IS_POINT_IN_PATH_METHOD, x, y);

        [Obsolete("Use the async version instead, which is already called internally.")]
        public bool IsPointInStroke(double x, double y) => this.CallMethod<bool>(IS_POINT_IN_STROKE_METHOD, x, y);
        public async Task<bool> IsPointInStrokeAsync(double x, double y) => await this.CallMethodAsync<bool>(IS_POINT_IN_STROKE_METHOD, x, y);

        [Obsolete("Use the async version instead, which is already called internally.")]
        public void Rotate(float angle) => this.CallMethod<object>(ROTATE_METHOD, angle);
        public async Task RotateAsync(float angle) => await this.BatchCallAsync(ROTATE_METHOD, isMethodCall: true, angle);

        [Obsolete("Use the async version instead, which is already called internally.")]
        public void Scale(double x, double y) => this.CallMethod<object>(SCALE_METHOD, x, y);
        public async Task ScaleAsync(double x, double y) => await this.BatchCallAsync(SCALE_METHOD, isMethodCall: true, x, y);

        [Obsolete("Use the async version instead, which is already called internally.")]
        public void Translate(double x, double y) => this.CallMethod<object>(TRANSLATE_METHOD, x, y);
        public async Task TranslateAsync(double x, double y) => await this.BatchCallAsync(TRANSLATE_METHOD, isMethodCall: true, x, y);

        [Obsolete("Use the async version instead, which is already called internally.")]
        public void Transform(double m11, double m12, double m21, double m22, double dx, double dy) => this.CallMethod<object>(TRANSFORM_METHOD, m11, m12, m21, m22, dx, dy);
        public async Task TransformAsync(double m11, double m12, double m21, double m22, double dx, double dy) => await this.BatchCallAsync(TRANSFORM_METHOD, isMethodCall: true, m11, m12, m21, m22, dx, dy);

        [Obsolete("Use the async version instead, which is already called internally.")]
        public void SetTransform(double m11, double m12, double m21, double m22, double dx, double dy) => this.CallMethod<object>(SET_TRANSFORM_METHOD, m11, m12, m21, m22, dx, dy);
        public async Task SetTransformAsync(double m11, double m12, double m21, double m22, double dx, double dy) => await this.BatchCallAsync(SET_TRANSFORM_METHOD, isMethodCall: true, m11, m12, m21, m22, dx, dy);

        [Obsolete("Use the async version instead, which is already called internally.")]
        public void Save() => this.CallMethod<object>(SAVE_METHOD);
        public async Task SaveAsync() => await this.BatchCallAsync(SAVE_METHOD, isMethodCall: true);

        [Obsolete("Use the async version instead, which is already called internally.")]
        public void Restore() => this.CallMethod<object>(RESTORE_METHOD);
        public async Task RestoreAsync() => await this.BatchCallAsync(RESTORE_METHOD, isMethodCall: true);

        public async Task DrawImageAsync(ElementReference elementReference, double dx, double dy) => await this.BatchCallAsync(DRAW_IMAGE_METHOD, isMethodCall: true, elementReference, dx, dy);
        public async Task DrawImageAsync(ElementReference elementReference, double dx, double dy, double dWidth, double dHeight) => await this.BatchCallAsync(DRAW_IMAGE_METHOD, isMethodCall: true, elementReference, dx, dy, dWidth, dHeight);
        public async Task DrawImageAsync(ElementReference elementReference, double sx, double sy, double sWidth, double sHeight, double dx, double dy, double dWidth, double dHeight) => await this.BatchCallAsync(DRAW_IMAGE_METHOD, isMethodCall: true, elementReference, sx, sy, sWidth, sHeight, dx, dy, dWidth, dHeight);

        #endregion Methods
    }
}
