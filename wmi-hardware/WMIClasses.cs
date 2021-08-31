using System.IO;
using System.Collections.Generic;
using System.Xml;

namespace wmi_hardware
{
    public class WMIClasses
    {
        public static List<string> GetPropertiesForWMIClass(string WMIClassName)
        {
            List<string> propertiesList = new List<string>();
            XmlDocument xmldoc = new XmlDocument();
            xmldoc.LoadXml(Properties.Resources.wmiclasses);

            XmlNode wmiClassNode = xmldoc.SelectSingleNode("wmi/class[@name='" + WMIClassName + "']");
            foreach (XmlNode node in wmiClassNode.ChildNodes)
                propertiesList.Add(node.InnerText);

            return propertiesList;
        }

        public static List<string> GetAllWMIClasses()
        {
            List<string> wmiClasses = new List<string>();
            XmlDocument xmldoc = new XmlDocument();
            xmldoc.LoadXml(Properties.Resources.wmiclasses);

            foreach (XmlNode node in xmldoc.SelectNodes("wmi/class"))
                wmiClasses.Add(node.Attributes["name"].Value);

            return wmiClasses;
        }
    }
}
