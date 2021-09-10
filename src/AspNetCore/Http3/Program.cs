using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.OpenApi.Models;
using System.Net;

var builder = WebApplication.CreateBuilder(args);

builder.WebHost.UseKestrel()
    // Set up Quic options
    .UseQuic(options =>
    {
        options.Alpn = "h3-29";
        options.IdleTimeout = TimeSpan.FromMinutes(1);
    })
    .ConfigureKestrel((context, options) =>
    {
        options.EnableAltSvc = true;
        options.Listen(IPAddress.Any, 5001, listenOptions =>
        {
            // Use Http3
            listenOptions.Protocols = HttpProtocols.Http1AndHttp2AndHttp3;
            listenOptions.UseHttps();
        });
    });
// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new() { Title = "Http3", Version = "v1" });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (builder.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Http3 v1"));
}

app.UseAuthorization();

app.MapControllers();

await app.RunAsync();
