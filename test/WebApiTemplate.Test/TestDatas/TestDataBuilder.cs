using WebApiTemplate.EntityFrameworkCore;

namespace WebApiTemplate.Test.TestDatas
{
    public class TestDataBuilder
    {
        private readonly MainDbContext _context;

        public TestDataBuilder(MainDbContext context)
        {
            _context = context;
        }

        public void Build()
        {
            //create test data here...
        }
    }
}