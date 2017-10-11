using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Text.RegularExpressions;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace ASPCore2
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
            services.AddMvc()
                .AddRazorPagesOptions((opts) =>
                {
                    //opts.Conventions.AddFolderRouteModelConvention("/", model =>
                    //{
                    //    foreach (var selector in model.Selectors)
                    //    {
                    //        var attributeRouteModel = selector.AttributeRouteModel;
                    //        attributeRouteModel.Template = ToKebabCase(attributeRouteModel.Template);
                    //    }
                    //});

                    //opts.Conventions.AddPageRoute("/HelloWorld", "hello-world");
                });

            services.AddSingleton<IHostedService, SampleHostedService>();
            services.AddSingleton<ITagHelperComponent, SampleTagHelperComponent>();
        }

        private string ToKebabCase(string s)
        {
            return Regex.Replace(
                s,
                "([a-z])([A-Z])",
                "$1-$2",
                RegexOptions.Compiled)
                .ToLower();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
