# Root Driving History: Solution Explanation
This README includes an explanation of the different components of the Root Driving History interview problem. To summarize the approach taken, the program reads the input from a text file line-by-line until there are no remaining lines of text to read. There are 2 primary actions that need to take place within the program. These actions are based on the two commands: Trip and Driver. If the text line starts with Driver, the program will take certain actions, and if the text line starts with Trip, the program will take other actions. All of the drivers and their driving history information is saved in a dictionary with the keys as their names and the values as Driver class objects. Once all of the calculations are completed, the driver information is sorted using LINQ, so the first printed output is the driver with the most miles (descending order). 

## Table of Contents
- [Driver Class Overview](#Driver-Class-Overview)
  - [Fields](#Fields)
  - [Properties](##Properties)
  - [Constructors](##Constructor)
  - [CalculateSpeed() Method](##CalculateSpeed()-Method)
- [Trip Class Overview](##Trip-Class-Overview)
  - [CalculateTripTime(...) Method](##CalculateTripTime(...)-Method)
  - [CalculateTripSpeed(...) Method](##CalculateTripSpeed(...)-Method)  
- [Program Class Overview](##Program-Class-Overview)
  - [Requirement: Handling Driver Command](##Driver-Command)
  - [Requirement: Handling Trip Command](##Trip-Command)
  - [Requirement: Handling Outlier Trips](##Outlier-Trips)
  - [Requirement: Sorting Driving Records by Miles](##Sorting-Driving-Records)

# Driver Class Overview
The Driver class is the blueprint for all of the driver objects that will be created. The problem description informs us that there are specific pieces of information we need to output about the driver, including the driver's name, total number of miles traveled and the driver's speed based also on the total amount of time driving. These key pieces of information will be the fields of the driver class, and the fields are accessed through the properties. This class also includes a method for calculating the speed for the driver and returns the value in the Program class.

## Fields
In C#, we can create properties without explicitly creating fields using the short hand `{ get; set; }` implementations. For the Driver class, I explicitly created the private fields as seen below. Because these fields are private, they cannot be accessed outside of the Driver class. Instead, the fields are accessed through their public properties. The `driverName` is declared as a string data type because a name is a sequence of characters. Both `driverMiles` and `driverTime` are doubles because they are floating point types because a driver could drive a partial mile and time (calculated by number of hours) could be a partial hour. The `driverSpeed` field is declared as an integer because we will use a method to calculate the driver's speed and the method will return the speed as an integer.
```CSharp
//Fields
private string driverName;
private double driverMiles;
private double driverTime;
private int driverSpeed;
```

## Properties
The public properties are used to access the private fields. The public access modifier on the properties allows the properties to be accessed within the Program class. For each private fields, there is a public property. The `set` implementation is different depending on the property. For `DriverMiles` and `DriverTime`, the shorthand `+=` operators because the properties will hold total values for the driver. This means for each trip a driver takes, their total number of miles driven (`DriverMiles`) must be updated based on the trip miles. The trip miles comes into play as `value` in the Program class. The same is for `DriverTime`. For both `DriverName` and `DriverSpeed` the values will be assigned simply with an `=` to the appropriate value in the Program class.
```CSharp
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
 ``` 
 
## Constructors
For each driver listed in the text file, a Driver object is created. The following constructor was created with parameters for the driver's name, miles driven, speed, and time driven, so that the information about the object(driver) is being passed in on object creation. The first constructor is the default constructor, which would allow us to instantiate a new driver object without having to pass in any information upfront.
```CSharp
//constructors
public Driver()
{
     //Default constructor
}

public Driver(string driverName, double driverMiles, int driverSpeed, double driverTime)
{
     //constructor for creating Driver objects for each driver listed in the file
}
```

## CalculateSpeed() Method
This method calculates the speed for each driver based on the properties `DriverMiles` divided by `DriverTime`. The `Round(...)` method of the `Math` class is used to round the speed to the nearest whole value. Next, the value is converted to an integer using `Convert.ToInt32(...)` because the variable the value is being assigned to (`mph`) is an integer. The problem asks that the speed is returned as a whole number, so lastly, `mph` is returned.
```CSharp
//Calculate the MPH for the driver
public int CalculateSpeed()
{
      int mph = Convert.ToInt32(Math.Round(DriverMiles / DriverTime));
      return mph;
}
```

# Trip Class Overview
The Trip class was created as a static class because we do not need to instantiate instances of the class. The class has 2 static methods, one for calculating the duration of each trip listed in the text file and the other for calculating the speed for each trip listed.

## CalculateTripTime(...) Method
The CalculateTripTime(...) method takes in two arguments, one for the start time of a trip and one for the stop time of the same trip. Both the start and stop times are passed as strings from the text file. Since they are both strings, in order to calculate how much time exists between the two times, they need to be converted into a numeric type. First, both the start time and stop are split at the ':' (colon) to separate the hours from the minutes. Once the hours and minutes are both parsed to integers, they are passed in as arguments for 2 different TimeSpan instances. There is a TimeSpan instance for both the start time and the stop time. Because the problem specifies the times are on a 24-hour clock and the stop time will always be greater than the start time, the duration of the trip is calculated by subtracting the TimeSpan instance for the start time from the TimeSpan instance for the stop time. To get the total number of hours (we want hours because our speed is calculated based on miles per hour), the TotalHours TimeSpan property is used. This value is then assigned to `duration` and returned.
```CSharp
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
```

## CalculateTripSpeed(...) Method
The CalculateTripSpeed(...) method is needed in order to calculate the speed of each trip to check to see if the trip is an outlier trip based on the calculated mph and should be discarded and not included in the driver totals.
```CSharp
//Calculate the trip speed to be able to check for outliers (<5 MPH or >100 MPH)
public static double CalculateTripSpeed(double tripMiles, double tripTime)
{
      double mph = tripMiles / tripTime;
      return mph;
}
```

# Program Class Overview

## Requirement: Handling Driver Command

## Requirement: Handling Trip Command

## Requirement: Handling Outlier Trips

## Requirement: Sorting Driving Records by Miles
