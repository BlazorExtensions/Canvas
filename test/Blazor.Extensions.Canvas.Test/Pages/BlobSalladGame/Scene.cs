using System;
using System.Numerics;
using System.Threading.Tasks;

namespace Blazor.Extensions.Canvas.Test.BlobSalladGame
{
    public class Scene
    {
        public Environment Env { get; set; }
        public double Width { get; set; }
        public double Height { get; set; }
        public double ScaleFactor { get; set; }
        public BlobCollective BlobColl { get; set; }
        public Vector2 Gravity { get; set; }
        public bool Stopped { get; set; }
        public Vector2 SavedMouseCoords { get; set; }
        public (double x, double y) SelectedOffset { get; set; }
        public Canvas2dContext Context { get; private set; }

        public Scene(Canvas2dContext context, double width, double height, double scaleFactor)
        {
            this.Width = width;
            this.Height = height;
            this.ScaleFactor = scaleFactor;
            this.Context = context;
            this.Env = new Environment(0.2, 0.2, 2.6, 1.6);
            this.BlobColl = new BlobCollective(1.0, 1.0, 1, 200);
            this.Gravity = new Vector2(0, 10);
            this.Stopped = false;
        }

        public void Update()
        {
            var dt = 0.05;

            if (this.SavedMouseCoords != default && this.SelectedOffset != default)
            {
                this.BlobColl.SelectedBlobMoveTo(this.SavedMouseCoords.X - this.SelectedOffset.x,
                        this.SavedMouseCoords.Y - this.SelectedOffset.y);
            }

            this.BlobColl.Move(dt);
            this.BlobColl.Sc(this.Env);
            this.BlobColl.SetForce(this.Gravity);
        }

        public void Draw()
        {
            this.Context.ClearRect(0, 0, this.Width, this.Height);

            //this.Env.Draw(this.Context, this.ScaleFactor);
            this.BlobColl.Draw(this.Context, this.ScaleFactor);
            Console.WriteLine("Draw");
        }

        public void Timeout()
        {
            Task.Run(() =>
            {
                do
                {
                    this.Draw();
                    this.Update();
                } while (!this.Stopped);
            });
        }

        public void HandleKeyPress(int keyCode)
        {
            switch (keyCode)
            {
                // left 
                case 37:
                    this.BlobColl.AddForce(new Vector2(-50, 0));
                    break;

                // up 
                case 38:
                    this.BlobColl.AddForce(new Vector2(0, -50));
                    break;

                // right 
                case 39:
                    this.BlobColl.AddForce(new Vector2(50, 0));
                    break;

                // down
                case 40:
                    this.BlobColl.AddForce(new Vector2(0, 50));
                    break;

                // join 'j' 
                case 74:
                    this.BlobColl.Join();
                    break;

                // split 'h'
                case 72:
                    this.BlobColl.Split();
                    break;

                // toggle gravity 'g'
                case 71:
                    ToggleGravity();
                    break;

                default:
                    break;
            }
        }

        private void ToggleGravity()
        {
            if (this.Gravity.Y > 0.0)
            {
                this.Gravity = new Vector2(this.Gravity.X, 0);
            }
            else
            {
                this.Gravity = new Vector2(this.Gravity.X, 10);
            }
        }

        public void Stop() => this.Stopped = false;

        public void Start()
        {
            this.Stopped = false;
            this.Timeout();
        }
    }
}
