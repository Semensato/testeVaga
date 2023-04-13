using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;

namespace TesteVagaWinForms
{
    internal class Processor
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public Processor()
        {
            ManagementScope scope = new ManagementScope("\\\\.\\root\\cimv2");

            string strConsulta = @"SELECT 
                                    Name,
                                    Description
                                    FROM Win32_Processor";

            ObjectQuery query = new ObjectQuery(strConsulta);
            ManagementObjectSearcher searcher = new ManagementObjectSearcher(scope, query);

            ManagementObjectCollection queryResults = searcher.Get();

            foreach (ManagementObject queryResult in queryResults)
            {
                Name = queryResult["Name"].ToString();
                Description = queryResult["Description"].ToString();
            }
        }
    }
}
