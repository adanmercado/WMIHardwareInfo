using System;
using System.Collections.Generic;
using System.Text;
using System.Management;

//Fork by: Mohammad Yaser Ammar
//https://github.com/MohammadYAmmar/
//Feture 0: solving project problems
//There was a problem when I first ran the project in a function, I fixed it before adding the test project

namespace wmi_hardware
{
    public class WMIResult
    {
        public static List<Dictionary<string, string>> GetPropertyValuesForWMIClass(WMIConnection connection, string query, string className)
        {
            ManagementScope connectionScope = connection.ConnectionScope;
            List<Dictionary<string, string>> devices = new List<Dictionary<string, string>>();
            List<string> properties = WMIClasses.GetPropertiesForWMIClass(className);
            SelectQuery msQuery = new SelectQuery(query);
            ManagementObjectSearcher searchProcedure = new ManagementObjectSearcher(connectionScope, msQuery);

            try
            {
                foreach (ManagementObject item in searchProcedure.Get())
                {
                    Dictionary<string, string> device = new Dictionary<string, string>();
                    foreach (string property in properties)
                    {
                        try {
                            //Old:
                            //device.Add(property, item[property].ToString());

                            //Mohammad Yasir Ammar: to solve Screenshot 1 first-run problem 
                            if (item[property] == null)
                            {
                                //To get out of the for each loop
                                //without going through the problem that stopped the program
                                //break;
                                continue;
                            }
                            device.Add(property, item[property].ToString());
                        }
                        catch (SystemException)
                        {
                        }
                    }
                    devices.Add(device);
                }
            }
            catch (ManagementException e)
            {
                Console.WriteLine("WMIResult Error: " + e.Message.ToString());
            }

            return devices;
        }
    }
}
