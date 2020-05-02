using System;
using System.Management;
using System.Collections.Generic;
using System.Text;

namespace wmi_hardware
{
    class WMIConnection
    {
        ManagementScope connectionScope;
        ConnectionOptions options;

        public WMIConnection()
        {
            EstablishConnection(null, null, null, Environment.MachineName);
        }

        public WMIConnection(string username, string password, string domain, string machineName)
        {
            EstablishConnection(username, password, domain, machineName);
        }

        public ManagementScope ConnectionScope
        {
            get { return connectionScope; }
        }

        public ConnectionOptions Options
        {
            get { return options; }
        }
              
        public ConnectionOptions SetConnectionOptions()
        {
            ConnectionOptions options = new ConnectionOptions();
            options.Impersonation = ImpersonationLevel.Impersonate;
            options.Authentication = AuthenticationLevel.Default;
            options.EnablePrivileges = true;
            return options;
        }

        public ManagementScope SetConnectionScope(string machineName, ConnectionOptions options)
        {
            ManagementScope connectScope = new ManagementScope();
            connectScope.Path = new ManagementPath(@"\\" + machineName + @"\root\CIMV2");
            connectScope.Options = options;

            try
            {
                connectScope.Connect();
            }
            catch (ManagementException e)
            {
                Console.WriteLine("WMIConnection: " + e.Message.ToString());
            }
            return connectScope;
        }

        private void EstablishConnection(string userName, string password, string domain, string machineName)
        {
            options = SetConnectionOptions();
            if (domain != null || userName != null)
            {
                options.Username = domain + "\\" + userName;
                options.Password = password;
            }
            connectionScope = SetConnectionScope(machineName, options);
        }
      
   }
}
