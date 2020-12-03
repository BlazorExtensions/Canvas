namespace Blazor.Extensions.Canvas.Canvas2D
{
    public enum TextAlign
    {
        Start,
        End,
        Left,
        Right,
        Center
    }

    public enum TextBaseline
    {
        Alphabetic,
        Top,
        Hanging,
        Middle,
        Ideographic,
        Bottom
    }

    public enum TextDirection
    {
        Inherit,
        LTR,
        RTL
    }

    public enum LineCap
    {
        Butt,
        Round,
        Square
    }

    public enum LineJoin
    {
        Miter,
        Round,
        Bevel
    }

    public class RepeatPattern
    {
        private RepeatPattern(string value)
        {
            this.Value = value;
        }
        public string Value { get; }

        public static readonly RepeatPattern Repeat = new RepeatPattern("repeat");
        public static readonly RepeatPattern RepeatX = new RepeatPattern("repeat-x");
        public static readonly RepeatPattern RepeatY = new RepeatPattern("repeat-y");
        public static readonly RepeatPattern NoRepeat = new RepeatPattern("no-repeat");   
    }
}
