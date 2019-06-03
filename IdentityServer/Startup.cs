using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace IdentityServer
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            //Configuracion para Implicit IdentityServer. Activacion del MVC
            services.AddMvc();

            // IdentitytServer configuration
            services.ConfigureIdentityServerInMemory();


            services.AddAuthentication("Bearer")
               .AddIdentityServerAuthentication(options =>
               {
                   options.Authority = "http://localhost:5000";
                   options.RequireHttpsMetadata = false;
                   options.ApiName = "ApiResource";
               });


            services.AddCors(options =>
            {
                options.AddPolicy("AllowSpecificOrigin",
                    builder => builder.AllowAnyHeader()
                 .AllowAnyMethod()
                 .AllowAnyOrigin()
                 .AllowCredentials());
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            //app.UseCors("AllowSpecificOrigin");
            // Activacion del identity server
            app.UseIdentityServer();
            app.UseAuthentication();
            // Https configuration
            //app.UseHttpsRedirection();
            // Activacion  del MVC para trabajar con Identity server configuracion Implicita
            app.UseStaticFiles();
            app.UseMvcWithDefaultRoute();
        }
    }
    public static class CustomExtensionMethods
    {
        public static IServiceCollection ConfigureIdentityServerInMemory(this IServiceCollection services)
        {
            services.AddIdentityServer()
                .AddDeveloperSigningCredential()
                .AddInMemoryIdentityResources(Config.GetIdentityResources()) // Implicit flow
                .AddInMemoryApiResources(Config.GetAllApiResources())
                .AddInMemoryClients(Config.GetClients())
                .AddTestUsers(Config.GetUsers()); //ResourceOwner flow, Implicit flow
            return services;
        }      
    }
}
