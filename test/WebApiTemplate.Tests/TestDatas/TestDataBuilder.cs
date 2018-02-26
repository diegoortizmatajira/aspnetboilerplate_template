using WebApiTemplate.EntityFrameworkCore;

namespace WebApiTemplate.Tests.TestDatas
{
    public class TestDataBuilder
    {
        private readonly WebApiTemplateDbContext _context;

        public TestDataBuilder(WebApiTemplateDbContext context)
        {
            _context = context;
        }

        public void Build()
        {
            //create test data here...
        }
    }
}