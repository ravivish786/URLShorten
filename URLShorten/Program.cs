
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.EntityFrameworkCore;
using URLShorten.Database;
using URLShorten.Interface;
using URLShorten.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddControllers();
builder.Services.AddLogging();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configure EF Core In-Memory Database
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseInMemoryDatabase("UrlShortenerDb"));

builder.Services.AddScoped<IUrlManager, UrlManagerService>();

// Register custom services


var app = builder.Build();

// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();
app.MapControllers();

app.UseForwardedHeaders(new ForwardedHeadersOptions
{
    ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
});

//// Other middleware registrations
//app.UseRouting();
//app.UseEndpoints(endpoints =>
//{
//    _ = app.UseAuthorization();
//    endpoints.MapControllers();
//});

app.Run();
