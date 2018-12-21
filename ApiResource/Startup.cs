
using ApiResource.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace ApiClient
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
            // Configure the resource identity server
            services.AddAuthentication("Bearer")
                .AddIdentityServerAuthentication(options =>
                {
                    options.Authority = "http://localhost:5000";
                    options.RequireHttpsMetadata = false;
                    options.ApiName = "ApiResource";
                });
            // Configure the context
            // In Memory
			//services.AddDbContext<BankContext>(options => 
			//	options.UseSqlServer(Configuration.GetConnectionString("BankingDbConection")));
            // Data Base
            services.AddDbContext<BankContext>(options =>
                options.UseInMemoryDatabase("BankingDbConection"));
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
		}



		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IHostingEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}
            app.UseAuthentication();
			app.UseMvc();
		}
	}
}
