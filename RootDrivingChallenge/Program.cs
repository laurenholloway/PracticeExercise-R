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
            //Dictionary to hold driver name as key and Driver object as value
            Dictionary<string, Driver> DrivingRecord = new Dictionary<string, Driver>();

            //StreamReader for reading the input from the file word by word
            StreamReader file = new StreamReader("DrivingRecord.txt");

            string fileLine;


            //READING FILE TO GET NAMES OF DRIVERS AND ADD THEM TO A LIST TO THEN BE ADDED AS DICTIONARY ENTRIES
            while ((fileLine = file.ReadLine()) != null)
            {
                double driverTime = 0;
                double driverMiles = 0;
                int speed = 0;

                string[] word = fileLine.Split();
                string driverName = word[1];

                //Adding names of drivers to list
                if (word[0] == "Driver")
                {
                    //use a constructor for those properties   
                    DrivingRecord[driverName] = new Driver { DriverName = driverName, DriverMiles = driverMiles, DriverSpeed = speed, DriverTime = driverTime };
                }
                else if (word[0] == "Trip")
                {
                    var currentDriver = DrivingRecord[driverName];

                    double tripTime = Trip.CalculateTripTime(word[2], word[3]);
                    double tripMiles = double.Parse(word[4]);
                    double tripMPH = tripMiles / tripTime;

                    //Update driver properties if entry is not less than 5mph or greater than 100mph
                    if (tripMPH >= 5 || tripMPH <= 100)
                    {
                        //Do calculation in the driver class
                        driverTime += tripTime;
                        currentDriver.DriverTime += driverTime;

                     
                        currentDriver.DriverMiles = driverMiles;
                    }
                    

                    //Overall Speed
                    speed = Convert.ToInt32(Math.Round(currentDriver.DriverMiles / currentDriver.DriverTime));

                    currentDriver.DriverSpeed = speed;
                }
                
            }
            file.Close();
            //LINQ for sorting the dictionary
            var drivingRecordSorted = from entry in DrivingRecord
                                      orderby entry.Value.DriverMiles descending
                                      select entry;

            //Printing the records based on number of miles driven
            foreach (var name in drivingRecordSorted)
            {
                if (name.Value.DriverMiles > 0)
                {
                    Console.WriteLine("{0}: {1} miles @ {2} mph", name.Value.DriverName, Math.Round(name.Value.DriverMiles), name.Value.DriverSpeed);
                }
                else
                {
                    Console.WriteLine("{0}: {1} miles", name.Value.DriverName, Math.Round(name.Value.DriverMiles));
                }
            }
        }
    }
}
