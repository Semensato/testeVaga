using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;

namespace TesteVagaWinForms
{
    internal class NetworkInterface
    {
        public string Name { get; set; }
        public string MACAddress { get; set; }
        public string IPAddress { get; set; }
        public string InterfaceIndex { get; set; }

        public NetworkInterface(string Name, string MACAddress, string InterfaceIndex)
        {
            this.Name = Name;
            this.MACAddress = MACAddress;
            this.InterfaceIndex = InterfaceIndex;
            this.IPAddress = GetIpAddress(this.InterfaceIndex);
        }

        private string GetIpAddress(string interfaceIndex)
        {
            string[] ipAddress = { };

            ManagementScope scope = new ManagementScope("\\\\.\\root\\cimv2");

            string strConsulta = @"SELECT 
                                    IPAddress
                                    FROM Win32_NetworkAdapterConfiguration
                                    WHERE InterfaceIndex = " + interfaceIndex;

            ObjectQuery query = new ObjectQuery(strConsulta);
            ManagementObjectSearcher searcher = new ManagementObjectSearcher(scope, query);

            ManagementObjectCollection queryResults = searcher.Get();

            foreach (ManagementObject queryResult in queryResults)
            {
                ipAddress = (string[])queryResult["IPAddress"];
            }

            string ip = "";

            if (ipAddress == null)
                return "";

            foreach (string ipAd in ipAddress)
            {
                ip += ipAd;
            }

            return ip;
        }
    }
}
