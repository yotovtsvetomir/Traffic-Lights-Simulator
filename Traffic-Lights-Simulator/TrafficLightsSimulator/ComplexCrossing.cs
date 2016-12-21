using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace TrafficLight
{
    [Serializable]
    class ComplexCrossing : Crossing
    {
        public ComplexCrossing(Point pos, int spot) : base(pos, spot)
        {
            this.ListOfPedestrians = new List<PedestrianStream>();
            // TODO: Complete member initialization
        }

        public List<PedestrianStream> ListOfPedestrians { get; set; }

        public bool addPedestrianStream(PedestrianStream stream)
        {
            this.ListOfPedestrians.Add(stream);
            //TODO - Disable the pedestrian point, 
            //so you cannot add new pedestrian stream on same place
            //You can use Edit then
            return false;
        }

        public override void DrawItself(Graphics gr, ImageList il)
        {
            gr.DrawImage(il.Images[1], this.Position.X, this.Position.Y);
            this.DrawAllTrafficLights(gr);
            this.DrawAllStartingStreams(gr, il);
        }

        public void ChangePedestrianLights(string whatIsGreen)
        {
        }
    }
}