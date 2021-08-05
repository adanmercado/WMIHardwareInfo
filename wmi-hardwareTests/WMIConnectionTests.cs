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
    public class WMIConnectionTests
    {
        //Given_When_Then

        [TestMethod]
        public void EstablishConnection_With_default_Return_success()
        {
            //AAA

            //Arrange
            WMIConnection sut = new WMIConnection(); //sut: System Under Test
            sut.EstablishConnection(null, null, null, Environment.MachineName);

            //Act
            //Assert

            //It is correct if it does not return an exception error
        }

        //Success
        [TestMethod]
        public void SetConnectionScope_With_default_Return_success(){
            ///AAA
            
            //Arrange

            WMIConnection sut = new WMIConnection(); //sut: System Under Test
            sut.EstablishConnection(null, null, null, Environment.MachineName);

            //Act
            //Assert

            //It is correct if it does not return an exception error

        }
        [TestMethod]
        public void SetConnectionOptions_When_Then()
        {
            //It is correct if it does not return an exception error

        }
    }

}
