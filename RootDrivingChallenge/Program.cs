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
          
            Trip a = new Trip();
            Console.WriteLine(a.CalculateTripTime("12:01", "13:16"));

            


            //This is how to save the objects in a dictionary
            List<string> names = new List<string>();

            //Dictionary to hold driver name as key and Driver object as value
            Dictionary<string, Driver> DrivingRecord = new Dictionary<string, Driver>();

            //StreamReader for reading the input from the file line by line
            StreamReader file = new StreamReader("DrivingRecord.txt");
            string words;
            while ((words = file.ReadLine()) != null)
            {
                string[] line = words.Split();
                
                //Adding names of drivers to list
                if (line[0].Equals("Driver"))
                {
                    names.Add(line[1]);
                }

                if (line[1].Equals("Trip"))
                {

                }
            }

            
            foreach (string name in names)
            {
                DrivingRecord[name] = new Driver { DriverName = name, DriverMiles = 0 };
            }


            //foreach (var entry in DrivingRecord.Values)
            //{
            //    Console.WriteLine(entry.DriverName);
            //    Console.WriteLine(entry.DriverMiles);
            //}

            //foreach(var entry in DrivingRecord)
            //{

            //    if(entry.Key == "Bob")
            //    {
            //            entry.Value.DriverMiles += 10;
            //            Console.WriteLine("\n{0}: {1} Total Miles Driven", entry.Key, entry.Value.DriverMiles);
            //    }
            //}








            ////CALCULATE MPH
            //int miles = 42;
            //Console.WriteLine(Math.Round(miles / duration));


        }
    }
}
