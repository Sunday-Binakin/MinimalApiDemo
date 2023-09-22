using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using MinimalApiDemo.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//setting connection string ie linking the string in the appsettings.json or appsettings.development.json
var sqlConnectionBuilder = new SqlConnectionStringBuilder();
sqlConnectionBuilder.ConnectionString = builder.Configuration.GetConnectionString("SQLDbConnection");
//register dbcontext builder
builder.Services.AddDbContext<AppDbContext>(opt => opt.UseSqlServer(sqlConnectionBuilder.ConnectionString));
//register our interface and concrete class ie the repositories (ICommandRepo and CommandRepo)
builder.Services.AddScoped<ICommandRepo,CommandRepo>();
//registrying automapper used in profiles
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.Run();
