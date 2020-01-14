using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json.Serialization;
using PkmnTeamBuilder.Api.Controllers;
using PkmnTeamBuilder.Api.Controllers.Ability;
using PkmnTeamBuilder.Api.Controllers.Auth;
using PkmnTeamBuilder.Api.Controllers.Item;
using PkmnTeamBuilder.Api.Controllers.Members;
using PkmnTeamBuilder.Api.Controllers.Move;
using PkmnTeamBuilder.Api.Controllers.Nature;
using PkmnTeamBuilder.Api.Controllers.News;
using PkmnTeamBuilder.Api.Controllers.Pokemon;
using PkmnTeamBuilder.Api.Controllers.Team;
using PkmnTeamBuilder.Data.Context;
using PkmnTeamBuilder.Entities;

namespace PkmnTeamBuilder.Api
{
    public class Startup
    {
        private const string _secretKey = "1597643280794658123049156237801954826730";
        private readonly SymmetricSecurityKey _signingKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_secretKey));

        public IConfiguration Configuration { get; }

        private MapperConfiguration _mapperConfiguration { get; set; }

        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddEnvironmentVariables();

            Configuration = builder.Build();
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            _mapperConfiguration = new MapperConfiguration(config =>
            {
                config.AddProfile(new AuthMapProfile());
                config.AddProfile(new PokemonMapProfile());
                config.AddProfile(new MoveMapProfile());
                config.AddProfile(new AbilityMapProfile());
                config.AddProfile(new ItemMapProfile());
                config.AddProfile(new NatureMapProfile());
                config.AddProfile(new TeamMemberMapProfile());
                config.AddProfile(new NewsMapProfile());
            });

            services.AddCors(options =>
            {
                options.AddPolicy("AllowAll",
                    builder => builder
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowAnyOrigin()
                    .AllowCredentials());
            });

            services.AddMvc().AddJsonOptions(options =>
            {
                options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
            });

            services.AddEntityFrameworkSqlServer().AddDbContext<TeamBuilderContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
            });

            services.AddMvc();

            services.AddSingleton<IJwtFactory, JwtFactory>();

            services.AddScoped<IPokemonRepository, PokemonRepository>();
            services.AddScoped<IPokemonService, PokemonService>();
            services.AddScoped<IItemRepository, ItemRepository>();
            services.AddScoped<IItemService, ItemService>();
            services.AddScoped<INatureRepository, NatureRepository>();
            services.AddScoped<INatureService, NatureService>();
            services.AddScoped<ITeamRepository, TeamRepository>();
            services.AddScoped<ITeamService, TeamService>();
            services.AddScoped<ITeamMemberRepository, TeamMemberRepository>();
            services.AddScoped<ITeamMemberService, TeamMemberService>();
            
            services.AddSingleton(sp => _mapperConfiguration.CreateMapper());

            var jwtAppSettingOptions = Configuration.GetSection(nameof(JwtIssuerOptions));

            services.Configure<JwtIssuerOptions>(options =>
            {
                options.Issuer = jwtAppSettingOptions[nameof(JwtIssuerOptions.Issuer)];
                options.Audience = jwtAppSettingOptions[nameof(JwtIssuerOptions.Audience)];
                options.SigningCredentials = new SigningCredentials(_signingKey, SecurityAlgorithms.HmacSha256);
            });

            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidIssuer = jwtAppSettingOptions[nameof(JwtIssuerOptions.Issuer)],

                ValidateAudience = true,
                ValidAudience = jwtAppSettingOptions[nameof(JwtIssuerOptions.Audience)],

                ValidateIssuerSigningKey = true,
                IssuerSigningKey = _signingKey,

                RequireExpirationTime = false,
                ValidateLifetime = false,
                ClockSkew = TimeSpan.Zero
            };

            services.AddAuthentication().AddJwtBearer(a =>
            {
                a.TokenValidationParameters = tokenValidationParameters;
            });

            services.AddAuthorization(options =>
            {
                options.AddPolicy("ApiUser", policy => policy.RequireClaim("rol", "api_access"));
            });

            services.AddIdentity<AppUser, IdentityRole>(options =>
            {
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequiredLength = 5;
            })
                .AddEntityFrameworkStores<TeamBuilderContext>()
                .AddDefaultTokenProviders();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole();
            loggerFactory.AddDebug();

            app.UseCors("AllowAll");

            app.UseExceptionHandler(builder =>
            {
                builder.Run(async context =>
                {
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    context.Response.ContentType = "application/json";
                    context.Response.Headers.Add("Access-Control-Allow-Origin", "*");
                    context.Response.Headers.Add("Access-Control-Allow-Headers", "Origin, X-Requested-With, Content-Type, Accept");

                    var error = context.Features.Get<Microsoft.AspNetCore.Diagnostics.IExceptionHandlerFeature>();

                    if (error != null)
                    {
                        await context.Response.WriteAsync(new { FtpStatusCode = (int)HttpStatusCode.InternalServerError, Message = String.IsNullOrEmpty(error.Error.Message) ? "An error occured." : error.Error.Message }.ToString()).ConfigureAwait(false);
                    }
                });
            });

            app.UseMvc();
        }
    }
}
