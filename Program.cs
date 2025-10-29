using GerenciadorBiblioteca.Context;
using GerenciadorBiblioteca.Repository;
using GerenciadorBiblioteca.Services;
using Microsoft.EntityFrameworkCore;
using Serilog;
using Serilog.Sinks.MSSqlServer;
using System.Collections.ObjectModel;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// Configuração do Serilog
Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Information()
    .Enrich.FromLogContext()
    .WriteTo.Console()
    .WriteTo.MSSqlServer(
        connectionString: connectionString,
        sinkOptions: new MSSqlServerSinkOptions
        {
            TableName = "LogsApi",
            AutoCreateSqlTable = true // Cria a tabela automaticamente se não existir
        },
        restrictedToMinimumLevel: Serilog.Events.LogEventLevel.Information,
        columnOptions: GetSqlColumnOptions()
    )
    .CreateLogger();

builder.Host.UseSerilog();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<ILivroService, LivroService>();
builder.Services.AddScoped<IUsuarioService, UsuarioService>();
builder.Services.AddScoped<IEmprestimoService, EmprestimoService>();
builder.Services.AddScoped<ILivroRepository, LivroRepository>();
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
builder.Services.AddScoped<IEmprestimoRepository, EmprestimoRepository>();
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
app.UseMiddleware<RequestLoggingMiddleware>();


app.Run();
ColumnOptions GetSqlColumnOptions()
{
    var columnOptions = new ColumnOptions
    {
        Store = new Collection<StandardColumn>
        {
            StandardColumn.Id,
            StandardColumn.Message,
            StandardColumn.MessageTemplate,
            StandardColumn.Level,
            StandardColumn.TimeStamp,
            StandardColumn.Exception,
            StandardColumn.Properties
        }
    };

    columnOptions.TimeStamp.ColumnName = "DataLog";
    columnOptions.Level.ColumnName = "Nivel";

    return columnOptions;
}