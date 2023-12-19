using ConsoleToWebAPI.Repository;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace ConsoleToWebAPI
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddTransient<CustomMiddleware>();



            services.TryAddSingleton<IProductRepository, ProductRepository>();
            services.TryAddTransient<IProductRepository, TestRepository>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //app.Run(async context =>
            //{
            //    await context.Response.WriteAsync("Hello from Run");
            //});

            //app.Use(async (context, next) =>
            //{
            //    await context.Response.WriteAsync("Hello from Use1-1 \n");

            //    await next();

            //    await context.Response.WriteAsync("Hello from Use1-2 \n");
            //});

            //app.UseMiddleware<CustomMiddleware>();

            //app.Map("/nitish", CustomCode);

            //app.Use(async (context, next) =>
            //{
            //    await context.Response.WriteAsync("Hello from Use2-1 \n");

            //    await next();

            //    await context.Response.WriteAsync("Hello from Use2-2 \n");
            //});

            //app.Run(async context =>
            //{
            //    await context.Response.WriteAsync("Request Complete \n");
            //});

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            //app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();                                     //new after commenting below
                //endpoints.MapGet("/", async context =>
                //{
                //    await context.Response.WriteAsync("Hello from new Web API app.");
                //});

                //endpoints.MapGet("/startupEndPoint", async context =>
                //{
                //    await context.Response.WriteAsync("Hello from new Web API app.");
                //});
            });
        }

        private void CustomCode(IApplicationBuilder app)
        {
            app.Use(async (context, next) =>
            {
                await context.Response.WriteAsync("Hello from nitish \n");
                
                await next();
            });

            app.Run(async context =>
            {
                await context.Response.WriteAsync("Request Complete CustomCode \n");
            });
        }
    }
}