using Agenda.Infra;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//EF
ConfigurationManager configuration = builder.Configuration; 
builder.Services.AddDbContext<AgendaContext>(opts => opts.UseSqlServer(configuration.GetConnectionString("sqlConnection")));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//services.AddDbContext<AppDbContext>(opts =>
//  opts.UseMySql(Configuration.GetConnectionString("sqlConnection")));

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
