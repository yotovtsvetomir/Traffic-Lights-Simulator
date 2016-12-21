using System;
using System.Drawing;
using System.Linq;

namespace TrafficLight
{
    [Serializable]
    public class PedestrianTrafficLight : TrafficLight
    {
        public PedestrianTrafficLight(Point pos) : base(pos)
        {
        }
    }
}
