using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Swashbuckle.AspNetCore.Swagger;

namespace SmartSqlSampleChapterTwo.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            services.AddLogging(logging =>
            {
                logging.SetMinimumLevel(LogLevel.Trace);
                logging.AddConsole();
            });

            // register smartsql
            services.AddSmartSql(builder =>
            {
                builder.UseAlias("SmartSqlSampleChapterTwo");       // 定义实例别名，在多库场景下适用。
                //.UseXmlConfig(ResourceType.File,"MyConfig.xml");
            }).AddRepositoryFromAssembly(options =>
            {
                // SmartSql实例的别名
                options.SmartSqlAlias = "SmartSqlSampleChapterTwo";
                // 仓储接口所在的程序集全称
                options.AssemblyString = "SmartSqlSampleChapterTwo.Repository";
                // 筛选器，根据接口的Type筛选需要的仓储
                options.Filter = type => type.FullName.Contains("Sample");
                // Scope模板，默认是"I{Scope}Repository"
                options.ScopeTemplate = "I{Scope}Repository";
            });


            // register swagger
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("SmartSqlSampleChapterTwo", new Info
                {
                    Title = "SmartSqlSample.ChapterTwo.Api",
                    Version = "v1",
                    Description = "SmartSqlSample.ChapterTwo.Api"
                });
                string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "SmartSqlSampleChapterTwo.Api.xml");
                if (File.Exists(filePath)) c.IncludeXmlComments(filePath);
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment()) app.UseDeveloperExceptionPage();
            app.UseMvc();

            app.UseSwagger(c => { });
            app.UseSwaggerUI(c => { c.SwaggerEndpoint("/swagger/SmartSqlSampleChapterTwo/swagger.json", "SmartSqlSampleChapterTwo"); });
        }
    }
}
