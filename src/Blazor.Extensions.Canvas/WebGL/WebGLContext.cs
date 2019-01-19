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
        private const string BLEND_COLOR = "blendColor";
        private const string BLEND_EQUATION = "blendEquation";
        private const string BLEND_EQUATION_SEPARATE = "blendEquationSeparate";
        private const string BLEND_FUNC = "blendFunc";
        private const string BLEND_FUNC_SEPARATE = "blendFuncSeparate";
        private const string CLEAR_DEPTH = "clearDepth";
        private const string CLEAR_STENCIL = "clearStencil";
        private const string COLOR_MASK = "colorMask";
        private const string CULL_FACE = "cullFace";
        private const string DEPTH_FUNC = "depthFunc";
        private const string DEPTH_MASK = "depthMask";
        private const string DEPTH_RANGE = "depthRange";
        private const string DISABLE = "disable";
        private const string ENABLE = "enable";
        private const string FRONT_FACE = "frontFace";
        private const string GET_PARAMETER = "getParameter";
        private const string GET_ERROR = "getError";
        private const string HINT = "hint";
        private const string IS_ENABLED = "isEnabled";
        private const string LINE_WIDTH = "lineWidth";
        private const string PIXEL_STORE_I = "pixelStorei";
        private const string POLYGON_OFFSET = "polygonOffset";
        private const string SAMPLE_COVERAGE = "sampleCoverage";
        private const string STENCIL_FUNC = "stencilFunc";
        private const string STENCIL_FUNC_SEPARATE = "stencilFuncSeparate";
        private const string STENCIL_MASK = "stencilMask";
        private const string STENCIL_MASK_SEPARATE = "stencilMaskSeparate";
        private const string STENCIL_OP = "stencilOp";
        private const string STENCIL_OP_SEPARATE = "stencilOpSeparate";
        private const string BIND_BUFFER = "bindBuffer";
        private const string BUFFER_DATA = "bufferData";
        private const string BUFFER_SUB_DATA = "bufferSubData";
        private const string CREATE_BUFFER = "createBuffer";
        private const string DELETE_BUFFER = "deleteBuffer";
        private const string GET_BUFFER_PARAMETER = "getBufferParameter";
        private const string IS_BUFFER = "isBuffer";
        private const string BIND_FRAMEBUFFER = "bindFramebuffer";
        private const string CHECK_FRAMEBUFFER_STATUS = "checkFramebufferStatus";
        private const string CREATE_FRAMEBUFFER = "createFramebuffer";
        private const string DELETE_FRAMEBUFFER = "deleteFramebuffer";
        private const string FRAMEBUFFER_RENDERBUFFER = "framebufferRenderbuffer";
        private const string FRAMEBUFFER_TEXTURE_2D = "framebufferTexture2D";
        private const string GET_FRAMEBUFFER_ATTACHMENT_PARAMETER = "getFramebufferAttachmentParameter";
        private const string IS_FRAMEBUFFER = "isFramebuffer";
        private const string READ_PIXELS = "readPixels";
        #endregion

        #region Properties
        public int DrawingBufferWidth => this.GetProperty<int>(DRAWING_BUFFER_WIDTH);
        public int DrawingBufferHeight => this.GetProperty<int>(DRAWING_BUFFER_HEIGHT);
        #endregion

        internal WebGLContext(BECanvasComponent reference, WebGLContextAttributes attributes = null) : base(reference, CONTEXT_NAME, attributes)
        {
        }

        #region Methods
        public void ClearColor(float red, float green, float blue, float alpha) => this.CallMethod<object>(CLEAR_COLOR, new object[] {red, green, blue, alpha});
        public void Clear(BufferBits mask) => this.CallMethod<object>(CLEAR, new object[] {mask});
        public WebGLContextAttributes GetContextAttributes() => this.CallMethod<WebGLContextAttributes>(GET_CONTEXT_ATTRIBUTES);
        public bool IsContextLost() => this.CallMethod<bool>(IS_CONTEXT_LOST);
        public void Scissor(int x, int y, int width, int height) => this.CallMethod<object>(SCISSOR, new object[] {x, y, width, height});
        public void Viewport(int x, int y, int width, int height) => this.CallMethod<object>(VIEWPORT, new object[] {x, y, width, height});
        public void ActiveTexture(Texture texture) => this.CallMethod<object>(ACTIVE_TEXTURE, new object[] {texture});
        public void BlendColor(float red, float green, float blue, float alpha) => this.CallMethod<object>(BLEND_COLOR, new object[] {red, green, blue, alpha});
        public void BlendEquation(BlendingEquation equation) => this.CallMethod<object>(BLEND_EQUATION, new object[] {equation});
        public void BlendEquationSeparate(BlendingEquation modeRGB, BlendingEquation modeAlpha) => this.CallMethod<object>(BLEND_EQUATION_SEPARATE, new object[] {modeRGB, modeAlpha});
        public void BlendFunc(BlendingMode sfactor, BlendingMode dfactor) => this.CallMethod<object>(BLEND_FUNC, new object[] {sfactor, dfactor});
        public void BlendFuncSeparate(BlendingMode srcRGB, BlendingMode dstRGB, BlendingMode srcAlpha, BlendingMode dstAlpha) => this.CallMethod<object>(BLEND_FUNC_SEPARATE, new object[] {srcRGB, dstRGB, srcAlpha, dstAlpha});
        public void ClearDepth(float depth) => this.CallMethod<object>(CLEAR_DEPTH, new object[] {depth});
        public void ClearStencil(int stencil) => this.CallMethod<object>(CLEAR_STENCIL, new object[] {stencil});
        public void ColorMask(bool red, bool green, bool blue, bool alpha) => this.CallMethod<object>(COLOR_MASK, new object[] {red, green, blue, alpha});
        public void CullFace(Face mode) => this.CallMethod<object>(CULL_FACE, new object[] {mode});
        public void DepthFunc(CompareFunction func) => this.CallMethod<object>(DEPTH_FUNC, new object[] {func});
        public void DepthMask(bool flag) => this.CallMethod<object>(DEPTH_MASK, new object[] {flag});
        public void DepthRange(float zNear, float zFar) => this.CallMethod<object>(DEPTH_RANGE, new object[] {zNear, zFar});
        public void Disable(EnableCap cap) => this.CallMethod<object>(DISABLE, new object[] {cap});
        public void Enable(EnableCap cap) => this.CallMethod<object>(ENABLE, new object[] {cap});
        public void FrontFace(FrontFaceDirection mode) => this.CallMethod<object>(FRONT_FACE, new object[] {mode});
        public T GetParameter<T>(Parameter parameter) => this.CallMethod<T>(GET_PARAMETER, new object[] {parameter});
        public Error GetError() => this.CallMethod<Error>(GET_ERROR);
        public void Hint(HintTarget target, HintMode mode) => this.CallMethod<object>(HINT, new object[] {target, mode});
        public bool IsEnabled(EnableCap cap) => this.CallMethod<bool>(IS_ENABLED, new object[] {cap});
        public bool LineWidth(float width) => this.CallMethod<bool>(LINE_WIDTH, new object[] {width});
        public bool PixelStoreI(PixelStorageMode pname, int param) => this.CallMethod<bool>(PIXEL_STORE_I, new object[] {pname, param});
        public void PolygonOffset(float factor, float units) => this.CallMethod<object>(POLYGON_OFFSET, new object[] {factor, units});
        public void SampleCoverage(float value, bool invert) => this.CallMethod<object>(SAMPLE_COVERAGE, new object[] {value, invert});
        public void StencilFunc(CompareFunction func, int reference, uint mask) => this.CallMethod<object>(STENCIL_FUNC, new object[] {func, reference, mask});
        public void StencilFuncSeparate(Face face, CompareFunction func, int reference, uint mask) => this.CallMethod<object>(STENCIL_FUNC_SEPARATE, new object[] {face, func, reference, mask});
        public void StencilMask(uint mask) => this.CallMethod<object>(STENCIL_MASK, new object[] {mask});
        public void StencilMaskSeparate(Face face, uint mask) => this.CallMethod<object>(STENCIL_MASK_SEPARATE, new object[] {face, mask});
        public void StencilOp(StencilFunction fail, StencilFunction zfail, StencilFunction zpass) => this.CallMethod<object>(STENCIL_OP, new object[] {fail, zfail, zpass});
        public void StencilOpSeparate(Face face, StencilFunction fail, StencilFunction zfail, StencilFunction zpass) => this.CallMethod<object>(STENCIL_OP_SEPARATE, new object[] {face, fail, zfail, zpass});

        public void BindBuffer(BufferType target, WebGLBuffer buffer) => this.CallMethod<object>(BIND_BUFFER, new object[] {target, buffer});
        public void BufferData(BufferType target, int size, BufferUsageHint usage) => this.CallMethod<object>(BUFFER_DATA, new object[] {target, size, usage});
        public void BufferData(BufferType target, byte[] data, BufferUsageHint usage) => this.CallMethod<object>(BUFFER_DATA, new object[] {target, data, usage});
        public void BufferSubData(BufferType target, uint offset, byte[] data) => this.CallMethod<object>(BUFFER_SUB_DATA, new object[] {target, offset, data});
        public WebGLBuffer CreateBuffer() => this.CallMethod<WebGLBuffer>(CREATE_BUFFER);
        public void DeleteBuffer(WebGLBuffer buffer) => this.CallMethod<WebGLBuffer>(DELETE_BUFFER, new object[] {buffer});
        public T GetBufferParameter<T>(BufferType target, BufferParameter pname) => this.CallMethod<T>(GET_BUFFER_PARAMETER, new object[] {target, pname});
        public bool IsBuffer(WebGLBuffer buffer) => this.CallMethod<bool>(IS_BUFFER, new object[] {buffer});

        public void BindFramebuffer(FramebufferType target, WebGLFramebuffer framebuffer) => this.CallMethod<object>(BIND_FRAMEBUFFER, new object[] {target, framebuffer});
        public FramebufferStatus CheckFramebufferStatus(FramebufferType target) => this.CallMethod<FramebufferStatus>(CHECK_FRAMEBUFFER_STATUS, new object[] {target});
        public WebGLFramebuffer CreateFramebuffer() => this.CallMethod<WebGLFramebuffer>(CREATE_FRAMEBUFFER);
        public void DeleteFramebuffer(WebGLFramebuffer buffer) => this.CallMethod<object>(DELETE_FRAMEBUFFER, new object[] {buffer});
        public void FramebufferRenderbuffer(FramebufferType target, FramebufferAttachment attachment, RenderbufferType renderbuffertarget, WebGLRenderbuffer renderbuffer) => this.CallMethod<object>(FRAMEBUFFER_RENDERBUFFER, new object[] {target, attachment, renderbuffertarget, renderbuffer});
        public void FramebufferTexture2D(FramebufferType target, FramebufferAttachment attachment, Texture2DType textarget, WebGLTexture texture, int level) => this.CallMethod<object>(FRAMEBUFFER_TEXTURE_2D, new object[] {target, attachment, textarget, texture, level});
        public T GetFramebufferAttachmentParameter<T>(FramebufferType target, FramebufferAttachment attachment, FramebufferAttachmentParameter pname) => this.CallMethod<T>(GET_FRAMEBUFFER_ATTACHMENT_PARAMETER, new object[] {target, attachment, pname});
        public bool IsFramebuffer(WebGLFramebuffer framebuffer) => this.CallMethod<bool>(IS_FRAMEBUFFER, new object[] {framebuffer});
        public void ReadPixels(int x, int y, int width, int height, PixelFormat format, PixelType type, byte[] pixels) => this.CallMethod<object>(READ_PIXELS, new object[] {x, y, width, height, format, type, pixels}); //pixels should be an ArrayBufferView which the data gets read into

        #endregion
    }

    public class WebGLBuffer
    { }

    public class WebGLFramebuffer
    { }

    public class WebGLRenderbuffer
    { }

    public class WebGLTexture
    { }
}
