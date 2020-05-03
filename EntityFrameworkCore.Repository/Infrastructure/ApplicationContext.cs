using EntityFrameworkCore.DataModel;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace EntityFrameworkCore.Repository
{
    public class ApplicationContext : DbContext
    {
        #region Members
        public DbSet<Student> Student { get; set; }
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
            modelBuilder.Seed();
            modelBuilder.ApplyConfiguration(new StudentConfig());
            modelBuilder.ApplyConfiguration(new StudentSubjectConfig());

            foreach (var property in modelBuilder.Model.GetEntityTypes()
                        .SelectMany(t => t.GetProperties())
                        .Where(p => p.ClrType == typeof(string)))
            {
                int? maxLen = property.GetMaxLength();
                maxLen = maxLen ?? 1;
                if (property.GetColumnType() == null)
                    property.SetColumnType($"VARCHAR({maxLen})");
            }

            base.OnModelCreating(modelBuilder);
        }
        #endregion
    }
}
