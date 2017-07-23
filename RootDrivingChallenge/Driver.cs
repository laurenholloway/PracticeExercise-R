using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RootDrivingChallenge
{
    public class Driver
    {
        public double DriverMiles { get; set; }
        public string DriverName { get; set; }
        public double DriverTime { get; set; }
        public int DriverSpeed { get; set; }

        //Calculate the total number of miles driven by the driver
        public double SumDriverTime(double tripDuration)
        {
            DriverTime += tripDuration;
            return DriverTime;
            
        }

        //Calculate the total number of miles driven by the driver
        public double SumDriverMiles(double tripMiles)
        {
            DriverMiles += tripMiles;
            return DriverMiles;
        }

        //Calculate the MPH for the driver
        public int CalculateSpeed(double driverMiles, double driverTime)
        {
            int mph = Convert.ToInt32(Math.Round(driverMiles / DriverTime));
            return mph;
        }
    }

   
}
