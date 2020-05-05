using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using wmi_hardware;

class Hardware
{
    static void Main(string[] args)
    {
        //Local Connection
        WMIConnection connection = new WMIConnection();

        //Get all hardware info iteratively
        //Get all wmi classes
        foreach (string wmiclass in WMIClasses.GetAllWMIClasses())
        {
            Console.WriteLine("---------- WMI Class: " + wmiclass + " ----------\n");
            //Get all devices of wmi class
            foreach(var device in WMIResult.GetPropertyValuesForWMIClass(connection, "SELECT * FROM " + wmiclass, wmiclass))
            {
                //Print all device properties
                foreach(var property in device)
                {
                    Console.WriteLine(property.Key + ": " + property.Value);
                }
                Console.WriteLine("\n");
            }
            Console.WriteLine("\n");
        }

        Console.ReadLine();
    }
}
