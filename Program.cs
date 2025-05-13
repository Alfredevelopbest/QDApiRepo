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
            policy.WithOrigins("http://localhost:5500","https://alfredevelopbest.github.io")
            .AllowAnyHeader()
            .AllowAnyMethod()
            .AllowAnyOrigin();
        });
});

var app = builder.Build();

app.UseHttpsRedirection();

app.UseCors(FrontConnection);

app.UseRouting();

app.UseAuthorization();

startup.Configure(app, app.Environment);

app.Run();
