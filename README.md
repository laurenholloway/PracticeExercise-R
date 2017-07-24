# Root Driving History: Solution Explanation
This README includes an explanation of the different components that make up this project. To summarize the approach taken, the program reads the input from a text file line-by-line until there are no remaining lines of text to read. There are 2 primary actions that need to take place within the program. These actions are based on the two commands: Trip and Driver. If the text line starts with Driver, the program will take certain actions, and if the text line starts with Trip, the program will take other actions. All of the drivers and their driving history information is saved in a dictionary with the keys as their names and the values as Driver class objects. Once all of the calculations are completed, the driver information is sorted using LINQ, so the first printed output is the driver with the most miles (descending order). 

## Table of Contents
- [Driver Class Overview](##Driver-Class-Overview)
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

## Driver Class Overview
Blah Blah Blah
  
