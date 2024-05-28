using Microsoft.EntityFrameworkCore;

namespace GosExApp
{
    internal class MyDbContext : DbContext
    {
        public virtual DbSet<UserModel> Users { set; get; }

        public virtual DbSet<ClassModel> Classes { set; get; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=helloapp.db");
        }
    }
}
