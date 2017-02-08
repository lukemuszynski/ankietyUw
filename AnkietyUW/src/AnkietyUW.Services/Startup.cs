using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AnkietyUW.DataLayer.DbContext;
using AnkietyUW.DataLayer.Repository;
using AnkietyUW.DataLayer.Repository.AnswerRepository;
using AnkietyUW.DataLayer.Repository.SecretRepository;
using AnkietyUW.DataLayer.Repository.TestRepository;
using AnkietyUW.DataLayer.Repository.UserRepository;
using AnkietyUW.DataLayer.UnitOfWork;
using AnkietyUW.Utilities;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace AnkietyUW.Services
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddUserSecrets()
                .AddEnvironmentVariables();

            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            var connection = Configuration["connectionString"];
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connection));
            services.AddAutoMapper();
            services.AddScoped<IJwtUtility, JwtUtility>();
            services.AddScoped<IQuestionsProvider, QuestionsProvider>();
            services.AddScoped<ISecretRepository, SecretRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IAnswerRepository, AnswerRepository>();
            services.AddScoped<ITestRepository, TestRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddMvc().AddJsonOptions(options => {
                options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            app.UseMvc();
        }
    }
}
