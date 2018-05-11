using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Threading.Tasks;

namespace Blazor.Extensions.Canvas.Test.BlobSalladGame
{
    public class BlobCollective
    {
        public double MaxNum { get; set; }
        public double NumActive { get; set; }
        public Dictionary<int, Blob> Blobs { get; set; } = new Dictionary<int, Blob>();
        public Vector2 TmpForce { get; set; } = new Vector2();
        public Blob SelectedBlob { get; set; }

        public BlobCollective(double x, double y, double startNum, double maxNum)
        {
            this.Blobs[0] = new Blob(x, y, 0.4, 8);
        }

        public void Split()
        {
            double maxRadius = 0.0;
            int emptySlot;
            Blob motherBlob = null, newBlob = null;

            if (this.NumActive == this.MaxNum)
            {
                return;
            }

            emptySlot = this.Blobs.Count;
            for (var i = 0; i < this.Blobs.Count; i++)
            {
                if (this.Blobs[i] != null && this.Blobs[i].Radius > maxRadius)
                {
                    maxRadius = this.Blobs[i].Radius;
                    motherBlob = this.Blobs[i];
                }
                else if (this.Blobs[i] == null)
                {
                    emptySlot = i;
                }
            }

            motherBlob.Scale(0.75);
            newBlob = new Blob(motherBlob.X,
              motherBlob.Y, motherBlob.Radius, 8);

            for (var i = 0; i < this.Blobs.Count; i++)
            {
                if (this.Blobs[i] == null)
                {
                    continue;
                }
                this.Blobs[i].AddBlob(newBlob);
                newBlob.AddBlob(this.Blobs[i]);
            }
            this.Blobs[emptySlot] = newBlob;

            this.NumActive++;
        }

        public int FindSmallest(int exclude)
        {
            var minRadius = 1000.0;
            int minIndex = 0;

            for (var i = 0; i < this.Blobs.Count; i++)
            {
                if (i == exclude || this.Blobs[i] == null)
                {
                    continue;
                }
                if (this.Blobs[i].Radius < minRadius)
                {
                    minIndex = i;
                    minRadius = this.Blobs[i].Radius;
                }
            }
            return minIndex;
        }

        public int FindClosest(int exclude)
        {
            var minDist = 1000.0;
            int foundIndex = 0;
            double dist, aXbX, aYbY;
            PointMass myPointMass, otherPointMass;

            myPointMass = this.Blobs[exclude].MiddlePointMass;
            for (var i = 0; i < this.Blobs.Count; i++)
            {
                if (i == exclude || this.Blobs[i] == null)
                {
                    continue;
                }

                otherPointMass = this.Blobs[i].MiddlePointMass;
                aXbX = myPointMass.Cur.X - otherPointMass.Cur.X;
                aYbY = myPointMass.Cur.Y - otherPointMass.Cur.Y;
                dist = aXbX * aXbX + aYbY * aYbY;
                if (dist < minDist)
                {
                    minDist = dist;
                    foundIndex = i;
                }
            }
            return foundIndex;
        }

        public void Join()
        {
            int blob1Index, blob2Index;
            double r1, r2, r3;

            if (this.NumActive == 1)
            {
                return;
            }

            blob1Index = this.FindSmallest(-1);
            blob2Index = this.FindClosest(blob1Index);

            r1 = this.Blobs[blob1Index].Radius;
            r2 = this.Blobs[blob2Index].Radius;
            r3 = Math.Sqrt(r1 * r1 + r2 * r2);

            this.Blobs[blob1Index] = null;
            this.Blobs[blob2Index].Scale(0.945 * r3 / r2);

            this.NumActive--;

        }

        public (double x, double y) SelectBlob(double x, double y)
        {
            var minDist = 10000.0;
            PointMass otherPointMass = null;
            (double x, double y) selectOffset = default;

            if (this.SelectedBlob != null)
            {
                return default;
            }

            for (var i = 0; i < this.Blobs.Count; i++)
            {
                if (this.Blobs[i] == null)
                {
                    continue;
                }

                otherPointMass = this.Blobs[i].MiddlePointMass;
                var aXbX = x - otherPointMass.Cur.X;
                var aYbY = y - otherPointMass.Cur.Y;
                var dist = aXbX * aXbX + aYbY * aYbY;
                if (dist < minDist)
                {
                    minDist = dist;
                    if (dist < this.Blobs[i].Radius * 0.5)
                    {
                        this.SelectedBlob = this.Blobs[i];
                        selectOffset = (aXbX, aYbY);
                    }
                }
            }

            if (this.SelectedBlob != null)
            {
                this.SelectedBlob.Selected = true;
            }
            return selectOffset;
        }

        public void UnSelectBlob()
        {
            if (this.SelectedBlob == null)
            {
                return;
            }
            this.SelectedBlob.Selected = false;
            this.SelectedBlob = null;
        }

        public void SelectedBlobMoveTo(double x, double y)
        {
            if (this.SelectedBlob == null)
            {
                return;
            }
            this.SelectedBlob.MoveTo(x, y);
        }

        public void Move(double dt)
        {
            for (var i = 0; i < this.Blobs.Count; i++)
            {
                if (this.Blobs[i] == null)
                {
                    continue;
                }
                this.Blobs[i].Move(dt);
            }
        }

        public void Sc(Environment env)
        {
            for (var i = 0; i < this.Blobs.Count; i++)
            {
                if (this.Blobs[i] == null)
                {
                    continue;
                }
                this.Blobs[i].Sc(env);
            }
            //Where is it?!?!
            //if (this.blobAnchor != null)
            //{
            //    this.blobAnchor.sc();
            //}
        }

        public void SetForce(Vector2 force)
        {
            for (var i = 0; i < this.Blobs.Count; i++)
            {
                if (this.Blobs[i] == null)
                {
                    continue;
                }
                if (this.Blobs[i] == this.SelectedBlob)
                {
                    this.Blobs[i].SetForce(new Vector2(0, 0));
                    continue;
                }
                this.Blobs[i].SetForce(force);
            }
        }

        public void AddForce(Vector2 force)
        {
            for (var i = 0; i < this.Blobs.Count; i++)
            {
                if (this.Blobs[i] == null)
                {
                    continue;
                }
                if (this.Blobs[i] == this.SelectedBlob)
                {
                    continue;
                }
                var rnd = new Random();
                this.TmpForce = new Vector2(
                    (float)(force.X * (rnd.NextDouble() * 0.75 + 0.25)),
                    (float)(force.Y * (rnd.NextDouble() * 0.75 + 0.25)));
                this.Blobs[i].AddForce(this.TmpForce);
            }
        }

        public void Draw(Canvas2dContext ctx, double scaleFactor)
        {
            for (var i = 0; i < this.Blobs.Count; i++)
            {
                if (this.Blobs[i] == null)
                {
                    continue;
                }
                this.Blobs[i].Draw(ctx, scaleFactor);
            }
        }
    }
}
