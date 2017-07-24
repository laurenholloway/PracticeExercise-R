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
                
                //Creating dictionary element for each driver listed
                if (word[0] == "Driver")
                {
                    //use a constructor to pass in the values for the properties when creating object  
                    DrivingRecord[driverName] = new Driver(driverName, driverMiles, speed, driverTime);

                    var currentDriver = DrivingRecord[driverName];
                    currentDriver.DriverName = driverName;
                }

                //If the first word is trip, do the calculations so we can print the correct output values
                else if (word[0] == "Trip")
                {
                    var currentDriver = DrivingRecord[driverName];
                    double tripTime = Trip.CalculateTripTime(word[2], word[3]);
                    double tripMiles = double.Parse(word[4]);
                    double tripMPH = tripMiles / tripTime;

                    //Update driver properties if entry is not less than 5mph or greater than 100mph
                    if (tripMPH >= 5 || tripMPH <= 100)
                    {
                        //Do calculation of driver's total time and miles in the driver class
                        currentDriver.DriverTime = tripTime;
                        currentDriver.DriverMiles = tripMiles;
                    }

                    //Calculate the overall Speed for a driver
                    currentDriver.DriverSpeed = currentDriver.CalculateSpeed();
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
