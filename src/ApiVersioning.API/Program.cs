using ApiVersioning.API.Constants;
using ApiVersioning.API.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddDependencyInjection();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwaggerDependencyInjection();
}

app.UseCors(CorsPoliciesNamesConstants.CorsPolicy);
app.UseRouting();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
