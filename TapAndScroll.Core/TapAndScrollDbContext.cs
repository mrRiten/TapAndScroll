using Microsoft.EntityFrameworkCore;
using TapAndScroll.Core.Models;

namespace TapAndScroll.Core
{
    public class TapAndScrollDbContext : DbContext
    {
        public TapAndScrollDbContext(DbContextOptions<TapAndScrollDbContext> options) : base(options) { }

        public DbSet<AdditionalParametersCategory> AdditionalParametersCategory { get; set; }
        public DbSet<AdditionalParameters> AdditionalParameters { get; set; }
        public DbSet<Basket> Baskets { get; set; }
        public DbSet<BasketProduct> BasketsProduct { get; set;}
        public DbSet<Category> Categories { get; set; }
        public DbSet<Favorites> Favorites { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }
        public DbSet<ImgProduct> ImgProducts { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderProduct> OrdersProduct { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AdditionalParameters>()
                .HasOne(ap => ap.Product)
                .WithMany(p => p.Parameters)
                .HasForeignKey(ap => ap.ProductId);


            modelBuilder.Entity<AdditionalParametersCategory>()
                .HasOne(apc => apc.Category)
                .WithMany(c => c.AdditionalParametersCategory)
                .HasForeignKey(apc => apc.CategoryId);

            modelBuilder.Entity<Basket>()
               .HasOne(b => b.User)
               .WithMany(u => u.Baskets)
               .HasForeignKey(b => b.UserId);

            modelBuilder.Entity<BasketProduct>()
                .HasOne(bp => bp.User)
                .WithMany(u => u.BasketProducts)
                .HasForeignKey(bp => bp.UserId);

            modelBuilder.Entity<BasketProduct>()
                .HasOne(bp => bp.Product)
                .WithMany()
                .HasForeignKey(bp => bp.ProductId);

            modelBuilder.Entity<Favorites>()
                .HasOne(f => f.User)
                .WithMany(u => u.Favorites)
                .HasForeignKey(f => f.UserId);

            modelBuilder.Entity<Favorites>()
                .HasOne(f => f.Product)
                .WithMany()
                .HasForeignKey(f => f.ProductId);

            modelBuilder.Entity<Feedback>()
                .HasOne(fb => fb.User)
                .WithMany(u => u.Feedbacks)
                .HasForeignKey(fb => fb.UserId);

            modelBuilder.Entity<Feedback>()
                .HasOne(fb => fb.Product)
                .WithMany(p => p.Feedbacks)
                .HasForeignKey(fb => fb.ProductId);

            modelBuilder.Entity<Order>()
                .HasOne(o => o.User)
                .WithMany(u => u.Orders)
                .HasForeignKey(o => o.UserId);

            modelBuilder.Entity<OrderProduct>()
                .HasKey(op => new { op.OrderId, op.ProductId });

            modelBuilder.Entity<OrderProduct>()
                .HasOne(op => op.Order)
                .WithMany(o => o.OrderProducts)
                .HasForeignKey(op => op.OrderId);

            modelBuilder.Entity<OrderProduct>()
                .HasOne(op => op.Product)
                .WithMany()
                .HasForeignKey(op => op.ProductId);

            modelBuilder.Entity<Product>()
                .HasOne(p => p.Category)
                .WithMany(c => c.Products)
                .HasForeignKey(p => p.CategoryId);

            modelBuilder.Entity<User>()
                .HasOne(u => u.Role)
                .WithMany(r => r.Users)
                .HasForeignKey(u => u.RoleId);

        }
    }
}
