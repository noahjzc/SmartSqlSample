using System;
using System.IO;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using SmartSqlSampleChapterThree.DomainService;
using Swashbuckle.AspNetCore.Swagger;

namespace SmartSqlSampleChapterThree.Api
{
    public class Startup
    {
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
                builder.UseAlias("SmartSqlSampleChapterThree"); // 定义实例别名，在多库场景下适用。
            }).AddRepositoryFromAssembly(options =>
            {
                // SmartSql实例的别名
                options.SmartSqlAlias = "SmartSqlSampleChapterThree";
                // 仓储接口所在的程序集全称
                options.AssemblyString = "SmartSqlSampleChapterThree.Repository";
            });

            // register domain service
            services.AddSingleton<IUserDomainService, NormalUserDomainService>();

            // register swagger
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("SmartSqlSampleChapterThree", new Info
                {
                    Title = "SmartSqlSampleChapterThree",
                    Version = "v1",
                    Description = "SmartSqlSampleChapterThree"
                });
                var filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "SmartSqlSampleChapterThree.Api.xml");
                if (File.Exists(filePath)) c.IncludeXmlComments(filePath);
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment()) app.UseDeveloperExceptionPage();
            app.UseMvc();

            app.UseSwagger(c => { });
            app.UseSwaggerUI(c => { c.SwaggerEndpoint("/swagger/SmartSqlSampleChapterThree/swagger.json", "SmartSqlSampleChapterThree"); });
        }
    }
}