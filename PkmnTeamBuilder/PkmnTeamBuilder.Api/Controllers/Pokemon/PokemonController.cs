using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace PkmnTeamBuilder.Api.Controllers.Pokemon
{
    [Route("api/[controller]")]
    public class PokemonController : Controller
    {
        IPokemonService _svc;

        public PokemonController(IPokemonService svc)
        {
            _svc = svc;
        }

        [Route("pokemon/{id}")]
        [HttpGet]
        public IActionResult GetById(int id)
        {
            var pkmn = _svc.GetPokemon(id);

            return Ok(pkmn);
        }

        [Route("pokemon")]
        [HttpGet]
        public IActionResult Search([FromQuery] string name)
        {
            var results = _svc.SearchPokemon(name);

            return Ok(results);
        }
    }
}