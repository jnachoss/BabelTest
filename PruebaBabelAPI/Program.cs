using subastaAPI.App_Start;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

DependencyInjectionConfig.AddScope(builder.Services);

builder.Services.AddControllers();

builder.Services.AddCors(p => p.AddPolicy("PruebaBabelAPI", builder =>
{
    builder.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
}));

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
