using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Microsoft.Xrm.Sdk;
using Microsoft.PowerPlatform.Dataverse.Client;

namespace SampleFunctionApp
{
    public static class Sample
    {
        [FunctionName("Sample")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            //string name = req.Query["name"];

            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            string connectionString = @"AuthType=OAuth;
                Username=shereen@shereensultana.onmicrosoft.com;
                Password=Bored@house1;
                Url=https://org1c7935d5.crm.dynamics.com/;
                AppId=51f81489-12ee-4a9e-aaae-a2591f45987d;
                RedirectUri=app://58145B91-0C36-4500-8554-080854F2AC97;";
            ServiceClient service = new ServiceClient(connectionString);
            Entity rec = new Entity("contact");
            rec["lastname"] = "Contact2";
            rec["description"] = "this is description";
            Guid contactguid = service.Create(rec);
            //dynamic data = JsonConvert.DeserializeObject(requestBody);
            //name = name ?? data?.name;

            string responseMessage = string.IsNullOrEmpty(contactguid.ToString())
                ? "This HTTP triggered function executed successfully. Pass a name in the query string or in the request body for a personalized response."
                : $"Hello, contact has been created. This HTTP triggered function executed successfully.";

            return new OkObjectResult(responseMessage);
        }
    }
}
