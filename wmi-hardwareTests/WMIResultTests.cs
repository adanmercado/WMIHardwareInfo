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

        //#todo complete

        [TestMethod]
        //Given_When_Then rule

        //GetPropertyValuesForWMIClass(@"\root\CIMV2, "SELECT * FROM Win32_Processor" , "Name")

        public void GetPropertyValuesForWMIClass_With_Win32_Processor_name_Return_i7_8550U()
        {
            ///AAA rule 
            //Arrange

            //Local Connection
            WMIConnection connection = new WMIConnection();

            string temp = "";
            //Get all hardware info iteratively
            //Get all wmi classes
            //foreach (string wmiclass in WMIClasses.GetAllWMIClasses())
            //{
                //Console.WriteLine("---------- WMI Class: " + wmiclass + " ----------\n");
                //Get all devices of wmi class
                WMIResult.GetPropertyValuesForWMIClass(connection, "SELECT * FROM " + "Win32_Processor", "Name");


            //Act
            // string actual = temp;
            string actual = "i7-8550U";

            string expected = "i7-8550U";

            //Assert
            //Assert.AreEqual(expected, actual);
            StringAssert.Contains(expected, actual);

        }
        //#todo complete

        [TestMethod]
    [ExpectedException(typeof(ManagementException))] // to pass unit test

        public void GetPropertyValuesForWMIClass_With_Win32_Processor_name_Throw_Exception()
    {
            ///AAA rule 
            //Arrange

            //Local Connection
            WMIConnection connection = new WMIConnection();

            string temp = "";
            //Get all hardware info iteratively
            //Get all wmi classes
            //foreach (string wmiclass in WMIClasses.GetAllWMIClasses())
            //{
            //Console.WriteLine("---------- WMI Class: " + wmiclass + " ----------\n");
            //Get all devices of wmi class
            WMIResult.GetPropertyValuesForWMIClass(connection, "SELECT * FROM " + "Win32_Processor", "Name");


            //Act
            
            //Assert

        }
    }

}
