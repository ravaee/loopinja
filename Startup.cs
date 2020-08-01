using System;
using loppinja.BLL;
using loppinja.Common.DAL;
using loppinja.Common.Interfaces.Business;
using loppinja.Common.Interfaces.Service;
using loppinja.Common.Models.Domains;
using loppinja.DAL.UnitOfWork;
using loppinja.Models.Context;
using loppinja.Models.Domains;
using loppinja.Models.Utilities;
using loppinja.Services;
using loppinja.Services.ArticleServices;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;


namespace loppinja
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();

            services.Configure<RazorViewEngineOptions>(o =>
            {
                o.ViewLocationFormats.Clear();
                o.ViewLocationFormats.Add
                ("/PL/Views/{1}/{0}" + RazorViewEngine.ViewExtension);
                        o.ViewLocationFormats.Add
                ("/PL/Views/Shared/{0}" + RazorViewEngine.ViewExtension);
            });

            services.AddRazorPages().AddRazorRuntimeCompilation();

            services.ConfigureApplicationCookie(option => option.LoginPath = "/Account/Login");

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            
            services.AddIdentity<ApplicationUser, IdentityRole>(options =>
            {
                options.User.RequireUniqueEmail = false;
            })
            .AddEntityFrameworkStores<ApplicationDbContext>()
            .AddDefaultTokenProviders()
            .AddErrorDescriber<CustomIdentityErrorDescriber>()
            .AddSignInManager<SignInManager<ApplicationUser>>();

            services.Configure<IdentityOptions>(options =>
            {
                // Password settings.
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireNonAlphanumeric = true;
                options.Password.RequireUppercase = true;
                options.Password.RequiredLength = 6;
                options.Password.RequiredUniqueChars = 1;

                // Lockout settings.
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
                options.Lockout.MaxFailedAccessAttempts = 5;
                options.Lockout.AllowedForNewUsers = true;

                // User settings.
                options.User.AllowedUserNameCharacters =
                "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
                options.User.RequireUniqueEmail = true;
            });

            services.Configure<EmailSettings>(Configuration.GetSection("EmailSettings"));
            services.AddSingleton<IEmailSender, EmailSender>();
            //services.AddTransient<ServiceProvider>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient<ApplicationDbContext>();

            //business logic resolving
            services.AddTransient<IArticleBusinessLogic, ArticleBusinessLogic>();
            services.AddTransient(typeof(IBaseBusinessLogic<>) , typeof(BaseBusinessLogic<>));

            //service resoliving
            services.AddTransient<IArticleService, ArticleService>();

            services.AddRazorPages();
        
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();      
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }

    }
}
