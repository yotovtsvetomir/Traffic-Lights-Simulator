using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace TrafficLight
{
    [Serializable]
    public class CarStream
    {
        private int id;
        private int nrCars;

        public List<Car> CarList { get; set; }

        public List<Point> Road { get; set; }

        public CarStream(int id, int nrCars, List<Point> road)
        {
            this.id = id;

            this.nrCars = nrCars;
            this.CarList = new List<Car>();
            this.Road = road;
            this.SetNumberOfCars(nrCars);
        }

        public void SetNumberOfCars(int numberOfCars)
        {
            this.CarList.Clear();
            for (int i = 0; i < this.nrCars; i++)
            {
                Car k = new Car(i, this.Road);
                this.CarList.Add(k);
            }
        }

        public void DriveAllCars()
        {
            foreach (Car car in this.CarList)
            {
                car.Drive(car.CurrentDestination);
                if (car.CarRoad.Contains(car.Position))
                {
                    List<Lane> lanesOfThisCrossing = car.CurrentCrossing.LisftOfLanes;
                    for (int i = 0; i < lanesOfThisCrossing.Count; i++)
                    {
                        if (lanesOfThisCrossing[i].StopPoint == car.Position)
                        {
                            foreach (TrafficLight tfl in car.CurrentCrossing.ListOfCarTrafficLights)
                            {
                                //lanes - the two string values from the traffic light ID,
                                //which are indexes of the lanes, which are stopping on this traffic light
                                string[] lanes = tfl.Id.Split();
                                //If there are 2 lanes for this traffic light (straight + right turn)
                                
                                #region If straight+right turn and LightColor is Red
                                
                                if (lanes.Length > 1)
                                {
                                    if (lanes[0] == i.ToString() ||
                                        lanes[1] == i.ToString())
                                    {
                                        if (tfl.LightColor == Color.Red)
                                        {
                                            car.CanPass = false;
                                            break;
                                        }
                                        else
                                        {
                                            car.CanPass = true;
                                            break;
                                        }
                                    }
                                }
                                
                                #endregion
                                
                                //If there are is 1 lane for this traffic light (left turn)
                                
                                #region if left turn and LightColor is Red
                                
                                else
                                {
                                    //If the current looped lane is going through this traffic light
                                    if (lanes[0] == i.ToString())
                                    {
                                        //If the lightcolour is red - don't allow cars to pass. 
                                        if (tfl.LightColor == Color.Red)
                                        {
                                            car.CanPass = false;
                                            break;
                                        }
                                        else
                                        {
                                            car.CanPass = true;
                                            break;
                                        }
                                    }
                                }
                                
                                #endregion
                            }
                        }
                    }
                    if (car.CanPass)
                    {
                        car.CurrentDestination = car.NextDestination;
                        car.SetNextDestination();
                    }
                }
            }
        }
        
        public void DrawAllCars(Graphics gr, ImageList il)
        {
            foreach (Car car in this.CarList)
            {
                car.Draw(gr, il);
            }
        }
        
        public bool IsStopPoint(Point carPosition)
        {
            foreach (Point p in this.Road)
            {
                if (p == carPosition)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
