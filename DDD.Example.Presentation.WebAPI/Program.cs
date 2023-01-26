using DDD.Example.Application;
using DDD.Example.Infrastructure;
using DDD.Example.Presentation.WebAPI;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddPresentation(builder.Configuration)
    .AddApplication(builder.Configuration)
    .AddInfrastructure(builder.Configuration);

var app = builder.Build();
app.UseExceptionHandler("/error");
app.SetupSwagger();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();