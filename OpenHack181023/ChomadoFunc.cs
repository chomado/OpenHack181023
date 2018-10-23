
using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace OpenHack181023
{
    public static class ChomadoFunc
    {
        [FunctionName("ChomadoFunc")]
        public static async Task<IActionResult> Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = null)]HttpRequest req, ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            string productId = req.Query["productId"];

            //string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            //dynamic data = JsonConvert.DeserializeObject(requestBody);
            //productId = productId ?? data?.productId;

            return productId != null
                ? (ActionResult)new OkObjectResult($"The product name for your product id {productId} is Starfruit Explosion")
                : new BadRequestObjectResult("Please pass a name on the query string or in the request body");
        }
    }
}
