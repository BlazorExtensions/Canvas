using System;
using System.Collections.Generic;
using System.Numerics;

namespace Blazor.Extensions.Canvas.Test.BlobSalladGame
{
    public class Blob
    {
        public double X { get; private set; }
        public double Y { get; private set; }
        public Dictionary<int, Stick> Sticks { get; set; } = new Dictionary<int, Stick>();
        public Dictionary<int, PointMass> PointMasses { get; set; } = new Dictionary<int, PointMass>();
        public Dictionary<int, Joint> Joints { get; set; } = new Dictionary<int, Joint>();
        public PointMass MiddlePointMass { get; set; }
        public double Radius { get; private set; }
        public double DrawFaceStyle { get; private set; }
        public double DrawEyeStyle { get; private set; }
        public bool Selected { get; set; }
        public double XPos => this.MiddlePointMass.Cur.X;
        public double YPos => this.MiddlePointMass.Cur.Y;

        //private double f = 0.1;
        private double low = 0.95;
        private double high = 1.05;
        private double t;
        private int p;
        private int i;

        public Blob(double x, double y, double radius, int numPointMasses)
        {
            this.X = x;
            this.Y = y;
            this.Radius = radius;
            numPointMasses = 8;

            for (this.i = 0; this.i < numPointMasses; this.i++)
            {
                this.PointMasses[this.i] = new PointMass(Math.Cos(this.t) * radius + x, Math.Sin(this.t) * radius + y, 1.0);
                this.t += 2.0 * Math.PI / numPointMasses;
            }

            this.MiddlePointMass = new PointMass(x, y, 1.0);

            this.PointMasses[0].Mass = 4.0;
            this.PointMasses[1].Mass = 4.0;

            for (this.i = 0; this.i < numPointMasses; this.i++)
            {
                this.Sticks[this.i] = new Stick(this.PointMasses[this.i], this.PointMasses[ClampIndex(this.i + 1, numPointMasses)]);
            }

            for (this.i = 0, this.p = 0; this.i < numPointMasses; this.i++)
            {
                this.Joints[this.p++] = new Joint(this.PointMasses[this.i], this.PointMasses[ClampIndex(this.i + numPointMasses / 2 + 1, numPointMasses)], this.low, this.high);
                this.Joints[this.p++] = new Joint(this.PointMasses[this.i], this.MiddlePointMass, this.high * 0.9, this.low * 1.1); // 0.8, 1.2 works  
            }
        }

        public void AddBlob(Blob blob)
        {
            var index = this.Joints.Count;

            this.Joints[index] = new Joint(this.MiddlePointMass, blob.MiddlePointMass, 0.0, 0.0);
            var dist = this.Radius + blob.Radius;
            this.Joints[index].SetDist(dist * 0.95, 0.0);
        }

        public void Scale(double scaleFactor)
        {
            for (this.i = 0; this.i < this.Joints.Count; this.i++)
            {
                this.Joints[this.i].Scale(scaleFactor);
            }
            for (this.i = 0; this.i < this.Sticks.Count; this.i++)
            {
                this.Sticks[this.i].Scale(scaleFactor);
            }
            this.Radius *= scaleFactor;
        }

        public void Move(double dt)
        {
            for (this.i = 0; this.i < this.PointMasses.Count; this.i++)
            {
                this.PointMasses[this.i].Move(dt);
            }
            this.MiddlePointMass.Move(dt);
        }

        public void Sc(Environment env)
        {
            for (int j = 0; j < 4; j++)
            {
                for (this.i = 0; this.i < this.PointMasses.Count; this.i++)
                {
                    if (env.Collision(this.PointMasses[this.i].Cur, this.PointMasses[this.i].Cur) == true)
                    {
                        this.PointMasses[this.i].Friction = 0.75;
                    }
                    else
                    {
                        this.PointMasses[this.i].Friction = 0.01;
                    }
                }
                for (this.i = 0; this.i < this.Sticks.Count; this.i++)
                {
                    this.Sticks[this.i].Sc(env);
                }
                for (this.i = 0; this.i < this.Joints.Count; this.i++)
                {
                    this.Joints[this.i].Sc();
                }
            }
        }

        public void SetForce(Vector2 force)
        {
            for (this.i = 0; this.i < this.PointMasses.Count; this.i++)
            {
                this.PointMasses[this.i].Force = force;
            }
            this.MiddlePointMass.Force = force;
        }

        public void AddForce(Vector2 force)
        {
            for (this.i = 0; this.i < this.PointMasses.Count; this.i++)
            {
                this.PointMasses[this.i].Force += force;
            }
            this.MiddlePointMass.Force += force;
            this.PointMasses[0].Force += force;
            this.PointMasses[0].Force += force;
            this.PointMasses[0].Force += force;
            this.PointMasses[0].Force += force;
        }

        public void MoveTo(double x, double y)
        {
            Vector2 blobPos;

            blobPos = this.MiddlePointMass.Cur;
            x -= blobPos.X;
            y -= blobPos.Y;

            for (this.i = 0; this.i < this.PointMasses.Count; this.i++)
            {
                blobPos = this.PointMasses[this.i].Cur;
                blobPos.X += (float)x;
                blobPos.Y += (float)y;
            }
            blobPos = this.MiddlePointMass.Cur;
            blobPos.X += (float)x;
            blobPos.Y += (float)y;
        }

        public void DrawEars(Canvas2dContext ctx, double scaleFactor)
        {
            ctx.StrokeStyle = "#000000";
            ctx.FillStyle = "#FFFFFF";
            ctx.LineWidth = 2;

            ctx.BeginPath();
            ctx.MoveTo((-0.55 * this.Radius) * scaleFactor, (-0.35 * this.Radius) * scaleFactor);
            ctx.LineTo((-0.52 * this.Radius) * scaleFactor, (-0.55 * this.Radius) * scaleFactor);
            ctx.LineTo((-0.45 * this.Radius) * scaleFactor, (-0.40 * this.Radius) * scaleFactor);
            ctx.Fill();
            ctx.Stroke();

            ctx.BeginPath();
            ctx.MoveTo((0.55 * this.Radius) * scaleFactor, (-0.35 * this.Radius) * scaleFactor);
            ctx.LineTo((0.52 * this.Radius) * scaleFactor, (-0.55 * this.Radius) * scaleFactor);
            ctx.LineTo((0.45 * this.Radius) * scaleFactor, (-0.40 * this.Radius) * scaleFactor);
            ctx.Fill();
            ctx.Stroke();
        }

        public void DrawHappyEyes1(Canvas2dContext ctx, double scaleFactor)
        {
            ctx.LineWidth = 1;
            ctx.FillStyle = "#FFFFFF";
            ctx.BeginPath();
            ctx.Arc((-0.15 * this.Radius) * scaleFactor,
                    (-0.20 * this.Radius) * scaleFactor,
                    this.Radius * 0.12 * scaleFactor, 0, 2.0 * Math.PI, false);
            ctx.Fill();
            ctx.Stroke();

            ctx.BeginPath();
            ctx.Arc((0.15 * this.Radius) * scaleFactor,
                    (-0.20 * this.Radius) * scaleFactor,
                    this.Radius * 0.12 * scaleFactor, 0, 2.0 * Math.PI, false);
            ctx.Fill();
            ctx.Stroke();

            ctx.FillStyle = "#000000";
            ctx.BeginPath();
            ctx.Arc((-0.15 * this.Radius) * scaleFactor,
                    (-0.17 * this.Radius) * scaleFactor,
                    this.Radius * 0.06 * scaleFactor, 0, 2.0 * Math.PI, false);
            ctx.Fill();

            ctx.BeginPath();
            ctx.Arc((0.15 * this.Radius) * scaleFactor,
                    (-0.17 * this.Radius) * scaleFactor,
                    this.Radius * 0.06 * scaleFactor, 0, 2.0 * Math.PI, false);
            ctx.Fill();
        }

        public void DrawHappyEyes2(Canvas2dContext ctx, double scaleFactor)
        {
            ctx.LineWidth = 1;
            ctx.FillStyle = "#FFFFFF";
            ctx.BeginPath();
            ctx.Arc((-0.15 * this.Radius) * scaleFactor,
                    (-0.20 * this.Radius) * scaleFactor,
                    this.Radius * 0.12 * scaleFactor, 0, 2.0 * Math.PI, false);
            ctx.Stroke();

            ctx.BeginPath();
            ctx.Arc((0.15 * this.Radius) * scaleFactor,
                    (-0.20 * this.Radius) * scaleFactor,
                    this.Radius * 0.12 * scaleFactor, 0, 2.0 * Math.PI, false);
            ctx.Stroke();

            ctx.LineWidth = 1;
            ctx.BeginPath();
            ctx.MoveTo((-0.25 * this.Radius) * scaleFactor,
                       (-0.20 * this.Radius) * scaleFactor);
            ctx.LineTo((-0.05 * this.Radius) * scaleFactor,
                       (-0.20 * this.Radius) * scaleFactor);
            ctx.Stroke();

            ctx.BeginPath();
            ctx.MoveTo((0.25 * this.Radius) * scaleFactor,
                       (-0.20 * this.Radius) * scaleFactor);
            ctx.LineTo((0.05 * this.Radius) * scaleFactor,
                       (-0.20 * this.Radius) * scaleFactor);
            ctx.Stroke();
        }

        public void DrawHappyFace1(Canvas2dContext ctx, double scaleFactor)
        {
            ctx.LineWidth = 2;
            ctx.StrokeStyle = "#000000";
            ctx.FillStyle = "#000000";
            ctx.BeginPath();
            ctx.Arc(0.0, 0.0,
              this.Radius * 0.25 * scaleFactor, 0, Math.PI, false);
            ctx.Stroke();
        }

        public void DrawHappyFace2(Canvas2dContext ctx, double scaleFactor)
        {
            ctx.LineWidth = 2;
            ctx.StrokeStyle = "#000000";
            ctx.FillStyle = "#000000";
            ctx.BeginPath();
            ctx.Arc(0.0, 0.0,
              this.Radius * 0.25 * scaleFactor, 0, Math.PI, false);
            ctx.Fill();
        }

        public void DrawOohFace(Canvas2dContext ctx, double scaleFactor)
        {
            ctx.LineWidth = 2;
            ctx.StrokeStyle = "#000000";
            ctx.FillStyle = "#000000";
            ctx.BeginPath();
            ctx.Arc(0.0, (0.1 * this.Radius) * scaleFactor,
              this.Radius * 0.25 * scaleFactor, 0, Math.PI, false);
            ctx.Fill();

            ctx.BeginPath();

            ctx.MoveTo((-0.25 * this.Radius) * scaleFactor, (-0.3 * this.Radius) * scaleFactor);
            ctx.LineTo((-0.05 * this.Radius) * scaleFactor, (-0.2 * this.Radius) * scaleFactor);
            ctx.LineTo((-0.25 * this.Radius) * scaleFactor, (-0.1 * this.Radius) * scaleFactor);

            ctx.MoveTo((0.25 * this.Radius) * scaleFactor, (-0.3 * this.Radius) * scaleFactor);
            ctx.LineTo((0.05 * this.Radius) * scaleFactor, (-0.2 * this.Radius) * scaleFactor);
            ctx.LineTo((0.25 * this.Radius) * scaleFactor, (-0.1 * this.Radius) * scaleFactor);

            ctx.Stroke();
        }

        public void DrawFace(Canvas2dContext ctx, double scaleFactor)
        {
            var random = new Random();

            if (this.DrawFaceStyle == 1 && random.NextDouble() < 0.05)
            {
                this.DrawFaceStyle = 2;
            }
            else if (this.DrawFaceStyle == 2 && random.NextDouble() < 0.1)
            {
                this.DrawFaceStyle = 1;
            }

            if (this.DrawEyeStyle == 1 && random.NextDouble() < 0.025)
            {
                this.DrawEyeStyle = 2;
            }
            else if (this.DrawEyeStyle == 2 && random.NextDouble() < 0.3)
            {
                this.DrawEyeStyle = 1;
            }

            if (this.MiddlePointMass.Velocity > 0.004)
            {
                this.DrawOohFace(ctx, scaleFactor);
            }
            else
            {
                if (this.DrawFaceStyle == 1)
                {
                    this.DrawHappyFace1(ctx, scaleFactor);
                }
                else
                {
                    this.DrawHappyFace2(ctx, scaleFactor);
                }

                if (this.DrawEyeStyle == 1)
                {
                    this.DrawHappyEyes1(ctx, scaleFactor);
                }
                else
                {
                    this.DrawHappyEyes2(ctx, scaleFactor);
                }
            }
        }

        public PointMass GetPointMass(int index)
        {
            index += this.PointMasses.Count;
            index = index % this.PointMasses.Count;
            return this.PointMasses[index];
        }

        public void DrawBody(Canvas2dContext ctx, double scaleFactor)
        {
            ctx.StrokeStyle = "#000000";
            if (this.Selected == true)
            {
                ctx.FillStyle = "#FFCCCC";
            }
            else
            {
                ctx.FillStyle = "#FFFFFF";
            }
            ctx.LineWidth = 5;
            ctx.BeginPath();
            ctx.MoveTo(this.PointMasses[0].Cur.X * scaleFactor,
              this.PointMasses[0].Cur.Y * scaleFactor);

            for (this.i = 0; this.i < this.PointMasses.Count; this.i++)
            {
                double px, py, nx, ny, tx, ty, cx, cy;
                PointMass prevPointMass, currentPointMass, nextPointMass, nextNextPointMass;

                prevPointMass = this.GetPointMass(this.i - 1);
                currentPointMass = this.PointMasses[this.i];
                nextPointMass = this.GetPointMass(this.i + 1);
                nextNextPointMass = this.GetPointMass(this.i + 2);

                tx = nextPointMass.Cur.X;
                ty = nextPointMass.Cur.Y;

                cx = currentPointMass.Cur.X;
                cy = currentPointMass.Cur.Y;

                px = cx * 0.5 + tx * 0.5;
                py = cy * 0.5 + ty * 0.5;

                nx = cx - prevPointMass.Cur.X + tx - nextNextPointMass.Cur.X;
                ny = cy - prevPointMass.Cur.Y + ty - nextNextPointMass.Cur.Y;

                px += nx * 0.16;
                py += ny * 0.16;

                px = px * scaleFactor;
                py = py * scaleFactor;

                tx = tx * scaleFactor;
                ty = ty * scaleFactor;

                ctx.BezierCurveTo(px, py, tx, ty, tx, ty);
            }

            ctx.ClosePath();
            ctx.Stroke();
            ctx.Fill();
        }

        public void DrawSimpleBody(Canvas2dContext ctx, double scaleFactor)
        {
            for (this.i = 0; this.i < this.Sticks.Count; this.i++)
            {
                this.Sticks[this.i].Draw(ctx, scaleFactor);
            }
        }

        public void Draw(Canvas2dContext ctx, double scaleFactor)
        {            
            this.DrawBody(ctx, scaleFactor);

            ctx.StrokeStyle = "#000000";
            ctx.FillStyle = "#000000";

            ctx.Save();
            ctx.Translate(this.MiddlePointMass.Cur.X * scaleFactor,
              (this.MiddlePointMass.Cur.Y - 0.35 * this.Radius) * scaleFactor);

            var up = new Vector2((float)0.0, (float)-1.0);
            var ori = this.PointMasses[0].Cur;
            ori += this.MiddlePointMass.Cur;
            var dp = ori.X * up.X + up.Y * up.Y;
            var ang = Math.Acos(dp / ori.Length());
            if (ori.X < 0.0)
            {
                ctx.Rotate((float)-ang);
            }
            else
            {
                ctx.Rotate((float)ang);
            }

            // this.drawEars(ctx, scaleFactor); 
            this.DrawFace(ctx, scaleFactor);

            ctx.Restore();
        }

        private int ClampIndex(int index, int maxIndex)
        {
            index += maxIndex;
            return index % maxIndex;
        }
    }
}
