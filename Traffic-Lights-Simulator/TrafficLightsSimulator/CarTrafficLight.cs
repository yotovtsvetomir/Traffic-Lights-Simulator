using System;
using System.Drawing;
using System.Linq;

namespace TrafficLight
{
    [Serializable]
    public class CarTrafficLight : TrafficLight
    {
        public CarTrafficLight(string id, Point pos) : base(pos)
        {
            this.Id = id;
        }
    }
}
