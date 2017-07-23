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
                    double tripMiles = double.Parse(line[4]);
                    double tripMPH = tripMiles / tripTime;

                    if(tripMPH >= 5 || tripMPH <= 100)
                    {
                        driverTime += tripTime;
                        currentDriver.DriverTime += driverTime;

                        driverMiles += tripMiles;
                        currentDriver.DriverMiles += driverMiles;

                    }



                    //Overall Speed
                    speed = Convert.ToInt32(Math.Round(currentDriver.DriverMiles / currentDriver.DriverTime));
                    currentDriver.DriverSpeed = speed;

                        
                    }   
            }
            //LINQ for sorting the dictionary
            var drivingRecordSorted = from entry in DrivingRecord
                                      orderby entry.Value.DriverMiles descending
                                      select entry;

            var drivingRecordSortedList = drivingRecordSorted;
            foreach (var name in drivingRecordSortedList)
            {
                if(name.Value.DriverMiles > 0)
                {
                    Console.WriteLine("{0}: {1} miles @ {2} mph", name.Value.DriverName, Math.Round(name.Value.DriverMiles), name.Value.DriverSpeed);
                }
                else
                {
                    Console.WriteLine("{0}: {1} miles", name.Value.DriverName, Math.Round(name.Value.DriverMiles));
                }
                
            }

            file.Close();

        

        }
    }
}
