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

            //StreamReader for reading the input from the file line by line
            StreamReader file = new StreamReader("DrivingRecord.txt");

       

            //This is how to save the objects in a dictionary
            List<string> names = new List<string>();

            //Dictionary to hold driver name as key and Driver object as value
            Dictionary<string, Driver> DrivingRecord = new Dictionary<string, Driver>();

            
            string words;
            while ((words = file.ReadLine()) != null)
            {
                string[] line = words.Split();
                
                //Adding names of drivers to list
                if (line[0].Equals("Driver"))
                {
                    names.Add(line[1]);
                    
                }
                foreach (string name in names)
                {
                    DrivingRecord[name] = new Driver { DriverName = name, DriverMiles = 0, DriverSpeed = 0};
                }

                if (line[0].Equals("Trip"))
                {
                    foreach(var entry in DrivingRecord)
                    {
                        if (entry.Key==line[1])
                        {
                            
                            double tripDuration = Trip.CalculateTripTime(line[2], line[3]);
                            double tripMiles = Convert.ToDouble(line[4]);
                            entry.Value.DriverMiles = entry.Value.SumDriverMiles(tripMiles);

                            entry.Value.DriverSpeed = entry.Value.CalculateSpeed(entry.Value.DriverMiles,entry.Value.DriverTime);
                        }
                    }
                    

                }
            }

            foreach (var entry in DrivingRecord.Values)
            {
                Console.WriteLine("{0}: {1} miles", entry.DriverName, entry.DriverMiles);
                //Console.WriteLine(entry.DriverName);
                //Console.WriteLine(entry.DriverMiles);
                //Console.WriteLine(entry.DriverTime);
            }

            //foreach (var entry in DrivingRecord)
            //{

            //    if (entry.Key == "Bob")
            //    {
            //        entry.Value.DriverMiles += 10;
            //        Console.WriteLine("\n{0}: {1} Total Miles Driven", entry.Key, entry.Value.DriverMiles);
            //    }
            //}








            ////CALCULATE MPH
            //int miles = 42;
            //Console.WriteLine(Math.Round(miles / duration));

            file.Close();
        }
    }
}
