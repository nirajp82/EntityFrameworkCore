using EntityFrameworkCore.DataModel;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkCore.Repository
{
    public class ApplicationContext : DbContext
    {
        #region Members
        public DbSet<Student> Students { get; set; }
        #endregion


        #region Constructor
        public ApplicationContext(DbContextOptions dbContextOptions) :
            base(dbContextOptions)
        {
        }
        #endregion

        #region Public Methods
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new StudentConfig());
        }
        #endregion
    }
}
