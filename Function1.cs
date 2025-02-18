using System;
using System.Linq;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Crm.Sdk.Messages;
using Microsoft.Xrm.Sdk.Client;
using Microsoft.Xrm.Sdk;
using System.Net;
using System.ServiceModel.Description;

namespace AzureFunctionDemop
{
    public static class Function1
    {
        [FunctionName("Function1")]
        public static async Task<IActionResult> Run (
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req,
            ILogger log, ServiceClient service)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            var _contactid = new Guid();

            try
            {
                string _clientId = "ba0ba2a9-8cae-48f6-90eb-997dddc7cca8";
                string _clientSecret = "Your Client Secret";
                string _environment = "orgc02e4227.crm8";
                var _connectionString = @$"Url=https://{_environment}.dynamics.com;AuthType=ClientSecret;ClientId={_clientId}
                ;ClientSecret={_clientSecret};RequireNewInstance=true";


                var service = new ServiceClient(_connectionString);
                if (service.IsReady)
                {
                    // Create a contact 
                    Entity contact = new Entity("contact")
                    {
                        ["firstname"] = "Rey",
                        ["lastname"] = "Dynamics CRM"
                    };
                    _contactid = service.Create(contact);
                }
                

            }
            catch (Exception ex)
            {
                return new OkObjectResult(ex.Message);
                throw new(ex.Message);
            }
            return new OkObjectResult("Contact Record created with ID " + Convert.ToString(_contactid));
        }
    }
    }

