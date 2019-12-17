using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace PkmnTeamBuilder.Api.Controllers.Nature
{
    [Route("api/[controller]")]
    public class NatureController : Controller
    {
        INatureService _service;

        public NatureController(INatureService service)
        {
            _service = service;
        }

        [Route("")]
        [HttpGet]
        public IActionResult GetAll()
        {
            var natures = _service.GetNatures();

            return Ok(natures);
        }
    }
}