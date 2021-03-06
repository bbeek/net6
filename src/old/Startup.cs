namespace Old;

public class Startup
{
    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddSingleton<IAttendeeRepository, AttendeeRepository>();
        services.AddControllers();
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app)
    {
        app.UseHttpsRedirection();

        app.UseRouting();

        app.UseEndpoints(endpoints => endpoints.MapControllers());
    }
}
