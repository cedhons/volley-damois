using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using VolleyDamois.DataConfiguration;
using VolleyDamois.Models;
using VolleyDamois.Models.Interfaces;
using VolleyDamois.Models.Repository;
using VolleyDamois.Models.Repository.Interfaces;

namespace VolleyDamois
{
    public class Startup
    {
        public Startup(IWebHostEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();

            Configuration = builder.Build();
        }

        public IConfiguration Configuration { get; }


        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.AddRazorPages();
            services.AddDbContext<VolleyDbContext>(options => options.UseLazyLoadingProxies().UseSqlServer(Configuration.GetConnectionString("default")));

            services.AddIdentity<IdentityUser, IdentityRole>().AddDefaultUI().AddEntityFrameworkStores<VolleyDbContext>();

            services.AddScoped<ITeamRepository, TeamRepository>();
            services.AddScoped<IPoolCreator, PoolCreator>();
            services.AddScoped<IPoolRepository, PoolRepository>();
            services.AddScoped<IConfrontationRepository, ConfrontationRepository>();
            services.AddScoped<ICRUDRepository<Category>, CRUDRepository<Category>>();

            services.AddScoped<IRoundDateTimes, RoundDateTimes>();
            services.AddScoped<IPoolBasedConfrontationCreator, PoolConfrontationCreator>();
            services.AddScoped<IPoolBasedConfrontationCreator, EliminationPoolConfrontationCreator>();
            services.AddScoped<IEliminationConfrontationCreator, EliminationConfrontationCreator>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            DataInitializer.SeedDefaultUsers(userManager, roleManager).Wait();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
        }
    }
}
