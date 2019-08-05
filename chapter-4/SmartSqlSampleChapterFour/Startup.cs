using System;
using System.IO;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Swashbuckle.AspNetCore.Swagger;

namespace SmartSqlSampleChapterFour
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

            // 注册通用库实例
            services.AddSmartSql(setup =>
            {
                setup.UseAlias("Common");
                setup.UseXmlConfig(smartSqlMapConfig: "SmartSqlMapConfig-Common.xml");
            }).AddRepositoryFromAssembly(options =>
            {
                options.AssemblyString = "SmartSqlSampleChapterFour.CommonRepository";
                options.SmartSqlAlias = "Common";
                options.Filter = type => type.FullName.Contains("Common");
            });
            
            // 注册用户库实例
            services.AddSmartSql(setup =>
            {
                setup.UseAlias("User");
                setup.UseXmlConfig(smartSqlMapConfig: "SmartSqlMapConfig-User.xml");
            }).AddRepositoryFromAssembly(options =>
            {
                options.AssemblyString = "SmartSqlSampleChapterFour.CommonRepository";
                options.SmartSqlAlias = "User";
                options.Filter = type => type.FullName.Contains("User");
            });
            
            // 注册商品库实例
            services.AddSmartSql(setup =>
            {
                setup.UseAlias("Product");
                setup.UseXmlConfig(smartSqlMapConfig: "SmartSqlMapConfig-Product.xml");
            }).AddRepositoryFromAssembly(options =>
            {
                options.AssemblyString = "SmartSqlSampleChapterFour.ProductRepository";
                options.SmartSqlAlias = "Product";
            });
            
            // register swagger
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("SmartSqlSampleChapterFour", new Info
                {
                    Title = "SmartSqlSampleChapterFour",
                    Version = "v1",
                    Description = "SmartSqlSampleChapterFour"
                });
                var filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "SmartSqlSampleChapterFour.Api.xml");
                if (File.Exists(filePath)) c.IncludeXmlComments(filePath);
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
            
            app.UseSwagger(c => { });
            app.UseSwaggerUI(c => { c.SwaggerEndpoint("/swagger/SmartSqlSampleChapterFour/swagger.json", "SmartSqlSampleChapterFour"); });
        }
    }
}