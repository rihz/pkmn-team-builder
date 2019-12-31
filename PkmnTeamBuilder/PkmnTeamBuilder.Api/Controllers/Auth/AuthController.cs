using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using PkmnTeamBuilder.Api.Controllers.Auth.Settings;
using PkmnTeamBuilder.Api.Models;
using PkmnTeamBuilder.Data.Context;
using PkmnTeamBuilder.Entities;

namespace PkmnTeamBuilder.Api.Controllers.Auth
{
    [Route("api/[controller]")]
    public class AuthController : Controller
    {
        TeamBuilderContext _context;
        UserManager<AppUser> _userManager;
        IMapper _mapper;
        IJwtFactory _factory;
        JwtIssuerOptions _options;
        JsonSerializerSettings _serializerSettings;
        IUserSettingsService _service;

        public AuthController(UserManager<AppUser> userManager, IMapper mapper, 
            TeamBuilderContext context, IJwtFactory factory,
            IOptions<JwtIssuerOptions> options,
            IUserSettingsService service)
        {
            _context = context;
            _mapper = mapper;
            _userManager = userManager;
            _factory = factory;
            _options = options.Value;
            _service = service;

            _serializerSettings = new JsonSerializerSettings
            {
                Formatting = Formatting.Indented
            };
        }

        [HttpPost("signup")]
        public async Task<IActionResult> Signup([FromBody] SignupViewModel model)
        {
            var identity = _mapper.Map<AppUser>(model);
            identity.UserName = model.Username;

            try
            {
                var result = await _userManager.CreateAsync(identity, model.Password);

                if (!result.Succeeded)
                {
                    return new BadRequestObjectResult(result.Errors.First());
                }

                await _context.Users.AddAsync(identity);

                var user = await GetClaimsIdentity(model.Username, model.Password);

                _service.PostSettings(user.Claims.First(x => x.Type == "id").Value);
            }
            catch(Exception ex)
            {
                Console.WriteLine("An error occured");
            }        

            return Ok(true);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginViewModel model)
        {
            var identity = await GetClaimsIdentity(model.Username, model.Password);

            if (identity == null)
            {
                return BadRequest("Login Failure");
            }

            var settings = _service.GetSettings(identity.Claims.First(x => x.Type == "id").Value);

            var response = new
            {
                id = identity.Claims.Single(x => x.Type == "id").Value,
                auth_token = await _factory.GenerateEncodedToken(model.Username, identity),
                expires_in = (int)_options.ValidFor.TotalSeconds,
                username = model.Username,
                email = "testemail@email.email",
                settings
            };

            var json = JsonConvert.SerializeObject(response, _serializerSettings);
            return new OkObjectResult(json);
        }

        [HttpGet("{id}/settings")]
        public IActionResult GetSettings(string id)
        {
            return Ok(_service.GetSettings(id));
        }

        private async Task<ClaimsIdentity> GetClaimsIdentity(string username, string password)
        {
            if (!string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(password))
            {
                var userToVerify = await _userManager.FindByNameAsync(username);

                if (userToVerify != null)
                {
                    if (await _userManager.CheckPasswordAsync(userToVerify, password))
                    {
                        return await Task.FromResult(_factory.GenerateClaimsIdentity(username, userToVerify.Id));
                    }
                }
            }

            return await Task.FromResult<ClaimsIdentity>(null);
        }
    }
}