using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SicWEB.Data;
using System;

namespace SicWEB
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

      var connectionString = "Server=192.168.0.26;Database=sicweb;Uid=root;Pwd=15031989";
      var serverVersion = ServerVersion.AutoDetect(connectionString);
      services.AddDbContext<ApplicationDbContext>(options =>
          options.UseMySql(connectionString, serverVersion).
          EnableSensitiveDataLogging().
          EnableDetailedErrors());
      services.AddDatabaseDeveloperPageExceptionFilter();

      services.AddIdentity<IdentityUser, IdentityRole>(options => options.SignIn.RequireConfirmedAccount = false)
              .AddDefaultUI()
              .AddDefaultTokenProviders()
              .AddEntityFrameworkStores<ApplicationDbContext>();
      services.AddControllersWithViews();
      services.AddRazorPages();

      services.Configure<IdentityOptions>(options =>
      {
        // Default Password settings.
        options.Password.RequireDigit = true;
        options.Password.RequireLowercase = false;
        options.Password.RequireNonAlphanumeric = false;
        options.Password.RequireUppercase = false;
        options.Password.RequiredLength = 6;
        options.Password.RequiredUniqueChars = 1;
        options.SignIn.RequireConfirmedEmail = false;
        options.SignIn.RequireConfirmedPhoneNumber = false;
      });

      services.AddAuthorization(options =>
      {
        options.AddPolicy("super",
            builder => builder.RequireRole("Super"));

        options.AddPolicy("admin",
            builder => builder.RequireRole("Super", "Admin"));

        options.AddPolicy("usuario",
            builder => builder.RequireRole("Super", "Admin", "Usuario"));
      });

      services.ConfigureApplicationCookie(options =>
      {
        options.AccessDeniedPath = "/Identity/Account/AccessDenied";
        options.Cookie.Name = "SicWeb";
        options.Cookie.HttpOnly = true;
        options.ExpireTimeSpan = TimeSpan.FromMinutes(10);
        options.LoginPath = "/Identity/Account/Login";
        options.ReturnUrlParameter = CookieAuthenticationDefaults.ReturnUrlParameter;
        options.SlidingExpiration = true;
      });

    }


    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
        app.UseMigrationsEndPoint();
        app.UseCookiePolicy();
      }
      else
      {
        app.UseExceptionHandler("/Home/Error");
        // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
        app.UseHsts();
      }

      app.UseStatusCodePagesWithRedirects("/Home");
      app.UseHttpsRedirection();
      app.UseStaticFiles();

      app.UseRouting();

      app.UseAuthentication();
      app.UseAuthorization();
      app.UseCookiePolicy();

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
