using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace TrafficLight
{
    [Serializable]
    public class PedestrianStream 
    {
        private Point startPedestrianLight;
        private Point endPedestrianLight;
        private List<Pedestrian> listOfPedestrians;

        public PedestrianStream(Point startPoint, Point endPoint, int numberOfPedestrians)
        {
            this.startPedestrianLight = startPoint;
            this.endPedestrianLight = endPoint;
            this.listOfPedestrians = new List<Pedestrian>();
            this.SetNumberOfPedestrians(numberOfPedestrians);
        }

        public void SetNumberOfPedestrians(int numberOfPedestrians)
        {
            this.listOfPedestrians.Clear();
            List<Point> pedestrianPath = new List<Point> { this.startPedestrianLight, this.endPedestrianLight };
            for (int i = 0; i < numberOfPedestrians; i++)
            {
                this.listOfPedestrians.Add(new Pedestrian(0, pedestrianPath));
            }
        }

        public void DrawAllPedestrians(Graphics gr, ImageList il)
        {
            foreach (Pedestrian ped in this.listOfPedestrians)
            {
                ped.Draw(gr, il);
            }
        }
    }
}