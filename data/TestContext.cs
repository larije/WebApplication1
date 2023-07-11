using Microsoft.EntityFrameworkCore;
using WebApplication1.model;

namespace WebApplication1.data
{
    public class TestContext: DbContext
    {
        public TestContext(DbContextOptions<TestContext> options) : base(options) { }


        public DbSet<WebApplication1.model.project> tProject { get; set; }
        public DbSet<WebApplication1.model.projectTask>? tprojectTask { get; set; }
        public DbSet<WebApplication1.model.SysUser>? tSysUser { get; set; }

    }
}
