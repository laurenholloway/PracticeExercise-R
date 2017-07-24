# Root Driving History: Solution Explanation
This README includes an explanation of the different components of the Root Driving History interview problem. To summarize the approach taken, the program reads the input from a text file line-by-line until there are no remaining lines of text to read. There are 2 primary actions that need to take place within the program. These actions are based on the two commands: Trip and Driver. If the text line starts with Driver, the program will take certain actions, and if the text line starts with Trip, the program will take other actions. All of the drivers and their driving history information is saved in a dictionary with the keys as their names and the values as Driver class objects. Once all of the calculations are completed, the driver information is sorted using LINQ, so the first printed output is the driver with the most miles (descending order). 

## Table of Contents
- [Driver Class Overview](#Driver-Class-Overview)
  - [Fields](##Driver-Class-Fields)
  - [Properties](##Driver-Class-Properties)
  - [Constructor](##Driver-Class-Constructor)
  - [CalculateSpeed() Method](##CalculateSpeed()-Method)
- [Trip Class Overview](##Trip-Class-Overview)
  - [Properties](##Trip-Class-Properties)
  - [CalculateTripTime(...) Method](##CalculateTripTime(...)-Method)
- [Program Class Overview](##Program-Class-Overview)
  - [Reading Input](##Reading-Input)
  - [Requirement: Handling Driver Command](##Driver-Command)
  - [Requirement: Handling Trip Command](##Trip-Command)
  - [Requirement: Handling Outlier Trips](##Outlier-Trips)
  - [Sorting Driving Records by Miles](##Sorting-Driving-Records)
  - [Solution Output](##Solution-Output)

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

  
