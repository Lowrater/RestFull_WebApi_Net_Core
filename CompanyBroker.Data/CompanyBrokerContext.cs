using Microsoft.EntityFrameworkCore;

namespace CompanyBroker.Data
{
    public class CompanyBrokerContext : DbContext
    {
        public CompanyBrokerContext(DbContextOptions<CompanyBrokerContext> options) : base(options) { }

        public DbSet<Company> Companies { get; set; }

        public DbSet<Account> Accounts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>().Property(a => a.Username).HasMaxLength(100).IsRequired();
            modelBuilder.Entity<Account>().HasAlternateKey(a => a.Username);
            modelBuilder.Entity<Account>().Property(a => a.PasswordHash).HasMaxLength(32).IsFixedLength();
            modelBuilder.Entity<Account>().Property(a => a.PasswordSalt).HasMaxLength(32).IsFixedLength();
            modelBuilder.Entity<Account>().Property(a => a.Email).HasMaxLength(250);
            modelBuilder.Entity<Company>().Property(c => c.Balance).HasColumnType("money");
        }
    }
}
