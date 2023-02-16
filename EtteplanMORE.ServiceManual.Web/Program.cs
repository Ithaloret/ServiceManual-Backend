using EtteplanMORE.ServiceManual.ApplicationCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

namespace MyApp;

public static class Program
{
    public static void Main(string[] args)
    {
        CreateHostBuilder(args).Build().Run();
    }

    public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(webBuilder => webBuilder.UseStartup<Startup>());
}

public class Startup
{
    // Constructor to accept configuration options
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    // Configuration property to access configuration options
    public IConfiguration Configuration { get; }

    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {
        // Add the framework services.
        services.AddMvc();

        // Add Swagger
        services.AddSwaggerGen(options =>
        {
            options.SwaggerDoc("v1", new OpenApiInfo { Title = "Best API ever made", Version = "v1" });
        });

        // Configure database connection
        services.AddDbContext<DevicesDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("Default")));
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }

        // Use Swagger
        app.UseSwagger();
        app.UseSwaggerUI(options => options.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1"));

        app.UseRouting();

        app.UseEndpoints(endpoints => endpoints.MapControllers());
    }
}