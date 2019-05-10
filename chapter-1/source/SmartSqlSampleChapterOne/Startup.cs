using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Swashbuckle.AspNetCore.Swagger;
using System;
using System.IO;
using SmartSqlSampleChapterOne.DataAccess;

namespace SmartSqlSampleChapterOne
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
            services.AddSmartSql(builder => { builder.UseAlias("SmartSqlSampleChapterOne"); });

            // register data access
            services.AddSingleton<ArticleDataAccess>();

            // register swagger
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("SmartSqlSampleChapterOne", new Info
                {
                    Title = "SmartSqlSample.ChapterOne",
                    Version = "v1",
                    Description = "SmartSqlSample.ChapterOne"
                });
                var filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "SmartSqlSampleChapterOne.xml");
                if (File.Exists(filePath)) c.IncludeXmlComments(filePath);
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment()) app.UseDeveloperExceptionPage();
            app.UseMvc();

            app.UseSwagger(c => { });
            app.UseSwaggerUI(c => { c.SwaggerEndpoint("/swagger/SmartSqlSampleChapterOne/swagger.json", "SmartSqlSampleChapterOne"); });
        }
    }
}
