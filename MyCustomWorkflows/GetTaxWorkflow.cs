﻿using System;
using System.Activities;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using Microsoft.Xrm.Sdk.Workflow;

namespace MyCustomWorkflows
{
    public class GetTaxWorkflow : CodeActivity
    {
        [Input("Key")]
        public InArgument<string> Key { get; set; }

        [Output("Tax")]
        public OutArgument<string> Tax { get; set; }
        protected override void Execute(CodeActivityContext executionContext)
        {
            //Create the tracing service
            ITracingService tracingService = executionContext.GetExtension<ITracingService>();

            //Create the context
            IWorkflowContext context = executionContext.GetExtension<IWorkflowContext>();
            IOrganizationServiceFactory serviceFactory = executionContext.GetExtension<IOrganizationServiceFactory>();
            IOrganizationService service = serviceFactory.CreateOrganizationService(context.UserId);

            string key = Key.Get(executionContext);

            // Get data from Configuration Entity
            // Call organization web service

            QueryByAttribute query = new QueryByAttribute("ent_configuration");
            query.ColumnSet = new ColumnSet(new string[] { "ent_value" });
            query.AddAttributeValue("ent_name", key);
            EntityCollection collection = service.RetrieveMultiple(query);

            if (collection.Entities.Count != 1)
            {
                tracingService.Trace("Something is wrong with the configuration.");
            }

            Entity config = collection.Entities.FirstOrDefault();

            Tax.Set(executionContext, config.Attributes["ent_value"].ToString());
        }
    }
}
