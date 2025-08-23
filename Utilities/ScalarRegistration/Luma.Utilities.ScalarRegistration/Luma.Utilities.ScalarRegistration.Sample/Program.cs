using Luma.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();

builder.Services.AddLumaScalar(builder.Configuration, "Scalar");

var app = builder.Build();


app.UseLumaScalar();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

