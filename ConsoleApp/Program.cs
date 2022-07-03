using System;
using Microsoft.PowerPlatform.Dataverse.Client;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;

namespace ConsoleAppCore
{
    class Program
    {
        static void Main(string[] args)
        {
            // Using OAuth username and password
            string connectionString = @"AuthType=OAuth;
  Username=shereen@shereensultana.onmicrosoft.com;
  Password=Bored@house1;
  Url=https://org7ae2e893.crm.dynamics.com/;
  AppId=51f81489-12ee-4a9e-aaae-a2591f45987d;
  RedirectUri=app://58145B91-0C36-4500-8554-080854F2AC97;";
            ServiceClient service = new ServiceClient(connectionString);

            //// Create contact record programatically
            //Entity contact = new Entity("contact");
            //contact["lastname"] = "Smith (console app)";
            //Guid contactGuid = service.Create(contact);

            //// Create account
            //Entity acc = new Entity("account");
            //acc["name"] = "Test Acc";
            //Guid accGuid = service.Create(acc);


            //// Create custom entity record
            //Entity req = new Entity("new_expenserequest");
            //acc["new_name"] = "Test req";
            //Guid reqGuid = service.Create(req);


            // Pull contacts
            // Many ways to pull data
            // 1. Use QueryExpression
            //select firstname,lastname from contact where attname =value
            //QueryExpression query = new QueryExpression("contact");
            //query.ColumnSet.AddColumn("fullname");
            //  query.Criteria.AddCondition("")
            string xmlQuery = @"<fetch version='1.0' output-format='xml-platform' mapping='logical' distinct='false'>
  <entity name='account'>
    <attribute name='name' />
    <attribute name='primarycontactid' />
    <attribute name='telephone1' />
    <attribute name='accountid' />
    <order attribute='name' descending='false' />
    <filter type='and'>
      <condition attribute='name' operator='eq' value='testacc' />
      <condition attribute='name' operator='eq' value='test' />
    </filter>
  </entity>
</fetch>";
            EntityCollection collection = service.RetrieveMultiple( new FetchExpression(xmlQuery);

            foreach (var item in collection.Entities)
            {

                Console.WriteLine(item.Attributes["fullname"].ToString());
            }
            
          
        }
    }
}