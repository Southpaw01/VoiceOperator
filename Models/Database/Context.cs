using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Models
{
    public class Context : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Reglament> Reglaments { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Dialog> Dialogs { get; set; }
        public DbSet<Test> Tests { get; set; }
        public DbSet<TestDialog> TestDialog { get; set; }

        private static readonly string server = "DESKTOP-Q4ECFHC\\SQLEXPRESS";
        private static readonly string catalog = "Reglament2";
        private static readonly string trustedConnection = "True";
        private static readonly string trustServerCertificate = "True";

        public static readonly string connectionString = $"Data Source={server};" +
                                                         $"Initial Catalog={catalog};" +
                                                         $"Trusted_Connection={trustedConnection};" +
                                                         $"TrustServerCertificate={trustServerCertificate};";


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString);
        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasMany(u => u.Tests)
                .WithOne(t => t.User)
                .HasForeignKey(t => t.UserId)
                .IsRequired();

            modelBuilder.Entity<Dialog>()
                .HasMany(s => s.Reglaments)
                .WithOne(c => c.Dialog)
                .HasForeignKey(c => c.DialogId)
                .IsRequired();

            modelBuilder.Entity<Message>()
                .HasOne(m => m.TestDialog)
                .WithMany(t => t.Messages)
                .IsRequired();
                
        }
    }
}
