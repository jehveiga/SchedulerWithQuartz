using SchedulerWithQuartz.Extensions;
using SchedulerWithQuartz.Services;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<IMockService, MockService>();
builder.AddSerilog();
builder.Services.AddQuartz(builder.Configuration);

WebApplication app = builder.Build();

await app.RunAsync();