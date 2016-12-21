using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace TrafficLight
{
    [Serializable]
    class SimpleCrossing : Crossing
    {
        public SimpleCrossing(Point position, int spot) : base(position,spot)
        {
        }

        public override void DrawItself(Graphics gr, ImageList il)
        {
            gr.DrawImage(il.Images[0], this.Position.X, this.Position.Y);
            this.DrawAllTrafficLights(gr);
            this.DrawAllStartingStreams(gr, il);
        }
    }
}
