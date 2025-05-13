using QD_API;

var builder = WebApplication.CreateBuilder(args); 

builder.Configuration.AddEnvironmentVariables();

var connectionString = Environment.GetEnvironmentVariable("DefaultConnection");

builder.Configuration["ConnectionStrings:DefaultConnection"] = connectionString;

var startup = new StartUp(builder.Configuration);

startup.ConfigureServices(builder.Services);

var FrontConnection = "_frontconnection";

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: FrontConnection,
        policy =>
        {
            policy.WithOrigins("http://localhost:5500")
            .AllowAnyHeader()
            .AllowAnyMethod()
            .AllowAnyOrigin();
        });
});

var app = builder.Build();

app.UseCors(FrontConnection);

startup.Configure(app, app.Environment);

app.Run(); 
