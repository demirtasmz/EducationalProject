using Microsoft.EntityFrameworkCore;

namespace EducationalProject.Repository.Entity
{
    public class NorthWindContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer(@"Server=localhost;Database=Northwind;Trusted_Connection=true;Trusted_Connection=True;MultipleActiveResultSets=true;Integrated Security=false");
           optionsBuilder.UseSqlServer(@"Server=localhost;Database=Northwind;Trusted_Connection=True;");

        }

        public DbSet<Product> Products { get; set; }

        public DbSet<Category> Categories { get; set; }

    }
}
