using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;

namespace TesteVagaWPF
{
    internal class OperatingSystem
    {
        public string Caption { get; set; }
        public string Version { get; set; }
        public string OSArchitecture { get; set; }
        public string CSName { get; set; }

        public OperatingSystem()
        {
            ManagementScope scope = new ManagementScope("\\\\.\\root\\cimv2");

            string strConsulta = @"SELECT 
                                    Caption, 
                                    Version, 
                                    OSArchitecture, 
                                    CSName
                                    FROM Win32_OperatingSystem";

            ObjectQuery query = new ObjectQuery(strConsulta);
            ManagementObjectSearcher searcher = new ManagementObjectSearcher(scope, query);

            ManagementObjectCollection queryResults = searcher.Get();

            foreach (ManagementObject queryResult in queryResults)
            {
                Caption = queryResult["Caption"].ToString();
                Version = queryResult["Version"].ToString();
                OSArchitecture = queryResult["OSArchitecture"].ToString();
                CSName = queryResult["CSName"].ToString();
            }
        }
    }
}
