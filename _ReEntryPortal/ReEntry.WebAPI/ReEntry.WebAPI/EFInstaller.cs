using Microsoft.EntityFrameworkCore;
using ReEntry.WebAPI.DataAccess;
using ReEntry.WebAPI.Domain;

namespace ReEntry.WebAPI
{
    public static class EFInstaller
    {
        public static IServiceCollection AddEF(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<InsuranceDbContext>(opts =>
            {
                // получаем строку подключения из файла конфигурации
                string connection = configuration.GetConnectionString("DefaultConnection");
                //@"Server=(localdb)\mssqllocaldb;Database=NoCqrsDB;User Id=sa;Password=admin"
                opts.UseSqlServer(connection);
            });
            services.AddScoped<IDataStore, EFDataStore>();
            return services;
        }
    }
}