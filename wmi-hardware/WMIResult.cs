using System;
using System.Collections.Generic;
using System.Text;
using System.Management;

namespace wmi_hardware
{
    class WMIResult
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
                            device.Add(property, item[property].ToString());
                        }
                        catch (SystemException) {
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
