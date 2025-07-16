using Recipefy.Application;
using Recipefy.Infrastructure;
using Recipefy.Web;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddWebComponents()
    .AddSwaggerGen()
    .AddApplication()
    .AddInfrastructure(builder.Configuration);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseCors("AllowAll");
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();