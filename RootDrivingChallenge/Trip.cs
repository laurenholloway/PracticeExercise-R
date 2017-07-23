using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RootDrivingChallenge
{
    public static class Trip
    {
        //Trip properties
        public static string StartTime { get; set; }
        public static string StopTime {get; set; }
        public static double TripMiles { get; set; }

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
            TimeSpan span = new TimeSpan(startHr, startMin, 0);
            TimeSpan span2 = new TimeSpan(stopHr, stopMin, 0);

            double duration = (span2 - span).TotalHours;

            return duration;

        }

        

    }
}
