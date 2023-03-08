using Microsoft.EntityFrameworkCore;
using TaskApp.MVVM.Entities;
using TaskApp.MVVM.Models;

namespace TaskApp.Contexts
{
    internal class DataContext : DbContext
    {
        private readonly string serverString = @"Data Source=javadov.database.windows.net;Initial Catalog=azure_db;User ID=SqlAdmin;Password=BytMig123!;Connect Timeout=30;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        #region constructors
        public DataContext() { }
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        #endregion

        #region overrides
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
                optionsBuilder.UseSqlServer(serverString);
        }
        #endregion

        #region entities
        public DbSet<ContactEntity> Contacts { get; set; }
        public DbSet<IssueEntity> Issues { get; set; }
        public DbSet<Issue> Issue { get; set; }
        public DbSet<CommentEntity> Comments { get; set; }

        #endregion
    }
}
