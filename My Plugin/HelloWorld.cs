using System.ServiceModel;
using Microsoft.Xrm.Sdk;

namespace My_Plugin;
public class HelloWorld : IPlugin
{
    public void Execute(IServiceProvider serviceProvider)
    {
        // Obtain the tracing service
        ITracingService? tracingService =
        (ITracingService?)serviceProvider.GetService(typeof(ITracingService));

        // Obtain the execution context from the service provider.  
        IPluginExecutionContext? context = (IPluginExecutionContext?)
            serviceProvider.GetService(typeof(IPluginExecutionContext));

        // The InputParameters collection contains all the data passed in the message request.  
        if (context.InputParameters.Contains("Target") &&
            context.InputParameters["Target"] is Entity)
        {
            // Obtain the target entity from the input parameters.  
            Entity entity = (Entity)context.InputParameters["Target"];

            // Obtain the IOrganizationService instance which you will need for  
            // web service calls.  
            IOrganizationServiceFactory? serviceFactory =
                (IOrganizationServiceFactory?)serviceProvider.GetService(typeof(IOrganizationServiceFactory));
            IOrganizationService? service = serviceFactory?.CreateOrganizationService(context.UserId);

            try
            {
                // Reading from attribute values
                string? firstName = entity.Attributes["firstname"].ToString();
                string? lastName = entity.Attributes["lastname"].ToString();

                // Assign data to description attribute
                entity.Attributes.Add("description", "Hello World" + firstName + lastName);
            }

            catch (FaultException<OrganizationServiceFault> ex)
            {
                throw new InvalidPluginExecutionException("An error occurred in FollowUpPlugin.", ex);
            }

            catch (Exception ex)
            {
                tracingService?.Trace("FollowUpPlugin: {0}", ex.ToString());
                throw;
            }
        }
    }
}
