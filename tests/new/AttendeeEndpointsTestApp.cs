using System;

using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace NewStyle;

// WebApplicationFactory provides inmemory api (not exposed to web). However, complete pipeline
internal class AttendeeEndpointsTestApp : WebApplicationFactory<Program> 
{
    private readonly Action<IServiceCollection> _services;

    public AttendeeEndpointsTestApp(Action<IServiceCollection> services)
    { 
        _services = services;
    }

    protected override IHost CreateHost(IHostBuilder builder)
    {
        builder.ConfigureServices(_services);

        return base.CreateHost(builder);
    }
}