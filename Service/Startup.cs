using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Messages.Commands;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NServiceBus;


namespace Service
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
            var endpointConfiguration = new EndpointConfiguration("Trailers.App");
            var transport = endpointConfiguration.UseTransport<LearningTransport>();
            endpointConfiguration.SendOnly();

            var routing = transport.Routing();
            routing.RouteToEndpoint(typeof(RegisterKeeperCommand), "Trailers.Domain");

            services.AddNServiceBus(endpointConfiguration);

            services.AddControllers();
            services.AddScoped<ICommandDespatcher, NServiceBusDespatcher>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
