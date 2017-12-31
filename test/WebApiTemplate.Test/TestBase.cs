using System;
using System.Threading.Tasks;
using Abp.TestBase;
using WebApiTemplate.EntityFrameworkCore;
using WebApiTemplate.Test.TestDatas;

namespace WebApiTemplate.Test
{
    public class TestBase : AbpIntegratedTestBase<TestModule>
    {
        public TestBase()
        {
            UsingDbContext(context => new TestDataBuilder(context).Build());
        }

        protected virtual void UsingDbContext(Action<MainDbContext> action)
        {
            using (var context = LocalIocManager.Resolve<MainDbContext>())
            {
                action(context);
                context.SaveChanges();
            }
        }

        protected virtual T UsingDbContext<T>(Func<MainDbContext, T> func)
        {
            T result;

            using (var context = LocalIocManager.Resolve<MainDbContext>())
            {
                result = func(context);
                context.SaveChanges();
            }

            return result;
        }

        protected virtual async Task UsingDbContextAsync(Func<MainDbContext, Task> action)
        {
            using (var context = LocalIocManager.Resolve<MainDbContext>())
            {
                await action(context);
                await context.SaveChangesAsync(true);
            }
        }

        protected virtual async Task<T> UsingDbContextAsync<T>(Func<MainDbContext, Task<T>> func)
        {
            T result;

            using (var context = LocalIocManager.Resolve<MainDbContext>())
            {
                result = await func(context);
                context.SaveChanges();
            }

            return result;
        }
    }
}