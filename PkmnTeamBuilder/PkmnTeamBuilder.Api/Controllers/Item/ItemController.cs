using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace PkmnTeamBuilder.Api.Controllers.Item
{
    [Route("api/[controller]")]
    public class ItemController : Controller
    {
        IItemService _service;

        public ItemController(IItemService service)
        {
            _service = service;
        }

        [Route("")]
        [HttpGet]
        public IActionResult GetAll()
        {
            var items = _service.GetItems();

            return Ok(items);
        }
    }
}