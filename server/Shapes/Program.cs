using IShapesClb;
using ShapesClb;
using System.Net;

Dictionary<string, string> config = Helpers.GetObject<Dictionary<string, string>>(File.ReadAllText(AppDomain.CurrentDomain.BaseDirectory + @"\config.json"));
var builder = WebApplication.CreateBuilder(args);
builder.WebHost.ConfigureKestrel((context, serverOptions) =>
{
    serverOptions.Listen(IPAddress.Loopback, System.Convert.ToInt32(config["http"]));
    serverOptions.Listen(IPAddress.Loopback, System.Convert.ToInt32(config["https"]), listenOptions =>
    {
        //  listenOptions.UseHttps("testCert.pfx", "testPassword");
        listenOptions.UseHttps();
    });
});

// Add services to the container.
var ShapeOrigins = "_ShapeOrigins";

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: ShapeOrigins,
                      policy =>
                      {
                          policy.WithOrigins("http://localhost:4200").WithHeaders("Content-Type", "command").WithMethods("POST", "DELETE", "GET");
                      });
});

builder.Services.AddControllers();

builder.Services.AddTransient<IComputeShape, ComputeShape>();

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}
app.UseCors(ShapeOrigins);
app.UseHttpsRedirection();

app.UseAuthorization();
app.UseDefaultFiles();
app.UseStaticFiles();
app.MapControllers();

app.Run();
