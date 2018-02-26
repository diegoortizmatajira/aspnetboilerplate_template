using Abp.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace WebApiTemplate.EntityFrameworkCore
{
    public class WebApiTemplateDbContext : AbpDbContext
    {
        //Add DbSet properties for your entities...

        public WebApiTemplateDbContext(DbContextOptions<WebApiTemplateDbContext> options)
            : base(options)
        {

        }
    }
}