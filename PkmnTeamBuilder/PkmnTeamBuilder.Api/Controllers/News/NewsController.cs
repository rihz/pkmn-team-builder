using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace PkmnTeamBuilder.Api.Controllers.News
{
    [Route("api/[controller]")]
    public class NewsController : Controller
    {
        INewsService _service;

        public NewsController(INewsService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("")]
        public IActionResult GetNews()
        {
            return Ok(_service.GetNews());
        }
    }
}