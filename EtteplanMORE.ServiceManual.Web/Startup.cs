using EtteplanMORE.ServiceManual.ApplicationCore;
using EtteplanMORE.ServiceManual.ApplicationCore.Interfaces;
using EtteplanMORE.ServiceManual.ApplicationCore.Services;
using Microsoft.EntityFrameworkCore;
namespace EtteplanMORE.ServiceManual.Web;

public class Startup
{
    public IConfiguration Configuration { get; }

    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddControllers();

        // Register services in the container
        services.AddScoped<IFactoryDeviceService, FactoryDeviceService>();
        services.AddScoped<IMaintenanceTask, MaintenanceTaskService>();

        // Add Swagger 
        services.AddSwaggerGen();
        services.AddEndpointsApiExplorer();

        // Configure database connection
        services.AddDbContext<DevicesDbContext>(options =>
        {
            options.UseSqlServer(Configuration.GetConnectionString("Default"));
            options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
        });
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }

        app.UseSwagger();
        app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "v1"));

        app.UseRouting();
        app.UseAuthorization();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
    }
}