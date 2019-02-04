namespace TheTankGame.Tests
{
    using NUnit.Framework;
    using System;
    using System.Linq;
    using System.Reflection;
    using TheTankGame.Entities.Miscellaneous;
    using TheTankGame.Entities.Parts;
    using TheTankGame.Entities.Parts.Contracts;
    using TheTankGame.Entities.Vehicles;
    using TheTankGame.Entities.Vehicles.Contracts;

    [TestFixture]
    public class BaseVehicleTests
    {

        private IVehicle vehicleVanguard;
        private IVehicle vehicleRevenger;
        private IVehicle vehcleForStatistics;
        
        [SetUp]
        public void Setup()
        {
            this.vehicleVanguard = new Vanguard("SClass", 100, 300, 1000, 450, 2000, new VehicleAssembler());
            this.vehicleRevenger = new Revenger("RClass", 100, 300, 1000, 450, 2000, new VehicleAssembler());
            this.vehcleForStatistics = new Vanguard("Statistical", 100, 100, 100, 100, 100, new VehicleAssembler());
        }

        [Test]
        public void TestCtors()
        {
            var flags = BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public;

            var constructorVanguard = vehicleVanguard.GetType().GetConstructors(flags).FirstOrDefault();
            var constructorRevenger = vehicleVanguard.GetType().GetConstructors(flags).FirstOrDefault();

            Assert.That(constructorVanguard, Is.Not.Null, "Constructor doesn't exist");
            Assert.That(constructorRevenger, Is.Not.Null, "Constructor doesn't exist");

        }

        [Test]
        public void TestExceptions()
        {
            //Invlid vehicle model
            Assert.Throws<ArgumentException>(() =>
            new Vanguard(" ", 100, 300, 1000, 450, 2000, new VehicleAssembler()),
            "Argument exception should be thrown for invalid model");

            //Invlid vehicle weight
            Assert.Throws<ArgumentException>(() =>
            new Vanguard("C4", -1, 300, 1000, 450, 2000, new VehicleAssembler()),
            "Argument exception should be thrown for invalid weight");

            //Invlid vehicle price
            Assert.Throws<ArgumentException>(() =>
            new Vanguard("C4", 50, 0, 1000, 450, 2000, new VehicleAssembler()),
            "Argument exception should be thrown for invalid price");

            //Invlid vehicle attack
            Assert.Throws<ArgumentException>(() =>
            new Vanguard("C4", 50, 100, -1, 450, 2000, new VehicleAssembler()),
            "Argument exception should be thrown for invalid attack");

            //Invlid vehicle defence
            Assert.Throws<ArgumentException>(() =>
            new Vanguard("C4", 50, 100, 100, -1, 2000, new VehicleAssembler()),
            "Argument exception should be thrown for invalid defence");

            //Invlid vehicle Hit Points
            Assert.Throws<ArgumentException>(() =>
            new Vanguard("C4", 50, 100, 100, 100, -5, new VehicleAssembler()),
            "Argument exception should be thrown for invalid hit points");
        }

        [Test]
        public void TestAddPartsMethodsWorkProperly()
        {
            //Add Endurance part
            IPart endurancePart = new EndurancePart("A1", 100, 500, 50);
            this.vehicleRevenger.AddEndurancePart(endurancePart);
            string actualResult = vehicleRevenger.ToString();
            string expectedResult = "Revenger - RClass\r\nTotal Weight: 200.000\r\n" +
                "Total Price: 800.000\r\nAttack: 1000\r\nDefense: 450\r\n" +
                "HitPoints: 2050\r\nParts: A1";
            Assert.AreEqual(expectedResult, actualResult, 
                "AddEndurancePart method does not work properly");

            //Add Arsenal part
            IPart arsenalPart = new ArsenalPart("B123", 100, 500, 50);
            this.vehicleVanguard.AddArsenalPart(arsenalPart);
            actualResult = vehicleVanguard.ToString();
            expectedResult = "Vanguard - SClass\r\nTotal Weight: 200.000\r\n" +
                "Total Price: 800.000\r\nAttack: 1050\r\nDefense: 450\r\n" +
                "HitPoints: 2000\r\nParts: B123";
            Assert.AreEqual(expectedResult, actualResult,
               "AddArsenalPart method does not work properly");

            //Add Shell part
            IPart shellPart = new ShellPart("Shell3", 100, 500, 50);
            this.vehicleVanguard.AddShellPart(shellPart);
            actualResult = vehicleVanguard.ToString();
            expectedResult = "Vanguard - SClass\r\nTotal Weight: 300.000\r\n" +
                "Total Price: 1300.000\r\nAttack: 1050\r\nDefense: 500\r\n" +
                "HitPoints: 2000\r\nParts: B123, Shell3";
            Assert.AreEqual(expectedResult, actualResult,
               "AddShellPart method does not work properly");
        }

        [Test]
        public void TestVehicleStatistices()
        {
            //Shell part effects on vehicle's weight, price and defense;
            IPart shellPart = new ShellPart("Shell3", 100, 100, 100);
            vehcleForStatistics.AddShellPart(shellPart);
            string actual = vehcleForStatistics.ToString();
            string expected = "Vanguard - Statistical\r\nTotal Weight: 200.000\r\n" +
                "Total Price: 200.000\r\nAttack: 100\r\nDefense: 200\r\n" +
                "HitPoints: 100\r\nParts: Shell3";
            Assert.AreEqual(expected, actual);

            //Shell part effects on vehicle's weight, price and attack;
            IPart arsenalPart = new ArsenalPart("Ars", 100, 100, 100);
            vehcleForStatistics.AddArsenalPart(arsenalPart);
            actual = vehcleForStatistics.ToString();
            expected = "Vanguard - Statistical\r\nTotal Weight: 300.000\r\n" +
                "Total Price: 300.000\r\nAttack: 200\r\nDefense: 200\r\n" +
                "HitPoints: 100\r\nParts: Shell3, Ars";
            Assert.AreEqual(expected, actual);

            //Endurance part effects on vehicle's weight, price and hitpoints;
            IPart endurancePart = new EndurancePart("Endur", 100, 100, 100);
            vehcleForStatistics.AddEndurancePart(endurancePart);
            actual = vehcleForStatistics.ToString();
            expected = "Vanguard - Statistical\r\nTotal Weight: 400.000\r\n" +
                "Total Price: 400.000\r\nAttack: 200\r\nDefense: 200\r\n" +
                "HitPoints: 200\r\nParts: Shell3, Ars, Endur";
            Assert.AreEqual(expected, actual);
        }

    }
}