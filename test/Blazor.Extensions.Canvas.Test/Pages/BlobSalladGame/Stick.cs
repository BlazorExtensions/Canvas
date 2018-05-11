using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Threading.Tasks;

namespace Blazor.Extensions.Canvas.Test.BlobSalladGame
{
    public class Stick
    {
        public double Length { get; set; }
        public double LengthSquared { get; set; }
        public PointMass PointMassA { get; private set; }
        public PointMass PointMassB { get; private set; }
        public Vector2 Delta { get; set; }

        public Stick(PointMass pointMassA, PointMass pointMassB)
        {
            this.PointMassA = pointMassA;
            this.PointMassB = pointMassB;

            this.Length = this.PointMassA.Dist(this.PointMassB);
            this.LengthSquared = this.Length * this.Length;
        }

        public void Scale(double scaleFactor)
        {
            this.Length *= scaleFactor;
            this.LengthSquared = this.Length * this.Length;
        }

        public void Sc(Environment env)
        {
            this.Delta = this.PointMassB.Cur;
            this.Delta -= this.PointMassA.Cur;

            var dotProd = this.Delta.X * this.Delta.X + this.Delta.Y * this.Delta.Y;
            var scaleFactor = this.LengthSquared / (dotProd + this.LengthSquared) - 0.5;

            this.Delta = new Vector2(this.Delta.X * (float)scaleFactor, this.Delta.Y * (float)scaleFactor);

            this.PointMassA.Cur -= this.Delta;
            this.PointMassB.Cur += this.Delta;
        }

        public void SetForce(Vector2 force)
        {
            this.PointMassA.Force = force;
            this.PointMassB.Force = force;
        }

        public void AddForce(Vector2 force)
        {
            this.PointMassA.Force += force;
            this.PointMassB.Force += force;
        }

        public void Move(double dt)
        {
            this.PointMassA.Move(dt);
            this.PointMassB.Move(dt);
        }

        public void Draw(Canvas2dContext ctx, double scaleFactor)
        {
            this.PointMassA.Draw(ctx, scaleFactor);
            this.PointMassB.Draw(ctx, scaleFactor);

            ctx.LineWidth = 3;
            ctx.FillStyle = "#000000";
            ctx.StrokeStyle = "#000000";
            ctx.BeginPath();
            ctx.MoveTo(this.PointMassA.Cur.X * scaleFactor,
                       this.PointMassA.Cur.Y * scaleFactor);
            ctx.LineTo(this.PointMassB.Cur.X * scaleFactor,
                       this.PointMassB.Cur.Y * scaleFactor);
            ctx.Stroke();
        }
    }
}
