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
                case "SQLSERVER":
                    dbContextOptions.UseSqlServer(connectionString);
                    break;
                default:
                    dbContextOptions.UseNpgsql(connectionString);
                    break;
            }
        }

        public static void ConfigureMainDbContext(
           DbContextOptionsBuilder<MainDbContext> dbContextOptions,
           string provider,
           string connectionString
           )
        {
            ConfigureProvider(dbContextOptions, provider, connectionString);
        }
    }
}