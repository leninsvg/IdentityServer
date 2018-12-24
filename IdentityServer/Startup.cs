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

            // COnfiguracion basica del Identity service
			services.AddIdentityServer()
				.AddDeveloperSigningCredential()
                .AddInMemoryIdentityResources(Config.GetIdentityResources()) // Implicit flow
				.AddInMemoryApiResources(Config.GetAllApiResources())
				.AddInMemoryClients(Config.GetClients())
                .AddTestUsers(Config.GetUsers()); //ResourceOwner flow, Implicit flow
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IHostingEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}
            // Activacion del identity server
			app.UseIdentityServer();
            // Activacion  del MVC para trabajar con Identity server configuracion Implicita
            app.UseStaticFiles();
            app.UseMvcWithDefaultRoute();
		}
	}
}
