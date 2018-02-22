using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using WebApiTemplate.Core.Configuration;
using WebApiTemplate.Core.Web;

namespace WebApiTemplate.EntityFrameworkCore
{
    public class MainDbContextFactory : IDesignTimeDbContextFactory<MainDbContext>
    {
        public MainDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<MainDbContext>();
            var configuration = AppConfigurations.Get(WebContentDirectoryFinder.CalculateContentRootFolder());
            var Provider = configuration[SolutionConsts.MainDatabaseConnectionProviderName];
            var ConnectionString = configuration.GetConnectionString(SolutionConsts.MainDatabaseConnectionStringName);

            DbContextOptionsConfigurer.ConfigureMainDbContext(builder, Provider, ConnectionString);
            return new MainDbContext(builder.Options);
        }
    }
}