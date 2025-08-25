using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ApiAppEtec.Data;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<ApiAppEtecContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ApiAppEtecContext") ?? throw new InvalidOperationException("Connection string 'ApiAppEtecContext' not found.")));

// Add services to the container.







builder.Services.AddCors(option =>
{
    option.AddPolicy("PolicyApiEtec", olifrans =>
    {
        olifrans.AllowAnyMethod();
        olifrans.AllowAnyHeader();
        olifrans.AllowAnyOrigin();

    });
}
);



builder.Services.AddControllers();


var app = builder.Build();


// Configure the HTTP request pipeline.

app.UseCors("PolicyApiEtec");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
