using Microsoft.EntityFrameworkCore;
using ReEntry.WebAPI;
using ReEntry.WebAPI.Init;
using Serilog;

try
{
    Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .CreateBootstrapLogger();

    Log.Information("Starting up");

    var builder = WebApplication.CreateBuilder(args);

    // получаем строку подключения из файла конфигурации
    string connection = builder.Configuration.GetConnectionString("DefaultConnection");

    // Add services to the container.

    builder.Services.AddControllers();
    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();

    // добавляем контекст ApplicationContext в качестве сервиса в приложение
    builder.Services.AddEF(builder.Configuration);
    //builder.Services.AddDbContext<InsuranceDbContext>(options => options.UseSqlServer(connection));

    builder.Host.UseSerilog((ctx, lc) => lc
        .WriteTo.Console()
        .ReadFrom.Configuration(ctx.Configuration));

    var app = builder.Build();

    app.UseSerilogRequestLogging();

    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseAuthorization();

    app.MapControllers();

    app.UseDbInitializer();
    // получение данных
    app.MapGet("/", (InsuranceDbContext db) => db.Users.ToList());

    app.MapGet("/Offers", (InsuranceDbContext db) => db.Offers.ToList());

    app.Run();

}
catch (Exception ex)
{
    Log.Fatal(ex, "Unhandled exception");
}
finally
{
    Log.Information("Shut down complete");
    Log.CloseAndFlush();
}