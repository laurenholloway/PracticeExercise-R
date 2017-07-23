using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RootDrivingChallenge
{
    class Program
    {
        static void Main(string[] args)
        {

            //This is how to save the objects in a dictionary
            List<string> names = new List<string>();

            //Dictionary to hold driver name as key and Driver object as value
            Dictionary<string, Driver> DrivingRecord = new Dictionary<string, Driver>();

            //StreamReader for reading the input from the file line by line
            StreamReader file = new StreamReader("DrivingRecord.txt");

            string words;
            

            //READING FILE TO GET NAMES OF DRIVERS AND ADD THEM TO A LIST TO THEN BE ADDED AS DICTIONARY ENTRIES
            while ((words = file.ReadLine()) != null)
            {
                double driverTime = 0;
                double driverMiles = 0;
                int speed = 0;

                string[] line = words.Split();
                string driverName = line[1];

                //Adding names of drivers to list
                if (line[0] == "Driver")
                {
                    
                    DrivingRecord[driverName] = new Driver { DriverName = driverName, DriverMiles = driverMiles, DriverSpeed = speed, DriverTime = driverTime };

                }
                
                //NEED TO FIX MPH CALCULATION
                    if (line[0] == "Trip")
                    {
                    var currentDriver = DrivingRecord[driverName];

                    double tripTime = Trip.CalculateTripTime(line[2], line[3]);    
                    driverTime += tripTime;
                    currentDriver.DriverTime += driverTime;

                    double tripMiles = double.Parse(line[4]);
                    driverMiles += tripMiles;
                    currentDriver.DriverMiles += driverMiles;

                    speed = Convert.ToInt32(Math.Round(driverMiles / driverTime));
                    currentDriver.DriverSpeed = speed;

                        
                    }   
            }
            foreach (string name in DrivingRecord.Keys)
            {
                Console.WriteLine("{0}: {1} miles @ {2} mph (Time: {3} Hours)", DrivingRecord[name].DriverName, DrivingRecord[name].DriverMiles, DrivingRecord[name].DriverSpeed, DrivingRecord[name].DriverTime);
            }

            file.Close();

        

        }
    }
}
