using Microsoft.EntityFrameworkCore;

namespace GeekShopping.ProductApi.Model.Context
{
    public class MyContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public MyContext(DbContextOptions<MyContext> dbContextOptions) : base(dbContextOptions)
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            ChangeTracker.AutoDetectChangesEnabled = false;
            this.Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(MyContext).Assembly);

            modelBuilder.Entity<Product>().HasData( new Product 
            {
                Id = 1,
                ImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTDBJIKnU6BAEI8JEaCnpmAli0fW1-Q2OLA0eUp6ZNzzA&s",
                CategoryName = "Leao",
                Name = "Leao",
                Description = "Leao",
                Price = new Decimal(100.00)
            }
                );

            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 2,
                ImageUrl = "https://www.pontotel.com.br/wp-content/uploads/2022/05/imagem-corporativa.jpg",
                CategoryName = "Predios",
                Name = "Predios",
                Description = "Predios",
                Price = new Decimal(300.00)
            }
        );

            base.OnModelCreating(modelBuilder);
        }

    }
}
