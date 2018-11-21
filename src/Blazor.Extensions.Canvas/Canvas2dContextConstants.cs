namespace Blazor.Extensions
{
    public static class Canvas2dContextConstants
    {
        #region JavaScript Actions
        public static readonly string GET_CANVAS_PROPERTY_ACTION = "BlazorExtensions.Canvas2d.GetProperty";
        public static readonly string SET_CANVAS_PROPERTY_ACTION = "BlazorExtensions.Canvas2d.SetProperty";
        public static readonly string CALL_CANVAS_METHOD_ACTION = "BlazorExtensions.Canvas2d.Call";
        public static readonly string ADD_CANVAS_ACTION = "BlazorExtensions.Canvas2d.Add";
        public static readonly string REMOVE_CANVAS_ACTION = "BlazorExtensions.Canvas2d.Remove";
        #endregion

        #region Property Names
        public static readonly string FILL_STYLE_PROPERTY = "fillStyle";
        public static readonly string STROKE_STYLE_PROPERTY = "strokeStyle";
        public static readonly string LINE_WIDTH_PROPERTY = "lineWidth";
        public static readonly string LINE_CAP_PROPERTY = "lineCap";
        public static readonly string LINE_JOIN_PROPERTY = "lineJoin";
        public static readonly string MITER_LIMIT_PROPERTY = "miterLimit";
        public static readonly string LINE_DASH_OFFSET_PROPERTY = "lineDashOffset";
        public static readonly string SHADOW_BLUR_PROPERTY = "shadowBlur";
        public static readonly string SHADOW_COLOR_PROPERTY = "shadowColor";
        public static readonly string SHADOW_OFFSET_X_PROPERTY = "shadowOffsetX";
        public static readonly string SHADOW_OFFSET_Y_PROPERTY = "shadowOffsetY";
        public static readonly string GLOBAL_ALPHA_PROPERTY = "globalAlpha";
        public static readonly string FONT_PROPERTY = "font";
        public static readonly string TEXT_ALIGN_PROPERTY = "textAlign";
        public static readonly string DIRECTION_PROPERTY = "direction";
        public static readonly string TEXT_BASELINE_PROPERTY = "textBaseline";

        #endregion

        #region Canvas Methods
        public static readonly string FILL_RECT_METHOD = "fillRect";
        public static readonly string CLEAR_RECT_METHOD = "clearRect";
        public static readonly string STROKE_RECT_METHOD = "strokeRect";
        public static readonly string FILL_TEXT_METHOD = "fillText";
        public static readonly string STROKE_TEXT_METHOD = "strokeText";
        public static readonly string MEASURE_TEXT_METHOD = "measureText";
        public static readonly string GET_LINE_DASH_METHOD = "getLineDash";
        public static readonly string SET_LINE_DASH_METHOD = "setLineDash";
        public static readonly string BEGIN_PATH_METHOD = "beginPath";
        public static readonly string CLOSE_PATH_METHOD = "closePath";
        public static readonly string MOVE_TO_METHOD = "moveTo";
        public static readonly string LINE_TO_METHOD = "lineTo";
        public static readonly string BEZIER_CURVE_TO_METHOD = "bezierCurveTo";
        public static readonly string QUADRATIC_CURVE_TO_METHOD = "quadraticCurveTo";
        public static readonly string ARC_METHOD = "arc";
        public static readonly string ARC_TO_METHOD = "arcTo";
        public static readonly string RECT_METHOD = "rect";
        public static readonly string FILL_METHOD = "fill";
        public static readonly string STROKE_METHOD = "stroke";
        public static readonly string DRAW_FOCUS_IF_NEEDED_METHOD = "drawFocusIfNeeded";
        public static readonly string SCROLL_PATH_INTO_VIEW_METHOD = "scrollPathIntoView";
        public static readonly string CLIP_METHOD = "clip";
        public static readonly string IS_POINT_IN_PATH_METHOD = "isPointInPath";
        public static readonly string IS_POINT_IN_STROKE_METHOD = "isPointInStroke";
        public static readonly string ROTATE_METHOD = "rotate";
        public static readonly string SCALE_METHOD = "scale";
        public static readonly string TRANSLATE_METHOD = "translate";
        public static readonly string TRANSFORM_METHOD = "transform";
        public static readonly string SET_TRANSFORM_METHOD = "setTransform";
        public static readonly string SAVE_METHOD = "save";
        public static readonly string RESTORE_METHOD = "restore";
        #endregion
    }
}
