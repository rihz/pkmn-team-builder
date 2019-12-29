using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace PkmnTeamBuilder.Api.Controllers.Team
{
    [Route("api/[controller]")]
    public class TeamController : Controller
    {
        ITeamService _service;

        public TeamController(ITeamService service)
        {
            _service = service;
        }

        [Route("")]
        [HttpPost]
        public IActionResult AddTeam([FromBody] TeamModel team)
        {
            return Ok(_service.AddTeam(team));
        }

        [Route("")]
        [HttpGet]
        public IActionResult GetTeamsForUser([FromQuery] string userId)
        {
            return Ok(_service.GetTeams(userId));
        }

        [Route("{id}")]
        [HttpDelete]
        public IActionResult DeleteTeam(int id)
        {
            _service.DeleteTeam(id);

            return Ok();
        }
    }
}