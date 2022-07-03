using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using TeamTailorWebhooks1.Models;
using Microsoft.Xrm.Sdk;
using Microsoft.PowerPlatform.Dataverse.Client;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TeamTailorWebhooks
{
    //[Route("api/[controller]")]
    [Route("webhook")]
    [ApiController]
    /* public class TeamTailorController : ControllerBase
     {
         // GET: api/<TeamTailorController>
         [HttpGet]
         public IEnumerable<string> Get()
         {
             return new string[] { "value1", "value2" };
         }


         // POST api/<TeamTailorController>
         [HttpPost]
         //[FromBody] JsonElement value
         public string Post()
         {
             using (var wb = new WebClient())
             {
                 wb.UploadString("https://webhook.site/a2a4e6f6-cb31-4e33-b189-f977976c3a40", "Hello world");
                 //wb.UploadString("https://webhook.site/a2a4e6f6-cb31-4e33-b189-f977976c3a40", value.ToString());
                 string connectionString = @"AuthType=OAuth;
                 Username=shereen@shereensultana.onmicrosoft.com;
                 Password=Bored@house1;
                 Url=https://org1c7935d5.crm.dynamics.com/;
                 AppId=51f81489-12ee-4a9e-aaae-a2591f45987d;
                 RedirectUri=app://58145B91-0C36-4500-8554-080854F2AC97;";
                 ServiceClient service = new ServiceClient(connectionString);

                 Entity contact = new Entity("contact");
                 contact["lastname"] = "Testing";
                 Guid contactGuid = service.Create(contact);
                 Console.WriteLine(contactGuid);
             }


             System.Diagnostics.Trace.WriteLine("Post method started....");
             //  System.Diagnostics.Trace.WriteLine(value.ToString());

             // Root root = JsonConvert.DeserializeObject<Root>(value.ToString());

             return "";
         }*/
    public class TeamTailorController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "student", "Test" };
        }


        [HttpPost]
        //[FromBody] JsonElement value
        public string Post([FromBody] JsonElement val)
        {
            using (var wb = new WebClient())
            {
                student record = JsonConvert.DeserializeObject<student>(val.ToString());
                string connectionString = @"AuthType=OAuth;
                Username=shereen@shereensultana.onmicrosoft.com;
                Password=Bored@house1;
                Url=https://org1c7935d5.crm.dynamics.com/;
                AppId=51f81489-12ee-4a9e-aaae-a2591f45987d;
                RedirectUri=app://58145B91-0C36-4500-8554-080854F2AC97;";
                ServiceClient service = new ServiceClient(connectionString);
                Entity contactrec = new Entity("contact");
                contactrec["lastname"] = record.Name;
                contactrec["description"] = record.RollNo;
                Guid contactguid = service.Create(contactrec);
                //Entity studentdetdetails = new Entity("StudentDetails");
                //studentdetdetails["name"] = "Test";
                //studentdetdetails["rollno"] = 101;
                //studentdetdetails["age"] = 20;
               // Guid studentGuid = service.Create(studentdetdetails);

            }


            System.Diagnostics.Trace.WriteLine("Post method started....");
            //  System.Diagnostics.Trace.WriteLine(value.ToString());



            return "";
        }

    }
}