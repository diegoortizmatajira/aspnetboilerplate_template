using Abp;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace WebApiTemplate.EntityFrameworkCore
{
    public static class DbContextOptionsConfigurer
    {

        private static void ConfigureProvider(DbContextOptionsBuilder<MainDbContext> dbContextOptions, string provider, string connectionString)
        {
            switch (provider.ToUpper())
            {
                case "POSTGRESQL":
                    dbContextOptions.UseNpgsql(connectionString);
                    break;
                case "SQLSERVER":
                    dbContextOptions.UseSqlServer(connectionString);
                    break;
                default:
                    throw new AbpInitializationException("Debe especificar un proveedor de base de datos (POSTGRESQL o SQLSERVER)");
            }
        }

        public static void ConfigureMainDbContext(
           DbContextOptionsBuilder<MainDbContext> dbContextOptions,
           IConfigurationRoot config
           )
        {
            var Provider = config.GetConnectionString(SolutionConsts.MainDatabaseConnectionProviderName);
            var ConnectionString = config.GetConnectionString(SolutionConsts.MainDatabaseConnectionStringName);
            ConfigureProvider(dbContextOptions, Provider, ConnectionString);
        }
    }
}