using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Messages.Commands;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NServiceBus;

namespace Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KeeperCommandController : ControllerBase
    {
        IEndpointInstance _endpointInstance;

        public KeeperCommandController(IEndpointInstance endpointInstance)
        {
            _endpointInstance = endpointInstance;
        }

        [HttpPost]
        public ActionResult RegisterKeeper(string firstName, string lastName)
        {
            var cmd = new RegisterKeeperCommand();
            cmd.FirstName = firstName;
            cmd.LastName = lastName;

            _endpointInstance.Send(cmd).ConfigureAwait(false);

            return Ok();
        }
    }
}