using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Management;
using wmi_hardware;

//Fork by: Mohammad Yaser Ammar
//https://github.com/MohammadYAmmar/
//Feture 1:
//Add Unit test project


namespace wmi_hardwareTests
{
    [TestClass]
    public class WMIResultTests
    {
        //GetPropertyValuesForWMIClass call by Program
        //GetPropertyValuesForWMIClass(connection, "SELECT * FROM " + wmiclass, wmiclass)

        [TestMethod]
        //Given_When_Then rule

        //GetPropertyValuesForWMIClass(@"\root\CIMV2, "SELECT * FROM Win32_Processor" , "Name")

        public void GetPropertyValuesForWMIClass_With_Win32_Processor_name_Return_i7_8550U()
        {
            ///AAA rule 
            //Arrange
            WMIConnection connection = new WMIConnection();

            //#todo
            //WMIResult.GetPropertyValuesForWMIClass(connection, "SELECT * FROM Win32_Processor", "Name");
            string temp = "";
            foreach (var device in WMIResult.GetPropertyValuesForWMIClass(connection, "SELECT * FROM Win32_Processor", "Name"))
            {
                //Print all device properties
                foreach (var property in device)
                {
                    Console.WriteLine(property.Key + ": " + property.Value);
                    temp = temp + property.Key + ": " + property.Value;
                }
                Console.WriteLine("\n");
            }
            Console.WriteLine("\n");

            //Act
            string actual = temp;
            string expected = "i7-8550U";

            //Assert
            //Assert.AreEqual(expected, actual);
            StringAssert.Contains(expected, actual);

        }
    }
}
