using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
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

        [TestMethod]
        //Given_When_Then rule
        public void GetPropertyValuesForWMIClass_With_Win32_Processor_name_Return_i7_8550U()
        {
            ///AAA rule 
            //Arrange
            WMIConnection connection = new WMIConnection();

            //Get all devices of wmi class
            //draft when try
            //List<Dictionary<string, string>> actualList = WMIResult.GetPropertyValuesForWMIClass(connection, "SELECT * FROM Win32_Processor", "Win32_Processor");

            string actual = "";
            foreach (var device in WMIResult.GetPropertyValuesForWMIClass(connection, "SELECT * FROM Win32_Processor", "Win32_Processor"))
            {
                //Print all device properties
                foreach (var property in device)
                {
                    //Console.WriteLine(property.Key + ": " + property.Value);
                    actual = actual + property.Key + ": " + property.Value;
                }
            }
                //Act
                string expected = "i7-8550U";


            //Assert
            StringAssert.Contains(actual, expected);

        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))] // to pass unit test
        public void GetPropertyValuesForWMIClass_With_Win32_Processor_name_Throw_Exception()
        {
            ///AAA rule 
            //Arrange

            WMIConnection connection = new WMIConnection();


            WMIResult.GetPropertyValuesForWMIClass(connection, "SELECT * FROM " + "Win32_Processor", "Win64_Processor");
            //Win64_Processor is error but target to throw Exception


            //Act

            //Assert

        }
    }

}
