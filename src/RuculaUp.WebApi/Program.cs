using RuculaUp.Application;
using RuculaUp.Application.Command;
using RuculaUp.Dapper;
using RuculaUp.EntityFramework;
using RuculaUp.EntityFramework.Query;
using RuculaUp.WebApi;
using RuculaX.Database.Query;
using RuculaX.EntityFramework;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
    {
        options.AddPolicy("AllowAll",
            builder =>
            {
                builder.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader();
            });
    });

var environment = builder.Environment.EnvironmentName;
var configuration = builder.Configuration;

var connectionStringPostgres = new ConnectionStringPostgres(environment,configuration).ConnectionString;

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(DapperConnectionString).Assembly));
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(IntegranteCommand).Assembly));

builder.Services.AddPostgressContext(connectionStringPostgres);
builder.Services.AddDapper(connectionStringPostgres);

builder.Services.AddScoped<UnitOfWorkAsync>();
builder.Services.AddScoped<IntegranteRepository>();
builder.Services.AddSingleton<IQueries,RuculaUpQueries>();
builder.Services.AddScoped<FactoryQuery<ApplicationContext>>();

var app = builder.Build();

app.MapControllers();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("AllowAll");

app.Run();
