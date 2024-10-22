using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject.Model
{
    public class MyStoreDBContext : IdentityDbContext
    {

        public MyStoreDBContext() : base(new DbContextOptions<MyStoreDBContext>())
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var builder = new ConfigurationBuilder()
   .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../BusinessObject"))
   .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            IConfigurationRoot config = builder.Build();
            optionsBuilder.UseSqlServer(config.GetConnectionString("MyStoreDB"));
        }


        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Thiết lập khóa chính cho Order
            builder.Entity<Order>()
                .HasKey(o => o.OrderId);

            // Thiết lập mối quan hệ giữa Order và ApplicationUser
            builder.Entity<Order>()
                .HasOne(o => o.Member)
                .WithMany(u => u.Orders)
                .HasForeignKey(o => o.MemberId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);


            // Thiết lập khóa chính cho OrderDetail
            builder.Entity<OrderDetail>()
                .HasKey(od => new { od.OrderId, od.ProductId });

            // Thiết lập mối quan hệ giữa OrderDetail và Order
            builder.Entity<OrderDetail>()
                .HasOne(od => od.Order)
                .WithMany(o => o.OrderDetails)
                .HasForeignKey(od => od.OrderId);

            // Thiết lập mối quan hệ giữa OrderDetail và Product
            builder.Entity<OrderDetail>()
                .HasOne(od => od.Product)
                .WithMany(p => p.OrderDetails)
                .HasForeignKey(od => od.ProductId);

            // Thiết lập mối quan hệ giữa Product và Category
            builder.Entity<Product>()
                .HasOne(p => p.Category)
                .WithMany(c => c.Products)
                .HasForeignKey(p => p.CategoryId)
                .IsRequired(); // Đảm bảo CategoryId là bắt buộc
        }
    }
}

