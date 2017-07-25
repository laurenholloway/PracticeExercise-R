using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RootDrivingChallenge
{
    public static class Trip
    {
        //Calculate the trip duration
        public static double CalculateTripTime(string start, string stop)
        {
            //Separating the hours from the minutes
            string[] startArr = start.Split(':');
            string[] stopArr = stop.Split(':');

            int startHr = int.Parse(startArr[0]);
            int stopHr = int.Parse(stopArr[0]);

            int startMin = int.Parse(startArr[1]);
            int stopMin = int.Parse(stopArr[1]);

            //Calculating duration
            TimeSpan startSpan = new TimeSpan(startHr, startMin, 0);
            TimeSpan stopSpan = new TimeSpan(stopHr, stopMin, 0);

            double duration = (stopSpan - startSpan).TotalHours;
            return duration;
        }

        //Calculate the trip speed to be able to check for outliers (<5 MPH or >100 MPH)
        public static double CalculateTripSpeed(double tripMiles, double tripTime)
        {
            double mph = tripMiles / tripTime;
            return mph;
        }
    }
}
