using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace TrafficLight
{
    [Serializable]
    public class Car : TrafficMember
    {
        private int radius;

        public Car(int carId, List<Point> carRoad)
        {
            this.CarId = carId;
            this.Position = carRoad.First();
            this.CarRoad = carRoad;
            this.CurrentDestination = this.CarRoad.First();
            this.CanPass = true;
            this.radius = 8;
        }

        public delegate void CheckColorOfTrafficLight(Car car);

        public Crossing CurrentCrossing { get; set; }

        public List<Point> CarRoad { get; set; }

        public Point CurrentDestination { get; set; }

        public Point NextDestination { get; set; }

        public bool CanPass { get; set; }

        public int CarId { get; set; }

        public Point Position { get; set; }

        public override void Draw(Graphics gr, ImageList il)
        {
            int dia = this.radius * 2;
            base.Draw(gr, il);
            gr.FillEllipse(Brushes.DarkCyan, new Rectangle(new Point(this.Position.X - this.radius, this.Position.Y - this.radius), new Size(dia, dia)));
        }
       
        public void SetNextDestination()
        {
            for (int i = 0; i < this.CarRoad.Count - 1; i++)
            {
                if (this.CarRoad[i] == this.CurrentDestination)
                {
                    this.NextDestination = this.CarRoad[i + 1];
                    break;
                }
            }
        }

        public void Drive(Point destination)
        {
            bool destinationReached = true;
            this.CurrentDestination = destination;
            this.Speed = 1;
            if (this.Position.X < this.CurrentDestination.X)
            {
                this.Position = new Point(this.Position.X + this.Speed, this.Position.Y);
                destinationReached = false;
            }
            else if (this.Position.X > this.CurrentDestination.X)
            {
                this.Position = new Point(this.Position.X - this.Speed, this.Position.Y);
                destinationReached = false;
            }
            if (this.Position.Y < this.CurrentDestination.Y)
            {
                this.Position = new Point(this.Position.X, this.Position.Y + this.Speed);
                destinationReached = false;
            }
            else if (this.Position.Y > this.CurrentDestination.Y)
            {
                this.Position = new Point(this.Position.X, this.Position.Y - this.Speed);
                destinationReached = false;
            }
            if (destinationReached)
            {
                this.SetNextDestination(); 
            }
        }

        public void TurnLeft(Point destination)
        {
        }

        public void TurnRight(Point destination)
        {
        }

        public void Stop(Point stoppoint)
        {
        }
    }
}