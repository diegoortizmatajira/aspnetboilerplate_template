using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using WebApiTemplate.Core;
using WebApiTemplate.Core.Configuration;
using WebApiTemplate.Core.Web;

namespace WebApiTemplate.EntityFrameworkCore
{
    public class WebApiTemplateDbContextFactory : IDesignTimeDbContextFactory<WebApiTemplateDbContext>
    {
        public WebApiTemplateDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<WebApiTemplateDbContext>();
            var configuration = AppConfigurations.Get(WebContentDirectoryFinder.CalculateContentRootFolder());
            var ConnectionString = configuration.GetConnectionString(WebApiTemplateConsts.ConnectionStringName);

            DbContextOptionsConfigurer.Configure(builder, ConnectionString);
            return new WebApiTemplateDbContext(builder.Options);
        }
    }
}