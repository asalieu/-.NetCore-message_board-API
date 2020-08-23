using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using message_board.Models;
using Microsoft.OpenApi.Models;

namespace message_board
{
    public class Startup
    {
       // private const string RoutePrfix = "swagger";

       // private const string SwaggerEndpoint = "/swagger/v1/swagger.json";

        private const string SwaggerTitle = "Message Board Api";
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc(name: "v1", new OpenApiInfo { Title = "Message Board Api", Version = "v1" });
            });
            services.AddDbContext<TodoContext>(opt =>
               opt.UseInMemoryDatabase("TodoList"));
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseStaticFiles();
            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                //new settings    


               // c.RoutePrefix = "v1";
               // var basePath = string.IsNullOrWhiteSpace(c.RoutePrefix) ? "." : "..";
               // c.SwaggerEndpoint($"{basePath}/swagger/{c.RoutePrefix}/swagger.json", SwaggerTitle);

                // c.SwaggerEndpoint($"{SwaggerEndpoint}", SwaggerTitle);

                // original settings
                c.SwaggerEndpoint(url: "/swagger/v1/swagger.json", name: "Message Board Api");
            });
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
