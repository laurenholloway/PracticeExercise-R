using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RootDrivingChallenge;

namespace Tests
{
    [TestClass]
    public class DriverHistoryCalculator
    {
        [TestMethod]
        public void TestCalculateTripTime()
        {
            //Arrange
            string startTime = "12:01";
            string stopTime = "13:16";

            //Act
            double duration = Trip.CalculateTripTime(startTime, stopTime);

            //Assert
            Assert.AreEqual(1.25, duration);
        }

        [TestMethod]
        public void TestCalculateTripSpeed()
        {
            //Arrange
            double tripMiles = 42.0;
            double tripTime = 1.25;

            //Act
            double tripSpeed = Trip.CalculateTripSpeed(tripMiles,tripTime);

            //Assert
            Assert.AreEqual(33.6, tripSpeed);
        }
    }
}
