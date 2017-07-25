using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RootDrivingChallenge
{
    public class Driver
    {
        //Fields
        private string driverName;
        private double driverMiles;
        private double driverTime;
        private int driverSpeed;

        //Properties
        public double DriverMiles
        {
            get { return this.driverMiles; }
            set { this.driverMiles += value; }
        }

        public string DriverName
        {
            get { return this.driverName; }
            set { this.driverName = value; }
        }

        public double DriverTime
        {
            get { return this.driverTime; }
            set { this.driverTime += value; }
        }

        public int DriverSpeed
        {
            get { return this.driverSpeed; }
            set { this.driverSpeed = value; }
        }

        //constructors
        public Driver()
        {
            //Default constructor
        }

        public Driver(string driverName, double driverMiles, int driverSpeed, double driverTime)
        {
            //constructor for creating Driver objects for each driver listed in the file
        }

        //Calculate the MPH for the driver
        public int CalculateSpeed()
        {
            int mph = Convert.ToInt32(Math.Round(DriverMiles / DriverTime));
            return mph;
        }
    }
}
