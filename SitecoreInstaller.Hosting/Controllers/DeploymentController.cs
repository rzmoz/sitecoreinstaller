using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace SitecoreInstaller.Hosting.Controllers
{
    public class DeploymentController : Controller
    {
        [Route("Deployments")]
        [HttpPut]
        public IActionResult NewDeployment()
        {
            var list = new Dictionary<string, int>();
            for (var i = 0; i < 10; i++)
                list.Add(i.ToString(), i);


            return new ObjectResult(list);
        }
    }
}
