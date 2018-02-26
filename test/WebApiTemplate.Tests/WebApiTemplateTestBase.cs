using System;
using System.Threading.Tasks;
using Abp.TestBase;
using WebApiTemplate.EntityFrameworkCore;
using WebApiTemplate.Tests.TestDatas;

namespace WebApiTemplate.Tests
{
    public class WebApiTemplateTestBase : AbpIntegratedTestBase<WebApiTemplateTestModule>
    {
        public WebApiTemplateTestBase()
        {
            UsingDbContext(context => new TestDataBuilder(context).Build());
        }

        protected virtual void UsingDbContext(Action<WebApiTemplateDbContext> action)
        {
            using (var context = LocalIocManager.Resolve<WebApiTemplateDbContext>())
            {
                action(context);
                context.SaveChanges();
            }
        }

        protected virtual T UsingDbContext<T>(Func<WebApiTemplateDbContext, T> func)
        {
            T result;

            using (var context = LocalIocManager.Resolve<WebApiTemplateDbContext>())
            {
                result = func(context);
                context.SaveChanges();
            }

            return result;
        }

        protected virtual async Task UsingDbContextAsync(Func<WebApiTemplateDbContext, Task> action)
        {
            using (var context = LocalIocManager.Resolve<WebApiTemplateDbContext>())
            {
                await action(context);
                await context.SaveChangesAsync(true);
            }
        }

        protected virtual async Task<T> UsingDbContextAsync<T>(Func<WebApiTemplateDbContext, Task<T>> func)
        {
            T result;

            using (var context = LocalIocManager.Resolve<WebApiTemplateDbContext>())
            {
                result = await func(context);
                context.SaveChanges();
            }

            return result;
        }
    }
}