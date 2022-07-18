using ISO.Server.Contracts;
using ISO.Server.Models.Dto;
using ISO.Server.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddJsonFile("Assets/Iso.json");
builder.Services.Configure<Iso>(builder.Configuration);
builder.Services.AddRouting(options => options.LowercaseUrls = true);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddScoped<IIso4217, Iso4217Service>();
builder.Services.AddScoped<IIso18245, Iso18245Service>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
