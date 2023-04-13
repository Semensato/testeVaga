using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;

namespace TesteVagaWPF
{
    internal class ColetaDados
    {
        public OperatingSystem OperatingSystem { get; set; }
        public Processor Processor { get; set; }
        public DotNetFramework DotNetFramework { get; set; }
        public IList<NetworkInterface> NetworkInterfaces { get; set; }

        public ColetaDados()
        {
            OperatingSystem = new OperatingSystem();
            Processor = new Processor();
            DotNetFramework = new DotNetFramework();
            NetworkInterfaces = new List<NetworkInterface>();

            PreencheRedes();
        }

        private void PreencheRedes()
        {
            ManagementScope scope = new ManagementScope("\\\\.\\root\\cimv2");

            string strConsulta = @"SELECT 
                                    Name, 
                                    MACAddress,
                                    InterfaceIndex
                                    FROM Win32_NetworkAdapter";

            ObjectQuery query = new ObjectQuery(strConsulta);
            ManagementObjectSearcher searcher = new ManagementObjectSearcher(scope, query);

            ManagementObjectCollection queryResults = searcher.Get();

            foreach (ManagementObject queryResult in queryResults)
            {
                string macAddress = queryResult["MACAddress"] as string;
                NetworkInterface NetInt = new NetworkInterface(queryResult["Name"].ToString(), macAddress, queryResult["InterfaceIndex"].ToString());

                NetworkInterfaces.Add(NetInt);
            }
        }

        
    }
}
