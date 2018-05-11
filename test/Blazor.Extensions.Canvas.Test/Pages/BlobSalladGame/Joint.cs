using System.Numerics;

namespace Blazor.Extensions.Canvas.Test.BlobSalladGame
{
    public class Joint
    {
        public PointMass PointMassA { get; private set; }
        public PointMass PointMassB { get; private set; }
        public Vector2 Delta { get; set; }
        public double ShortConst { get; set; }
        public double LongConst { get; set; }
        public double ScSquared { get; set; }
        public double LcSquared { get; set; }


        public Joint(PointMass pointMassA, PointMass pointMassB, double shortConst, double longConst)
        {
            this.PointMassA = pointMassA;
            this.PointMassB = pointMassB;

            this.Delta = pointMassB.Cur;
            this.Delta -= pointMassA.Cur;

            this.ShortConst = this.Delta.Length() * shortConst;
            this.LongConst = this.Delta.Length() * longConst;
            this.ScSquared = this.ShortConst * this.ShortConst;
            this.LcSquared = this.LongConst * this.LongConst;
        }

        public void SetDist(double shortConst, double longConst)
        {
            this.ShortConst = shortConst;
            this.LongConst = longConst;
            this.ScSquared = this.ShortConst * this.ShortConst;
            this.LcSquared = this.LongConst * this.LongConst;
        }

        public void Scale(double scaleFactor)
        {
            this.ShortConst = this.ShortConst * scaleFactor;
            this.LongConst = this.LongConst * scaleFactor;
            this.ScSquared = this.ShortConst * this.ShortConst;
            this.LcSquared = this.LongConst * this.LongConst;
        }

        public void Sc()
        {
            this.Delta = this.PointMassB.Cur;
            this.Delta -= this.PointMassA.Cur;

            var dp = this.Delta.X * this.Delta.X + this.Delta.Y * this.Delta.Y;

            if (this.ShortConst != 0.0 && dp < this.ScSquared)
            {
                var scaleFactor = this.ScSquared / (dp + this.ScSquared) - 0.5;
                this.Delta = new Vector2(this.Delta.X * (float)scaleFactor, this.Delta.Y * (float)scaleFactor);

                this.PointMassA.Cur -= this.Delta;
                this.PointMassB.Cur += this.Delta;
            }
            else if (this.LongConst != 0.0 && dp > this.LcSquared)
            {
                var scaleFactor = this.LcSquared / (dp + this.LcSquared) - 0.5;

                this.Delta = new Vector2(this.Delta.X * (float)scaleFactor, this.Delta.Y * (float)scaleFactor);

                this.PointMassA.Cur -= this.Delta;
                this.PointMassB.Cur += this.Delta;
            }
        }

        public void Stick(PointMass pointMassA, PointMass pointMassB)
        {

        }
    }

}
