namespace Blazor.Extensions.Canvas.WebGL
{
    public class WebGLContextAttributes
    {
        public bool Alpha { get; set; } = true;
        public bool Antialias { get; set; } = true;
        public bool Depth { get; set; } = true;
        public bool PremultipliedAlpha { get; set; } = true;
        public bool PreserveDrawingBuffer { get; set; } = false;
        public bool Stencil { get; set; } = false;
        public string PowerPreference { get; set; } = POWER_PREFERENCE_DEFAULT;
        public bool FailIfMajorPerformanceCaveat { get; set; } = false;

        public const string POWER_PREFERENCE_DEFAULT = "default";
        public const string POWER_PREFERENCE_HIGH_PERFORMANCE = "high-performance";
        public const string POWER_PREFERENCE_LOW_POWER = "low-power";
    }
}
