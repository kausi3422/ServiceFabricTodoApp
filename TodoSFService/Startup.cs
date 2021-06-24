using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoSFService.Data;
using TodoSFService.Interface;
using TodoSFService.Model;
using TodoSFService.Repository;
using TodoSFService.Service;

namespace TodoSFService
{
	public class Startup
	{

		public IConfiguration Configuration { set; get; } 

		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			string connectionString = Configuration.GetConnectionString("ConnectionStrings:DefaultConnection");
			services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer("Server=.\\SQLEXPRESS;Database=TodoDb;Integrated Security=True")); //For now i have TodoDb already created
			services.AddControllers();
			services.AddHttpClient();
			services.AddTransient<IRepository<Item>, RepositoryItem>();
			services.AddTransient<TodoService, TodoService>();
			services.AddControllers();
			services.AddSwaggerGen(c =>
			{
				c.SwaggerDoc("v1", new OpenApiInfo { Title = "TodoSFService", Version = "v1" });
			});
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
				app.UseSwagger();
				app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "TodoSFService v1"));
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
