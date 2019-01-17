namespace Blazor.Extensions.Canvas.WebGL
{
    public class WebGLContext : RenderingContext
    {
        #region Constants
        private const string CONTEXT_NAME = "WebGL";
        private const string CLEAR_COLOR = "clearColor";
        private const string CLEAR = "clear";
        private const string DRAWING_BUFFER_WIDTH = "drawingBufferWidth";
        private const string DRAWING_BUFFER_HEIGHT = "drawingBufferHeight";
        private const string GET_CONTEXT_ATTRIBUTES = "getContextAttributes";
        private const string IS_CONTEXT_LOST = "isContextLost";
        private const string SCISSOR = "scissor";
        private const string VIEWPORT = "viewport";
        private const string ACTIVE_TEXTURE = "activeTexture";
        #endregion

        #region Properties
        public int DrawingBufferWidth => this.GetProperty<int>(DRAWING_BUFFER_WIDTH);
        public int DrawingBufferHeight => this.GetProperty<int>(DRAWING_BUFFER_HEIGHT);
        #endregion

        internal WebGLContext(BECanvasComponent reference, WebGLContextAttributes attributes = null) : base(reference, CONTEXT_NAME, attributes)
        {
        }

        #region Methods
        public void ClearColor(float red, float green, float blue, float alpha) => this.CallMethod<object>(CLEAR_COLOR, new object[] { red, green, blue, alpha });
        public void Clear(BufferBits mask) => this.CallMethod<object>(CLEAR, new object[] { mask });
        public WebGLContextAttributes GetContextAttributes() => this.CallMethod<WebGLContextAttributes>(GET_CONTEXT_ATTRIBUTES);
        public bool IsContextLost() => this.CallMethod<bool>(IS_CONTEXT_LOST);
        public void Scissor(int x, int y, int width, int height) => this.CallMethod<object>(SCISSOR, new object[] { x, y, width, height });
        public void Viewport(int x, int y, int width, int height) => this.CallMethod<object>(VIEWPORT, new object[] { x, y, width, height });
        public void ActiveTexture(Texture texture) => this.CallMethod<object>(ACTIVE_TEXTURE, new object[] { texture });
        #endregion
    }
}
