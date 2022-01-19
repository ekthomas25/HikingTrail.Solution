using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System;
using System.Reflection;
using System.IO;
using HikingTrail.Models;

namespace HikingTrail
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
      services.AddDbContext<HikingTrailContext>(opt =>
        opt.UseMySql(Configuration["ConnectionStrings:DefaultConnection"], ServerVersion.AutoDetect(Configuration["ConnectionStrings:DefaultConnection"])));
      services.AddControllers();

      services.AddSwaggerGen(c => {
        c.SwaggerDoc("v1", new OpenApiInfo{
          Version = "v1",
          Title = "Hiking Trails API",
          Description = "60 hikes within 100 miles of Portland",
          Contact = new OpenApiContact
          {
            Name = "Katie Pundt, Liz Thomas, and Kim Brannian",
            Email = string.Empty,
            Url = new Uri("https://github.com/kpundt93")
          },
          License = new OpenApiLicense
          {
            Name = "Use under MIT",
            Url = new Uri("https://opensource.org/licenses/MIT")
          }
        });
      });
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
      }
      app.UseSwagger();
      app.UseSwaggerUI(c =>
      {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Hiking Trails API V1");
        c.RoutePrefix = string.Empty;
      });

      // app.UseHttpsRedirection();

      app.UseRouting();

      app.UseAuthorization();

      app.UseEndpoints(endpoints =>
      {
        endpoints.MapControllers();
      });
    }
  }
}
