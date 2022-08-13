using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Demo.Service;
using System.Collections.Generic;

namespace Demo.sharpshift
{
    
    public static class Search
    {
        [FunctionName("Search")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            APIResponse<SteamModel> model = new APIResponse<SteamModel>();
            string name = req.Query["key"];
            try
            {
              model.Data=await  DataService.Search(name);
                model.Status = true;
            }
            catch (Exception ex)
            {
                model.Message = ex.Message;
            }
            return new OkObjectResult(model);
        }
    }
}
