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
        ICommandDespatcher _commandDespatcher;

        public KeeperCommandController(ICommandDespatcher commandDespatcher)
        {
            
            _commandDespatcher = commandDespatcher;
        }

        [HttpGet]
        public string Get()
        {
            var cmd = new RegisterKeeperCommand();
            cmd.FirstName = "asd";
            cmd.LastName = "asdas";

            _commandDespatcher.SendCommand(cmd);

            return "hello";
        }

        [HttpPost]
        public ActionResult RegisterKeeper(string firstName, string lastName)
        {
            var cmd = new RegisterKeeperCommand();
            cmd.FirstName = firstName;
            cmd.LastName = lastName;

            _commandDespatcher.SendCommand(cmd);

            return Ok();
        }

        [HttpPost]
        public ActionResult RegisterTrailer([FromBody]TrailersDto trailersDto)
        {
            var cmd = new RegisterTrailersCommand();
            cmd.KeeperId = trailersDto.KeeperId;

            cmd.payment.Amount = trailersDto.Payment.Amount;
            cmd.payment.Id = trailersDto.Payment.Id;

            foreach (var trailerDto in trailersDto.Trailers)
            {
                cmd.Trailers.Append(new RegisterTrailersCommand.Trailer()
                {
                    Manufacturer = trailerDto.Manufacturer,
                    Vin = trailerDto.Vin,
                    Weight = trailerDto.Weight
                });
            }

            _commandDespatcher.SendCommand(cmd);

            return Ok();
        }
    }
}