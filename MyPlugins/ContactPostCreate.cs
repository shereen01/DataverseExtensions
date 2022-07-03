using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xrm.Sdk;
namespace MyPlugins
{
    public class ContactPostCreate : IPlugin
    {
        public void Execute(IServiceProvider serviceProvider)
        {
            //to trace logs
            ITracingService tracingService =(ITracingService)serviceProvider.GetService(typeof(ITracingService));
            tracingService.Trace("Running contact post create");
            IPluginExecutionContext context = (IPluginExecutionContext)
            serviceProvider.GetService(typeof(IPluginExecutionContext));

            // Obtain the organization service reference which you will need for
            // web service calls.
            IOrganizationServiceFactory serviceFactory =
            (IOrganizationServiceFactory)serviceProvider.GetService(typeof(IOrganizationServiceFactory));
            IOrganizationService svc = serviceFactory.CreateOrganizationService(context.UserId);
            //retreive the record which user is working on 
            if (context.InputParameters.Contains("Target") && context.InputParameters["Target"] is Entity)
            {
                Entity contactRecord = (Entity)context.InputParameters["Target"];
                //custom code can be added
                //create a task for this contact
                Entity task=new Entity("task");
                task.Attributes.Add("subject", "A task from Plugin");
                //or
                task["description"] = "Sample desc";
                task["regardingobjectid"] = new EntityReference("contact", contactRecord.Id);
                //call organization web service to create task rec in database
                svc.Create(task);
            }
        }
    }
}
