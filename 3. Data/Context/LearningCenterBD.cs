using _3._Data.Model;
using Microsoft.EntityFrameworkCore;

namespace _3._Data.Context;

public class LearningCenterBD : DbContext
{
     public LearningCenterBD()
    {
        
    }
     public LearningCenterBD(DbContextOptions<LearningCenterBD> options) : base(options)
     {
     }
     
     public DbSet<Category> Categories { get; set; }
     public DbSet<Tutorial> Tutorials { get; set; }
     
     protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
     {
         if (!optionsBuilder.IsConfigured)
         {
             var serverVersion = new MySqlServerVersion(new Version(8, 0, 29));
             optionsBuilder.UseMySql("Server=sql10.freemysqlhosting.net,3306;Uid=sql10658330;Pwd=7nVTxi2EXT;Database=sql10658330;", serverVersion);
         }
     }


     protected override void OnModelCreating(ModelBuilder builder)
     {
         base.OnModelCreating(builder);

         builder.Entity<Category>().ToTable("Category");
         builder.Entity<Category>().HasKey(p => p.Id);
         builder.Entity<Category>().Property(c => c.Name).IsRequired().HasMaxLength(90);
         builder.Entity<Category>().Property(c => c.DateCreated).HasDefaultValue(DateTime.Now);
         builder.Entity<Category>().Property(c => c.IsActive).HasDefaultValue(true);
         
         
         builder.Entity<Tutorial>().ToTable("Tutorial");
         builder.Entity<Tutorial>().HasKey(p => p.Id);
         builder.Entity<Tutorial>().Property(c => c.Title).IsRequired().HasMaxLength(50);
         builder.Entity<Tutorial>().Property(c => c.DateCreated).HasDefaultValue(DateTime.Now);
         builder.Entity<Tutorial>().Property(c => c.IsActive).HasDefaultValue(true);
     }
}