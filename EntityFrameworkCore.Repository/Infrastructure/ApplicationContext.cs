using EntityFrameworkCore.DataModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

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

        public override int SaveChanges()
        {
            SetAuditValues();
            return base.SaveChanges();
        }       

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            SetAuditValues();
            return base.SaveChangesAsync(cancellationToken);
        }
        #endregion


        #region Private Method
        private void SetAuditValues()
        {
            var entries = ChangeTracker.Entries()
                                        .Where(e => e.Entity is BaseModel &&
                                        (e.State == EntityState.Added || e.State == EntityState.Modified));

            foreach (var entityEntry in entries)
            {
                ((BaseModel)entityEntry.Entity).UpdatedDate = DateTime.Now;
                if (entityEntry.State == EntityState.Added)
                    ((BaseModel)entityEntry.Entity).CreatedDate = DateTime.Now;
            }
        }
        #endregion
    }
}
