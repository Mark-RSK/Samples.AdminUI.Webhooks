using DuendeWebHooksClient.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.ConfigureServices()
    .ConfigureAuth();

var app = builder.Build();

app.ConfigurePipeline();

app.Run();
