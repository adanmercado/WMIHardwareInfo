using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using wmi_hardware;

//Fork by: Mohammad Yaser Ammar
//https://github.com/MohammadYAmmar/
//Feture 1:
//Add Unit test project


namespace wmi_hardwareTests
{
    [TestClass]
    public class WMIClassesTests
    {
        //Given_When_Then
        [TestMethod]
        public void GetPropertiesForWMIClass_When_ClassWin32_Processor_Return_name_CPU()
        {

            List<string> actualList = WMIClasses.GetPropertiesForWMIClass("Win32_Processor");

            //Error
            //System.IO.DirectoryNotFoundException: Could not find a part of the path 'C:\Users\Mohammad Yaser Ammar\Documents\GitHub\WMIHardwareInfo\wmi-hardwareTests\bin\wmiclasses\WMIClassProperties.xml'.
            //Then but file here #todo !!


            string expected = "Name";
            List<string> expectedList = new List<string> { "Name", "NumberOfCores", "NumberOfLogicalProcessors" };


            //Assert
            CollectionAssert.Contains(actualList, expected);

            //#todo with other library
            //CollectionAssert.Contains(actualList, expectedList);
        }

        //Success
        [TestMethod]
        public void GetAllWMIClasses_Return_success_load_file()
        {
            ///AAA

            //Arrange

            WMIClasses.GetAllWMIClasses();


            //Act
            //Assert

            //It is correct if it does not return an exception error

        }


    }
}
