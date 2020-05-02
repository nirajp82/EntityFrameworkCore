using EntityFrameworkCore.DataModel;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkCore.Repository
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions dbContextOptions) :
            base(dbContextOptions)
        {
        }

        public DbSet<Student> Students { get; set; }
    }
}
