using System.Numerics;

namespace Blazor.Extensions.Canvas.Test.BlobSalladGame
{
    public class Environment
    {
        public double Left { get; set; }
        public double Right { get; set; }
        public double Top { get; set; }
        public double Bottom { get; set; }
        public Vector2 R { get; set; }

        public Environment(double x, double y, double w, double h)
        {
            this.Left = x;
            this.Right = x + w;
            this.Top = y;
            this.Bottom = y + h;
            this.R = new Vector2(0.0f, 0.0f);
        }

        public bool Collision(Vector2 curPos, Vector2 prevPos)
        {
            if (curPos.X < this.Left)
            {
                curPos.X = (float)this.Left;
                return true;
            }
            else if (curPos.X > this.Right)
            {
                curPos.X = (float)this.Right;
                return true;
            }

            if (curPos.Y < this.Top)
            {
                curPos.Y = (float)this.Top;
                return true;
            }
            else if (curPos.Y > this.Bottom)
            {
                curPos.Y = (float)this.Bottom;
                return true;
            }

            return false;
        }
    }
}
