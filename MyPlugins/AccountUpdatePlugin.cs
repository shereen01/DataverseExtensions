using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
namespace MyPlugins
{
    public class AccountUpdatePlugin : IPlugin
    {
        public void Execute(IServiceProvider serviceProvider)
        {
            //to trace logs
            ITracingService tracingService = (ITracingService)serviceProvider.GetService(typeof(ITracingService));
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
                Entity account = (Entity)context.InputParameters["Target"];
                //custom code can be added
                //get phone no
                //string phone=account.Attributes["telephone1"].ToString();
                //get fax
                //string fax = account.Attributes["fax"].ToString();
                ColumnSet columnSet =new ColumnSet();
                columnSet.AddColumn("telephone1");
                columnSet.AddColumn("fax");
                Entity accPreImage = context.PreEntityImages["PreImage"];
                //Entity accwithmoreattri = svc.Retrieve("account", account.Id, columnSet);
                if(!accPreImage.Attributes.Contains("telephone1")&& !accPreImage.Attributes.Contains("fax"))
                {
                    throw new InvalidPluginExecutionException("Either phone or fax is mandatory");
                }
            }
        }
    }
}
