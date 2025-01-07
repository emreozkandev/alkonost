using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Hangfire;
using Hangfire.SqlServer;
using Alkonost.Core.Constants;
using Alkonost.Service.Jobs;
using Alkonost.Data;
using Alkonost.Core.Identity;

namespace Alkonost.Web
{
  public class Startup
  {
    public IConfiguration Configuration { get; }

    public Startup(IConfiguration configuration)
    {
      Configuration = configuration;
    }

    public void ConfigureServices(IServiceCollection services)
    {
      // Mevcut servis konfigürasyonları
      services.AddHangfire(config => config
          .SetDataCompatibilityLevel(CompatibilityLevel.Version_170)
          .UseSimpleAssemblyNameTypeSerializer()
          .UseRecommendedSerializerSettings()
          .UseSqlServerStorage(Configuration.GetConnectionString("DefaultConnection")));

      services.AddHangfireServer();

      services.AddIdentity<ApplicationUser, IdentityRole>(options =>
      {
        options.Password.RequiredLength = 8;
        options.Password.RequireNonAlphanumeric = true;
        options.Password.RequireUppercase = true;
        options.SignIn.RequireConfirmedEmail = true;
      })
      .AddEntityFrameworkStores<AlkonostDbContext>()
      .AddDefaultTokenProviders();

      services.AddAuthorization(options =>
      {
        options.AddPolicy("RequireAdminRole", policy =>
                  policy.RequireRole(UserRoles.Admin));

        options.AddPolicy("RequireAdminITRole", policy =>
                  policy.RequireRole(UserRoles.AdminIT));

        options.AddPolicy("RequireAuthorizedRole", policy =>
                  policy.RequireRole(UserRoles.Authorized));
      });
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IRecurringJobManager recurringJobManager)
    {
      // Mevcut middleware'ler ve job konfigürasyonları aynı kalacak
    }
  }
}