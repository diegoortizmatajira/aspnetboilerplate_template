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
            DbContextOptionsConfigurer.ConfigureMainDbContext(builder, configuration);
            return new MainDbContext(builder.Options);
        }
    }
}