using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AppliancesLibrary;
using AppliancesLibrary.Appliances;
using System.Collections.Generic;
using System.Linq;

namespace Appliances.Tests
{
    [TestClass]
    public class ControllerTests
    {
        [TestMethod]
        public void GetCost_1600and700_2300returned()
        {
            //Arrange
            KitchenUnit kitchenUnitToTest = new KitchenUnit("Arabika", "Something", 1600, 1000, 12);
            WashingMachine washingMachineToTest = new WashingMachine("Something", "Arabika", 700, 12, 6);
            double expected = 2300;

            //Act
            List<Appliance> appliances = new List<Appliance>
            {
                kitchenUnitToTest,
                washingMachineToTest
            };
            double actual = Controller.GetCost(appliances);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Sort_ArabikaAndSomethingAndLG_ArabikaReturned()
        {
            //Arrange
            KitchenUnit kitchenUnitToTest = new KitchenUnit("Arabika", "Something", 1600, 1000, 12);
            WashingMachine washingMachineToTest = new WashingMachine("Something", "Arabika", 700, 12, 6);
            VacuumCleaner vacuumCleanerToTest = new VacuumCleaner("LG", "Samsung", 1500, "Blue", 1600);
            List<Appliance> expectedList = new List<Appliance>
            {
                kitchenUnitToTest,
                vacuumCleanerToTest,
                washingMachineToTest,
            };

            //Act
            List<Appliance> actualList = new List<Appliance>
            {
                washingMachineToTest,
                vacuumCleanerToTest,
                kitchenUnitToTest
            };
            Controller.Sort(actualList);

            //Assert
            Assert.AreEqual(expectedList.ElementAt(0).Name, actualList.ElementAt(0).Name);
        }
        [TestMethod]
        public void Sort_ArabikaAndSomethingAndLG_LGReturned()
        {
            //Arrange
            KitchenUnit kitchenUnitToTest = new KitchenUnit("Arabika", "Something", 1600, 1000, 12);
            WashingMachine washingMachineToTest = new WashingMachine("Something", "Arabika", 700, 12, 6);
            VacuumCleaner vacuumCleanerToTest = new VacuumCleaner("LG", "Samsung", 1500, "Blue", 1600);
            List<Appliance> expectedList = new List<Appliance>
            {
                kitchenUnitToTest,
                vacuumCleanerToTest,
                washingMachineToTest,
            };

            //Act
            List<Appliance> actualList = new List<Appliance>
            {
                washingMachineToTest,
                vacuumCleanerToTest,
                kitchenUnitToTest
            };
            Controller.Sort(actualList);

            //Assert
            Assert.AreEqual(expectedList.ElementAt(1).Name, actualList.ElementAt(1).Name);
        }

        [TestMethod]
        public void FindApplianceByManufacturer_ArabikaAndSomethingAndSamsung_1Returned()
        {
            //Arrange
            
            KitchenUnit kitchenUnitToTest = new KitchenUnit("Arabika", "Something", 1600, 1000, 12);
            WashingMachine washingMachineToTest = new WashingMachine("Something", "Arabika", 700, 12, 6);
            VacuumCleaner vacuumCleanerToTest = new VacuumCleaner("LG", "Samsung", 1500, "Blue", 1600);
            double expectedValue = 1;

            //Act
            List<Appliance> appliances = new List<Appliance>
            {
                kitchenUnitToTest,
                washingMachineToTest,
                vacuumCleanerToTest
            };
            List<Appliance> actualObject = new List<Appliance>();
            actualObject.AddRange(Controller.FindApplianceByManufacturer(appliances, vacuumCleanerToTest.Manufacturer));
            double actualValue = actualObject.Count();

            //Assert
            Assert.AreEqual(expectedValue, actualValue);
        }

        [TestMethod]
        public void FindApplianceByManufacturer_ArabikaAndSomethingAndSamsung_SamsungReturned()
        {
            //Arrange

            KitchenUnit kitchenUnitToTest = new KitchenUnit("Arabika", "Something", 1600, 1000, 12);
            WashingMachine washingMachineToTest = new WashingMachine("Something", "Arabika", 700, 12, 6);
            VacuumCleaner vacuumCleanerToTest = new VacuumCleaner("LG", "Samsung", 1500, "Blue", 1600);
            string expectedValue = "Samsung";

            //Act
            List<Appliance> appliances = new List<Appliance>
            {
                kitchenUnitToTest,
                washingMachineToTest,
                vacuumCleanerToTest
            };
            List<Appliance> actualObject = new List<Appliance>();
            actualObject.AddRange(Controller.FindApplianceByManufacturer(appliances, vacuumCleanerToTest.Manufacturer));
            string actualValue = "";
            foreach( var a in actualObject )
            {
                actualValue = a.Manufacturer;
            }

            //Assert
            Assert.AreEqual(expectedValue, actualValue);
        }
    }
}
