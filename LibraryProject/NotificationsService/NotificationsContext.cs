using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace NotificationsService
{
    public partial class NotificationsContext : DbContext
    {
        public NotificationsContext()
            : base("name=NotificationsContext")
        {
        }

        public virtual DbSet<C__MigrationHistory> C__MigrationHistory { get; set; }
        public virtual DbSet<Books> Books { get; set; }
        public virtual DbSet<Leases> Leases { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
