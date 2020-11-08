
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Text;
using WebApi;

namespace UnitTetsing
{
    public class TestServerStartup : Startup
    {
        public TestServerStartup(IConfiguration config, IHostingEnvironment env) : base(config, env)
        {

           // env.ConfigureTestServices(ConfigureServices);
        }

      /*  public override void AddMvc(IServiceCollection serviceCollection)
        {
            serviceCollection.AddMvc().AddApplicationPart(typeof(Startup).Assembly);
        }*/

       /* public override void ConfigureAuth(IServiceCollection services)
        {
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = "test";
                x.DefaultChallengeScheme = "test";
            }).AddFakeJwtBearer();

        }*/

        }
    }

