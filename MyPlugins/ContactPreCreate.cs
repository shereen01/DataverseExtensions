using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xrm.Sdk;

namespace MyPlugIns
{
    public class ContactPreCreate : IPlugin
    {
        public void Execute(IServiceProvider serviceProvider)
        {
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
                string lastname=contactRecord.Attributes["lastname"].ToString();
                if(lastname.Length>=20)
                {
                    throw new InvalidPluginExecutionException("last name should be less than 20 chars");
                }
            }
        }
    }
}
