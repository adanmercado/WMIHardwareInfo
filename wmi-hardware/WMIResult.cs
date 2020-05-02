using System;
using System.Collections.Generic;
using System.Text;
using System.Management;

namespace wmi_hardware
{
    class WMIResult
    {
        public static List<KeyValuePair<string, string>> GetPropertyValuesForWMIClass(WMIConnection connection, string query, string className)
        {
            ManagementScope connectionScope = connection.ConnectionScope;
            List<KeyValuePair<string, string>> properties = new List<KeyValuePair<string, string>>();
            SelectQuery msQuery = new SelectQuery(query);
            ManagementObjectSearcher searchProcedure = new ManagementObjectSearcher(connectionScope, msQuery);

            try
            {
                foreach (ManagementObject item in searchProcedure.Get())
                {
                    foreach (string property in WMIClasses.GetPropertiesForWMIClass(className))
                    {
                        try {
                            properties.Add(new KeyValuePair<string, string>(property, item[property].ToString()));
                        }
                        catch (SystemException) {
                        }
                    }
                }
            }
            catch (ManagementException e)
            {
                Console.WriteLine("WMIResult Error: " + e.Message.ToString());
            }

            return properties;
        }
    }
}
