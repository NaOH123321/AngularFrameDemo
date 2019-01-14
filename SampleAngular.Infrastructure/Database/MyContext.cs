using Microsoft.EntityFrameworkCore;
using SampleAngular.Core.Entities;
using SampleAngular.Infrastructure.Database.EntityConfigurations;

namespace SampleAngular.Infrastructure.Database
{
    /// <summary>
    /// MySQL迁移数据库时需要手动创建迁移历史表
    /// CREATE TABLE `__EFMigrationsHistory` ( `MigrationId` nvarchar(150) NOT NULL, `ProductVersion` nvarchar(32) NOT NULL, PRIMARY KEY (`MigrationId`) );
    /// </summary>
    public class MyContext :DbContext
    {
        public MyContext(DbContextOptions<MyContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new StockConfiguration());
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());

            modelBuilder.Entity<StockCategory>().HasKey(x => new {x.StockId, x.CategoryId});
            modelBuilder.Entity<StockCategory>().HasOne(x => x.Stock).WithMany(x => x.StockCategories)
                .HasForeignKey(x => x.StockId);
            modelBuilder.Entity<StockCategory>().HasOne(x => x.Category).WithMany(x => x.StockCategories)
                .HasForeignKey(x => x.CategoryId);
        }

        public DbSet<Stock> Stocks { get; set; }
        public DbSet<StockCategory> StockCategories { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}
