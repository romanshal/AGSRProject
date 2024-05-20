using AGSRProject.Common.Mappings;
using AGSRProject.Extensions;
using AGSRProject.Middlewares;
using Microsoft.Net.Http.Headers;
using System.Data.Common;

var SwaggerDocName = "v1";
var AllowSpecificOrigins = "_allowSpecificOrigins";

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc(SwaggerDocName, new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Title = "AGSR Test project",
        Version = SwaggerDocName,
        Description = "Test project for AGSR Comp. project"
    });
});

builder.Services.AddCors(oprions =>
{
    oprions.AddPolicy(AllowSpecificOrigins,
        builder =>
        {
            builder.AllowAnyOrigin()
            .AllowAnyMethod()
            .WithHeaders(HeaderNames.ContentType, "application/json");
        });
});

var connectionString = builder.Configuration.GetConnectionString("dbConnection");
builder.Services.ConfigureDataAccess(connectionString)
    .ConfigureBusinessLogic()
    .ConfigureCommon();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint($"./{SwaggerDocName}/swagger.json", "AGSR project");
    });
}

app.UseCors(AllowSpecificOrigins);

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

app.UseExeptionWrappingMiddleware();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();
