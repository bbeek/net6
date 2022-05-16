using NBomber.Contracts;
using NBomber.CSharp;
using NBomber.Plugins.Http.CSharp;

var httpFactory = HttpClientFactory.Create();

var oldStyleApiStep = Step.Create("old_style_api_step", httpFactory, async context =>
{
    var url = "https://localhost:5001/attendees/e0eede48-f8d7-493f-bbd5-ed9e00212d6d";
    var response = await context.Client.GetAsync(url);

    return response.IsSuccessStatusCode
        ? Response.Ok(statusCode: (int)response.StatusCode)
        : Response.Fail(statusCode: (int)response.StatusCode);
});

var minimalStyleApiStep = Step.Create("minimal_api_step", httpFactory, async context =>
{
    var url = "https://localhost:7074/attendees/1397aa6c-4995-410f-8035-56d6f59c90d1";
    var response = await context.Client.GetAsync(url);

    return response.IsSuccessStatusCode
        ? Response.Ok(statusCode: (int)response.StatusCode)
        : Response.Fail(statusCode: (int)response.StatusCode);
});

var oldStyleApiScenario = ScenarioBuilder
    .CreateScenario("old_style_api", oldStyleApiStep)
    .WithWarmUpDuration(TimeSpan.FromSeconds(5))
    .WithLoadSimulations(Simulation.KeepConstant(24, TimeSpan.FromSeconds(60)));

var minimalApiScenario = ScenarioBuilder
    .CreateScenario("minimal_api", minimalStyleApiStep)
    .WithWarmUpDuration(TimeSpan.FromSeconds(5))
    .WithLoadSimulations(Simulation.KeepConstant(24, TimeSpan.FromSeconds(60)));

NBomberRunner
    .RegisterScenarios(oldStyleApiScenario, minimalApiScenario)
    .Run();