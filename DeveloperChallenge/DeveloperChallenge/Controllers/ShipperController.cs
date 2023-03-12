using DeveloperChallenge.Services.Interfaces;
using DeveloperChallenge.Services.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeveloperChallenge.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShipperController : ControllerBase
    {
        private readonly IShipperService _shipperService;


        public ShipperController(IShipperService shipperService)
        {
           _shipperService = shipperService;

        }

        [HttpGet]
        public ActionResult GetShippers()
        {
            var response = _shipperService.GetShippers();
            return StatusCode(200, response.Item3);
        }

        [HttpGet, Route("shipperById")]
        public ActionResult GetAuditTrail(int id)
        {
            var response = _shipperService.GetShipperDetailById(id);
            return StatusCode(200, response.Item3);
        }

    }
}
