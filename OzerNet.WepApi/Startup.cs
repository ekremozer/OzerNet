using Autofac;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using OzerNet.WepApi.Infrastructure;
using Microsoft.Extensions.Configuration;
using Autofac.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using OzerNet.Dal.EntityFrameWork;
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using OzerNet.Bll.Abstract.Common;
using OzerNet.Bll.Abstract.Users;
using OzerNet.Bll.Concrete.Common;
using OzerNet.Bll.Concrete.Users;
using OzerNet.Entities.Users;
using OzerNet.Service.Abstract.Common;
using OzerNet.Service.Abstract.Users;
using OzerNet.Service.Concrete.Common;
using OzerNet.Service.Concrete.Users;

namespace OzerNet.WepApi
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
            services.AddOptions().Configure<AppSettings>(Configuration);
            var options = services.BuildServiceProvider().GetService<IOptions<AppSettings>>().Value;
            services.AddTransient<IContextFactory>(x => new TheContextFactory(options.ConnectionStrings.Dev));
            services.AddControllers();
            services.AddMemoryCache();

            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IUserManager, UserManager>();
            services.AddScoped<ICommonManager, CommonManager>();
            services.AddScoped<ICommonService, CommonService>();

            var builder = new ContainerBuilder();
            builder.Populate(services);
            builder.RegisterModule<DefaultModule>();
            var container = builder.Build();
            IOC.Container = container;
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IServiceProvider serviceProvider, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}
