using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace wmi_hardware
{
    public class WMIClasses
    {
        public static List<string> GetPropertiesForWMIClass(string WMIClassName)
        {
            string filename = Directory.GetCurrentDirectory() + "\\..\\..\\wmiclasses\\WMIClassProperties.xml";
            List<string> propertiesList = new List<string>();
            XmlDocument xmldoc = new XmlDocument();
            xmldoc.Load(filename);

            XmlNode wmiClassNode = xmldoc.SelectSingleNode("wmi/class[@name='" + WMIClassName + "']");
            foreach (XmlNode node in wmiClassNode.ChildNodes)
                propertiesList.Add(node.InnerText);

            return propertiesList;
        }

        public static List<string> GetAllWMIClasses()
        {
            string filename = Directory.GetCurrentDirectory() + "\\..\\..\\wmiclasses\\WMIClassProperties.xml";
            List<string> wmiClasses = new List<string>();
            XmlDocument xmldoc = new XmlDocument();
            xmldoc.Load(filename);

            foreach(XmlNode node in xmldoc.SelectNodes("wmi/class"))
                wmiClasses.Add(node.Attributes["name"].Value);

            return wmiClasses;
        }
    }
}
