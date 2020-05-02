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
        foreach (string wmiclass in WMIClasses.GetAllWMIClasses())
        {
            Console.WriteLine("---------- WMI Class: " + wmiclass + " ----------\n");
            foreach (var item in WMIResult.GetPropertyValuesForWMIClass(connection, "SELECT * FROM " + wmiclass, wmiclass))
                Console.WriteLine(item.Key + ": " + item.Value);
            Console.WriteLine("\n");
        }

        Console.ReadLine();
    }
}
