using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace TrafficLight
{
    [Serializable]
    class Pedestrian : TrafficMember
    {
        public Pedestrian(int pedestrianID, List<Point> pedestrianPath)
        {
            this.PedestrianID = pedestrianID;
            this.Speed = 0;
            this.Position = pedestrianPath.First();
            this.CurrentDestination = pedestrianPath.Last();
        }

        public bool CanPass { get; set; }

        public Point StartPosition { get; set; }

        public Point CurrentDestination { get; set; }

        public int PedestrianID { get; set; }

        public Point Position { get; set; }

        public void Walk()
        {
            if (this.Position == this.StartPosition)
            {
                if (this.CanPass)
                {
                    this.Speed = 2;
                    if (this.Position.X < this.CurrentDestination.X)
                    {
                        this.Position = new Point(this.Position.X + this.Speed, this.Position.Y);
                    }
                    else if (this.Position.X > this.CurrentDestination.X)
                    {
                        this.Position = new Point(this.Position.X - this.Speed, this.Position.Y);
                    }
                    if (this.Position.Y < this.CurrentDestination.Y)
                    {
                        this.Position = new Point(this.Position.X, this.Position.Y + this.Speed);
                    }
                    else if (this.Position.Y > this.CurrentDestination.Y)
                    {
                        this.Position = new Point(this.Position.X, this.Position.Y - this.Speed);
                    }
                }
            }
        }

        public override void Draw(Graphics gr, ImageList il)
        {
            int radius = 4;
            base.Draw(gr, il);
            gr.FillEllipse(Brushes.Coral, new Rectangle(new Point(this.Position.X - radius, this.Position.Y - radius), new Size(radius * 2, radius * 2)));
        }
    }
}