using DeveloperChallenge.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeveloperChallenge.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuotableController : ControllerBase
    {

        private readonly IQuotableService quotableService;
        public QuotableController(IQuotableService _quotableService)
        {
            quotableService = _quotableService;
        }
        [HttpGet]
        public ActionResult GetRandomQuote()
        {
            var response = quotableService.GetRandomQuote();
            return StatusCode(200, response);
        }

        [HttpGet("getByAuthor")]
        public object GetQuoteByAutor()
        {
            var response = quotableService.GetQuotesByAuthor();
            return StatusCode(200, response);
        }
    }
}
