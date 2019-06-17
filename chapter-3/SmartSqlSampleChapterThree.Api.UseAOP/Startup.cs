using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AspectCore.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using SmartSqlSampleChapterThree.DomainService;
using Swashbuckle.AspNetCore.Swagger;

namespace SmartSqlSampleChapterThree.Api.UseAOP
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            services.AddLogging(logging =>
            {
                logging.SetMinimumLevel(LogLevel.Trace);
                logging.AddConsole();
            });

            // register smartsql
            services.AddSmartSql().AddRepositoryFromAssembly(options =>
            {
                // 仓储接口所在的程序集全称
                options.AssemblyString = "SmartSqlSampleChapterThree.Repository";
            });

            // register domain service
            services.AddSingleton<IUserDomainService, UseAopUserDomainService>();

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

            return services.BuildAspectInjectorProvider();
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