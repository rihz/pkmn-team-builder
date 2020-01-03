using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace PkmnTeamBuilder.Api.Controllers.Members
{
    [Route("api/member")]
    public class TeamMemberController : Controller
    {
        ITeamMemberService _service;

        public TeamMemberController(ITeamMemberService service)
        {
            _service = service;
        }

        [Route("{userId}")]
        [HttpGet]
        public IActionResult GetForUser(string userId)
        {
            return Ok(_service.GetForUser(userId));
        }
    }
}