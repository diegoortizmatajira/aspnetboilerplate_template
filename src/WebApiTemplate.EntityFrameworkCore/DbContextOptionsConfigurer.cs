using Abp;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace WebApiTemplate.EntityFrameworkCore
{
    public static class DbContextOptionsConfigurer
    {

        public static void Configure(
           DbContextOptionsBuilder<WebApiTemplateDbContext> dbContextOptions,
           string connectionString)
        {
            dbContextOptions.UseNpgsql(connectionString);
        }
    }
}