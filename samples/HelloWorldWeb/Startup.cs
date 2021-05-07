using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ask.Sdk.Asp.Net.Core.Configuration;
using Ask.Sdk.Asp.Net.Core.Configuration.DependencyInjection;
using Ask.Sdk.Asp.Net.Core.Configuration.DependencyInjection.Extensions;
using HelloWorldWeb.Handlers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace HelloWorldWeb
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAlexaSkill(options =>
            {
                options.SkillId = "<<Your Skill ID goes here>>";
            })
                .AddRequestHandlers(typeof(CancelAndStopIntentHandler),
                    typeof(HelloWorldIntentHandler),
                    typeof(HelpIntentHandler),
                    typeof(LaunchRequestHandler),
                    typeof(SessionEndedRequestHandler),
                    typeof(FallbackIntentHandler));

            services.AddControllers().AddNewtonsoftJson();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseHttpsRedirection();

            app.UseAlexaSkill(env.IsDevelopment());

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}
