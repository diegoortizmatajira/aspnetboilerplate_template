using Abp.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace WebApiTemplate.EntityFrameworkCore
{
    public class MainDbContext : AbpDbContext
    {
        //Add DbSet properties for your entities...

        public MainDbContext(DbContextOptions<MainDbContext> options)
            : base(options)
        {

        }
    }
}