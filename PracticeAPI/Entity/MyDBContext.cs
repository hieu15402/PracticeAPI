using Microsoft.EntityFrameworkCore;

namespace PracticeAPI.Entity
{
    public class MyDBContext : DbContext
    {
        public MyDBContext() { }
        public MyDBContext(DbContextOptions<MyDBContext> options) : base(options) { }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(GetConnectionString());
            }
        }

        private string GetConnectionString()
        {
            IConfiguration config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", true, true)
                .Build();
            return config["ConnectionStrings:DefaultConnectionStrings"];
        }

        public DbSet<UserEntity> Users { get; set; }

        public DbSet<ProductEntity> Products { get; set; }
        public DbSet<TypeEntity> Types { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserEntity>(entity =>
            {
                entity.HasIndex(e => e.Id).IsUnique();
                entity.HasIndex(e => e.UserName).IsUnique();
            });
        }
    }
}
