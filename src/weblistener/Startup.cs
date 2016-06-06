using System;
using Autofac;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Autofac.Extensions.DependencyInjection;

namespace weblistener
{
  public class Startup
  {
    // This method gets called by the runtime. Use this method to add services to the container.
    // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=398940
    public IServiceProvider ConfigureServices(IServiceCollection services)
    {

      // Add Autofac
      var containerBuilder = new ContainerBuilder();
      containerBuilder.Populate(services);
      var container = containerBuilder.Build();
      return container.Resolve<IServiceProvider>();
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app)
    {
      app.Run(async (context) =>
      {
        var claimsPrinciple = context.User;
        string name = claimsPrinciple.Identity.Name;
        await context.Response.WriteAsync("Hello World!");
      });
    }
  }
}
