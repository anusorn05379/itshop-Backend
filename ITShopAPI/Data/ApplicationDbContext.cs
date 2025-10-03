using Microsoft.EntityFrameworkCore;
using ITShopAPI.Models;

namespace ITShopAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure Product
            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Price).HasColumnType("decimal(18,2)");
                entity.Property(e => e.CreatedDate).HasDefaultValueSql("datetime('now')");
                entity.Property(e => e.UpdatedDate).HasDefaultValueSql("datetime('now')");

                // Add index for faster search/filter operations
                entity.HasIndex(e => e.Name);
                entity.HasIndex(e => e.Price);
            });

            // Configure Customer
            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.HasIndex(e => e.Email).IsUnique();
                entity.Property(e => e.CreatedDate).HasDefaultValueSql("datetime('now')");
                entity.Property(e => e.UpdatedDate).HasDefaultValueSql("datetime('now')");
            });

            // Configure Order
            modelBuilder.Entity<Order>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.TotalAmount).HasColumnType("decimal(18,2)");
                entity.Property(e => e.CreatedDate).HasDefaultValueSql("datetime('now')");
                entity.Property(e => e.UpdatedDate).HasDefaultValueSql("datetime('now')");

                entity.HasOne(e => e.Customer)
                    .WithMany(c => c.Orders)
                    .HasForeignKey(e => e.CustomerId)
                    .OnDelete(DeleteBehavior.Restrict);

                // Add indexes for faster queries
                entity.HasIndex(e => e.CustomerId);
                entity.HasIndex(e => e.Status);
                entity.HasIndex(e => e.PaymentStatus);
            });

            // Configure OrderItem
            modelBuilder.Entity<OrderItem>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.UnitPrice).HasColumnType("decimal(18,2)");
                entity.Property(e => e.SubTotal).HasColumnType("decimal(18,2)");

                entity.HasOne(e => e.Order)
                    .WithMany(o => o.OrderItems)
                    .HasForeignKey(e => e.OrderId)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(e => e.Product)
                    .WithMany(p => p.OrderItems)
                    .HasForeignKey(e => e.ProductId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            // Seed initial data
            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    Id = 1,
                    Name = "Laptop Dell XPS 15",
                    Description = "High-performance laptop for professionals",
                    Price = 45000,
                    Stock = 10,
                    ImageUrl = "https://placehold.co/300x200/1890ff/white?text=Dell+XPS+15",
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now
                },
                new Product
                {
                    Id = 2,
                    Name = "iPhone 15 Pro",
                    Description = "Latest Apple smartphone with titanium design",
                    Price = 42000,
                    Stock = 15,
                    ImageUrl = "https://placehold.co/300x200/52c41a/white?text=iPhone+15+Pro",
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now
                },
                new Product
                {
                    Id = 3,
                    Name = "Samsung Galaxy S24",
                    Description = "Flagship Android smartphone with AI features",
                    Price = 35000,
                    Stock = 20,
                    ImageUrl = "https://placehold.co/300x200/722ed1/white?text=Galaxy+S24",
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now
                },
                new Product
                {
                    Id = 4,
                    Name = "MacBook Air M3",
                    Description = "Ultra-thin laptop with powerful M3 chip",
                    Price = 48000,
                    Stock = 8,
                    ImageUrl = "https://placehold.co/300x200/fa8c16/white?text=MacBook+Air",
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now
                },
                new Product
                {
                    Id = 5,
                    Name = "iPad Pro 12.9",
                    Description = "Professional tablet for creative work",
                    Price = 38000,
                    Stock = 12,
                    ImageUrl = "https://placehold.co/300x200/eb2f96/white?text=iPad+Pro",
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now
                },
                new Product
                {
                    Id = 6,
                    Name = "ASUS ROG Strix Gaming Laptop",
                    Description = "Ultimate gaming laptop with RTX 4090",
                    Price = 75000,
                    Stock = 5,
                    ImageUrl = "https://placehold.co/300x200/13c2c2/white?text=ASUS+ROG",
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now
                },
                new Product
                {
                    Id = 7,
                    Name = "Sony WH-1000XM5 Headphones",
                    Description = "Premium noise-cancelling wireless headphones",
                    Price = 15000,
                    Stock = 25,
                    ImageUrl = "https://placehold.co/300x200/2f54eb/white?text=Sony+WH-1000XM5",
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now
                },
                new Product
                {
                    Id = 8,
                    Name = "Logitech MX Master 3S Mouse",
                    Description = "Advanced wireless mouse for professionals",
                    Price = 3500,
                    Stock = 30,
                    ImageUrl = "https://placehold.co/300x200/a0d911/white?text=MX+Master+3S",
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now
                },
                new Product
                {
                    Id = 9,
                    Name = "Apple Watch Series 9",
                    Description = "Latest smartwatch with advanced health features",
                    Price = 18000,
                    Stock = 18,
                    ImageUrl = "https://placehold.co/300x200/f5222d/white?text=Apple+Watch+9",
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now
                },
                new Product
                {
                    Id = 10,
                    Name = "Samsung 4K Monitor 32 inch",
                    Description = "Ultra HD monitor for professional work",
                    Price = 22000,
                    Stock = 12,
                    ImageUrl = "https://placehold.co/300x200/1890ff/white?text=Samsung+4K+32",
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now
                },
                new Product
                {
                    Id = 11,
                    Name = "Razer BlackWidow V3 Keyboard",
                    Description = "Mechanical gaming keyboard with RGB",
                    Price = 5500,
                    Stock = 22,
                    ImageUrl = "https://placehold.co/300x200/52c41a/white?text=Razer+BlackWidow",
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now
                },
                new Product
                {
                    Id = 12,
                    Name = "WD My Passport 2TB External HDD",
                    Description = "Portable external hard drive",
                    Price = 2800,
                    Stock = 40,
                    ImageUrl = "https://placehold.co/300x200/722ed1/white?text=WD+Passport+2TB",
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now
                },
                new Product
                {
                    Id = 13,
                    Name = "AirPods Pro 2nd Gen",
                    Description = "Active noise cancellation wireless earbuds",
                    Price = 9500,
                    Stock = 28,
                    ImageUrl = "https://placehold.co/300x200/fa8c16/white?text=AirPods+Pro+2",
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now
                },
                new Product
                {
                    Id = 14,
                    Name = "Xiaomi Mi Band 8",
                    Description = "Affordable fitness tracker smartband",
                    Price = 1200,
                    Stock = 50,
                    ImageUrl = "https://placehold.co/300x200/eb2f96/white?text=Mi+Band+8",
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now
                },
                new Product
                {
                    Id = 15,
                    Name = "Canon EOS R6 Camera",
                    Description = "Professional mirrorless camera",
                    Price = 95000,
                    Stock = 6,
                    ImageUrl = "https://placehold.co/300x200/13c2c2/white?text=Canon+EOS+R6",
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now
                },
                new Product
                {
                    Id = 16,
                    Name = "DJI Mini 3 Pro Drone",
                    Description = "Compact drone with 4K camera",
                    Price = 28000,
                    Stock = 10,
                    ImageUrl = "https://placehold.co/300x200/2f54eb/white?text=DJI+Mini+3",
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now
                },
                new Product
                {
                    Id = 17,
                    Name = "GoPro Hero 12",
                    Description = "Action camera with 5.3K video",
                    Price = 18500,
                    Stock = 15,
                    ImageUrl = "https://placehold.co/300x200/a0d911/white?text=GoPro+Hero+12",
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now
                },
                new Product
                {
                    Id = 18,
                    Name = "Nintendo Switch OLED",
                    Description = "Gaming console with vibrant OLED screen",
                    Price = 12500,
                    Stock = 20,
                    ImageUrl = "https://placehold.co/300x200/f5222d/white?text=Switch+OLED",
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now
                },
                new Product
                {
                    Id = 19,
                    Name = "PlayStation 5",
                    Description = "Next-gen gaming console",
                    Price = 19900,
                    Stock = 8,
                    ImageUrl = "https://placehold.co/300x200/1890ff/white?text=PlayStation+5",
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now
                },
                new Product
                {
                    Id = 20,
                    Name = "Xbox Series X",
                    Description = "Powerful gaming console with 4K support",
                    Price = 18500,
                    Stock = 12,
                    ImageUrl = "https://placehold.co/300x200/52c41a/white?text=Xbox+Series+X",
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now
                }
            );
        }
    }
}
