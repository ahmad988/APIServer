using APIServer.Model.Plugins.DataStore.SQL;
using APIServer.Model.Plugins.DataStore.User.SQL;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//My Services
var connectionString = builder.Configuration.GetConnectionString("DBConnection");
var connectionStringForUser = builder.Configuration.GetConnectionString("DBConnectionUser");
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString));
builder.Services.AddDbContext<UserDbContext>(option => option.UseSqlServer(connectionStringForUser));
// Add-Migration ExternalClientData -Context ExternalClientContext
//Update-Database -Context ExternalClientContext



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
