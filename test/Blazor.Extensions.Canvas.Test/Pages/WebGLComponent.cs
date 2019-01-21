using System;
using Blazor.Extensions.Canvas.WebGL;
using Microsoft.AspNetCore.Blazor.Components;

namespace Blazor.Extensions.Canvas.Test.Pages
{
    public class WebGLComponent : BlazorComponent
    {
        protected BECanvasComponent canvasReference;

        private const string VS_SOURCE = "attribute vec3 aPos;" +
                                         "attribute vec3 aColor;" +
                                         "varying vec3 vColor;" +

                                         "void main() {" +
                                            "gl_Position = vec4(aPos, 1.0);" +
                                            "vColor = aColor;" +
                                         "}";

        private const string FS_SOURCE = "precision mediump float;" +
                                         "varying vec3 vColor;" +

                                         "void main() {" +
                                            "gl_FragColor = vec4(vColor, 1.0);" +
                                         "}";

        protected override void OnAfterRender()
        {
            WebGLContext context = this.canvasReference.CreateWebGL(new WebGLContextAttributes
            {
                PowerPreference = WebGLContextAttributes.POWER_PREFERENCE_HIGH_PERFORMANCE
            });

            context.ClearColor(0, 0, 0, 1);
            context.Clear(BufferBits.COLOR_BUFFER_BIT);

            var program = this.InitProgram(context, VS_SOURCE, FS_SOURCE);

            var vertexBuffer = context.CreateBuffer();
            context.BindBuffer(BufferType.ARRAY_BUFFER, vertexBuffer);

            var vertices = new[]
            {
                -0.5f, -0.5f, 0.0f, 1.0f, 0.0f, 0.0f,
                0.5f, -0.5f, 0.0f, 0.0f, 1.0f, 0.0f,
                0.0f,  0.5f, 0.0f, 0.0f, 0.0f, 1.0f
            };
            context.BufferData(BufferType.ARRAY_BUFFER, vertices, BufferUsageHint.STATIC_DRAW);

            context.VertexAttribPointer(0, 3, DataType.FLOAT, false, 6 * sizeof(float), 0);
            context.VertexAttribPointer(1, 3, DataType.FLOAT, false, 6 * sizeof(float), 3 * sizeof(float));
            context.EnableVertexAttribArray(0);
            context.EnableVertexAttribArray(1);

            context.UseProgram(program);

            context.DrawArrays(Primitive.TRIANGLES, 0, 3);
        }

        private WebGLProgram InitProgram(WebGLContext gl, string vsSource, string fsSource)
        {
            var vertexShader = this.LoadShader(gl, ShaderType.VERTEX_SHADER, vsSource);
            var fragmentShader = this.LoadShader(gl, ShaderType.FRAGMENT_SHADER, fsSource);

            var program = gl.CreateProgram();
            gl.AttachShader(program, vertexShader);
            gl.AttachShader(program, fragmentShader);
            gl.LinkProgram(program);

            gl.DeleteShader(vertexShader);
            gl.DeleteShader(fragmentShader);

            if (!gl.GetProgramParameter<bool>(program, ProgramParameter.LINK_STATUS))
            {
                string info = gl.GetProgramInfoLog(program);
                throw new Exception("An error occured while linking the program: " + info);
            }

            return program;
        }

        private WebGLShader LoadShader(WebGLContext gl, ShaderType type, string source)
        {
            var shader = gl.CreateShader(type);

            gl.ShaderSource(shader, source);
            gl.CompileShader(shader);

            if (!gl.GetShaderParameter<bool>(shader, ShaderParameter.COMPILE_STATUS))
            {
                string info = gl.GetShaderInfoLog(shader);
                gl.DeleteShader(shader);
                throw new Exception("An error occured while compiling the shader: " + info);
            }

            return shader;
        }
    }
}
