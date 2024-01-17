using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Tooling.Connector;

namespace ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Authenticate
            string connectionString = "AuthType=Office365;Url=https://orgeb294ea2.crm8.dynamics.com;Username=admin@dynamicscrm504.onmicrosoft.com;Password=Hsdfj566@djf";

            CrmServiceClient service = new CrmServiceClient(connectionString);

            // Create a contact in dynamics 365

            Entity contact = new Entity("contact");
            contact.Attributes.Add("lastname", "consoleapp");

            Guid guid = service.Create(contact);

            Console.WriteLine(guid);
            Console.Read();
        }
    }
}
