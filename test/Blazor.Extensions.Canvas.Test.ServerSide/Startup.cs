using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Blazor.Extensions.Canvas.Test.ServerSide.Components;

namespace Blazor.Extensions.Canvas.Test.ServerSide
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc()
                .AddNewtonsoftJson();

            services.AddRazorComponents();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();

            app.UseRouting(routes =>
            {
                routes.MapRazorPages();
                routes.MapComponentHub<App>("app");
            });
        }
    }
}
