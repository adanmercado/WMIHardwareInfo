using FluentAssertions;
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
            string actual = "";
            foreach (var device in WMIResult.GetPropertyValuesForWMIClass(connection, "SELECT * FROM Win32_Processor", "Win32_Processor"))
            {
                foreach (var property in device)
                {
                    actual = actual + property.Key + ": " + property.Value;
                }
            }

            //Act
             string expected = "i7-8550U";//Of course, it varies according to the type of processor that will be tested

            //Assert
            StringAssert.Contains(actual, expected);

            //FluentAssertions
            //using FluentAssertions;

            actual.Should().Contain(expected);
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
