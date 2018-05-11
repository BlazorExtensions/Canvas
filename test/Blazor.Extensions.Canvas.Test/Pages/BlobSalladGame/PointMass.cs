using System;
using System.Numerics;

namespace Blazor.Extensions.Canvas.Test.BlobSalladGame
{
    public class PointMass
    {
        public Vector2 Cur { get; set; }
        public Vector2 Prev { get; set; }
        public double Mass { get; set; }
        public Vector2 Force { get; set; }
        public Vector2 Result { get; set; }
        public double Friction { get; set; } = 0.01F;
        public double Velocity
        {
            get
            {
                double cXpX, cYpY = 0;
                cXpX = this.Cur.X - this.Prev.X;
                cYpY = this.Cur.Y - this.Prev.Y;
                return cXpX * cXpX + cYpY * cYpY;
            }
        }

        public PointMass(double cx, double cy, double mass)
        {
            this.Cur = new Vector2((float)cx, (float)cy);
            this.Prev = new Vector2((float)cx, (float)cy);
            this.Mass = mass;
            this.Force = new Vector2();
            this.Result = new Vector2();
            this.Friction = 0.01;
        }

        public void Move(double dt)
        {
            double t, a, c, dtdt = 0;

            dtdt = dt * dt;

            a = this.Force.X / this.Mass;
            c = this.Cur.X;
            t = (2.0 - this.Friction) * c - (1.0 - this.Friction) * this.Prev.X + a * dtdt;
            this.Prev = new Vector2((float)c, this.Prev.Y);
            this.Cur = new Vector2((float)t, this.Cur.Y);

            a = this.Force.Y / this.Mass;
            c = this.Cur.Y;
            t = (2.0 - this.Friction) * c - (1.0 - this.Friction) * this.Prev.Y + a * dtdt;
            this.Prev = new Vector2(this.Prev.X, (float)c);
            this.Cur = new Vector2(this.Prev.X, (float)t);
        }

        public void Draw(Canvas2dContext ctx, double scaleFactor)
        {
            ctx.LineWidth = 2;
            ctx.FillStyle = "#000000";
            ctx.StrokeStyle = "#000000";
            ctx.BeginPath();
            ctx.Arc(this.Cur.X * scaleFactor,
                    this.Cur.Y * scaleFactor,
                    4.0, 0.0, Math.PI * 2.0, true);
            ctx.Fill();
        }

        public double Dist(PointMass pointMass)
        {
            var aXbX = this.Cur.X - pointMass.Cur.X;
            var aYbY = this.Cur.Y - pointMass.Cur.Y;

            return Math.Sqrt(aXbX * aXbX + aYbY * aYbY);
        }
    }
}
