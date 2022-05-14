using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PcAccessories.Entities.Entities;
using PcAccessories.Ultilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PcAccessories.EFCore.Data
{
    public class PcAccessoriesDbContext : IdentityDbContext<User, Role, Guid>
    {
        public PcAccessoriesDbContext(DbContextOptions<PcAccessoriesDbContext> options) : base(options)
        {

        }

        public DbSet<Slide> Sliders { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }
        public DbSet<ProductLove> ProductLoves { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<InvoiceDetail> InvoiceDetails { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<ProductInCart> ProductInCarts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IdentityUserClaim<Guid>>().ToTable("UserClaims");
            modelBuilder.Entity<IdentityUserRole<Guid>>().ToTable("UserRoles").HasKey(x => new { x.UserId, x.RoleId });
            modelBuilder.Entity<IdentityUserLogin<Guid>>().ToTable("UserLogins").HasKey(x => x.UserId);

            modelBuilder.Entity<IdentityRoleClaim<Guid>>().ToTable("RoleClaims");
            modelBuilder.Entity<IdentityUserToken<Guid>>().ToTable("UserTokens").HasKey(x => x.UserId);

            modelBuilder.Entity<Slide>()
            .Property(f => f.Id)
            .ValueGeneratedOnAdd();
            modelBuilder.Entity<Category>()
            .Property(f => f.Id)
            .ValueGeneratedOnAdd();
            modelBuilder.Entity<Brand>()
            .Property(f => f.Id)
            .ValueGeneratedOnAdd();
            modelBuilder.Entity<Product>()
            .Property(f => f.Id)
            .ValueGeneratedOnAdd();
            modelBuilder.Entity<ProductImage>()
            .Property(f => f.Id)
            .ValueGeneratedOnAdd();
            modelBuilder.Entity<ProductLove>()
            .Property(f => f.Id)
            .ValueGeneratedOnAdd();
            modelBuilder.Entity<Invoice>()
            .Property(f => f.Id)
            .ValueGeneratedOnAdd();
            modelBuilder.Entity<InvoiceDetail>()
            .Property(f => f.Id)
            .ValueGeneratedOnAdd();
            modelBuilder.Entity<Cart>()
            .Property(f => f.Id)
            .ValueGeneratedOnAdd();
            modelBuilder.Entity<ProductInCart>()
            .Property(f => f.Id)
            .ValueGeneratedOnAdd();

            modelBuilder.Entity<Slide>(entity =>
            {
                entity.Property(e => e.SlideId)
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.Property(e => e.CategoryId)
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            modelBuilder.Entity<Brand>(entity =>
            {
                entity.Property(e => e.BrandId)
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.CategoryId)
                    .IsRequired()
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.Property(e => e.ProductId)
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.BrandId)
                    .IsRequired()
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            modelBuilder.Entity<ProductImage>(entity =>
            {
                entity.Property(e => e.ProductImageId)
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.ProductId)
                    .IsRequired()
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            modelBuilder.Entity<ProductLove>(entity =>
            {
                entity.Property(e => e.ProductLoveId)
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.ProductId)
                    .IsRequired()
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            modelBuilder.Entity<Invoice>(entity =>
            {
                entity.Property(e => e.InvoiceId)
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            modelBuilder.Entity<InvoiceDetail>(entity =>
            {
                entity.Property(e => e.InvoiceDetailId)
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.InvoiceId)
                    .IsRequired()
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.ProductId)
                    .IsRequired()
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            modelBuilder.Entity<Cart>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.CartId)
                   .IsRequired()
                   .HasMaxLength(36)
                   .IsUnicode(false)
                   .IsFixedLength();
            });

            modelBuilder.Entity<ProductInCart>(entity =>
            {
                entity.Property(e => e.CartId)
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.ProductId)
                    .IsRequired()
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.ProductInCartId)
                    .IsRequired()
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .IsFixedLength();
            });



            modelBuilder.Entity<Slide>().HasIndex(x => x.SlideId).IsUnique();
            modelBuilder.Entity<Category>().HasIndex(x => x.CategoryId).IsUnique();
            modelBuilder.Entity<Brand>().HasIndex(x => x.BrandId).IsUnique();
            modelBuilder.Entity<Product>().HasIndex(x => x.ProductId).IsUnique();
            modelBuilder.Entity<ProductImage>().HasIndex(x => x.ProductImageId).IsUnique();
            modelBuilder.Entity<ProductLove>().HasIndex(x => x.ProductLoveId).IsUnique();
            modelBuilder.Entity<Invoice>().HasIndex(x => x.InvoiceId).IsUnique();
            modelBuilder.Entity<InvoiceDetail>().HasIndex(x => x.InvoiceDetailId).IsUnique();
            modelBuilder.Entity<Cart>().HasIndex(x => x.CartId).IsUnique();
            modelBuilder.Entity<ProductInCart>().HasIndex(x => x.ProductInCartId).IsUnique();

            var roleId = new Guid("8D04DCE2-969A-435D-BBA4-DF3F325983DC");
            var adminId = new Guid("69BD714F-9576-45BA-B5B7-F00649BE00DE");
            modelBuilder.Entity<Role>().HasData(new Role
            {
                Id = roleId,
                Name = "admin",
                NormalizedName = "admin",
                Description = "Administrator role"
            });

            var hasher = new PasswordHasher<User>();
            modelBuilder.Entity<User>().HasData(new User
            {
                Id = adminId,
                UserName = "admin",
                NormalizedUserName = "admin",
                Email = "huyt4242@gmail.com",
                NormalizedEmail = "huyt4242@gmail.com",
                EmailConfirmed = true,
                PasswordHash = hasher.HashPassword(null, "admin"),
                SecurityStamp = string.Empty,
                Name = "Atoms",
                Address = "HCM",
                PhoneNumber = "0342553542"
            });

            modelBuilder.Entity<IdentityUserRole<Guid>>().HasData(new IdentityUserRole<Guid>
            {
                RoleId = roleId,
                UserId = adminId
            });

            modelBuilder.Entity<Slide>().HasData(
              new Slide() { Id = 1, SlideId = new Guid("69BD714F-9576-45BA-B5B7-F00649BE00D1"), Image = "1.png", Status = (byte)PcAccessoriesEnum.SlideStatus.Active },
              new Slide() { Id = 2, SlideId = new Guid("69BD714F-9576-45BA-B5B7-F00649BE00D2"), Image = "2.png", Status = (byte)PcAccessoriesEnum.SlideStatus.Active },
              new Slide() { Id = 3, SlideId = new Guid("69BD714F-9576-45BA-B5B7-F00649BE00D3"), Image = "3.png", Status = (byte)PcAccessoriesEnum.SlideStatus.Active },
              new Slide() { Id = 4, SlideId = new Guid("69BD714F-9576-45BA-B5B7-F00649BE00D4"), Image = "4.png", Status = (byte)PcAccessoriesEnum.SlideStatus.Active },
              new Slide() { Id = 5, SlideId = new Guid("69BD714F-9576-45BA-B5B7-F00649BE00D5"), Image = "5.png", Status = (byte)PcAccessoriesEnum.SlideStatus.Active }
            );
            modelBuilder.Entity<Category>().HasData(
                new Category() { Id = 1, CategoryId = new Guid("79BD714F-9576-45BA-B5B7-F00649BE00D1"), Name = "Keyboard" },
                new Category() { Id = 2, CategoryId = new Guid("79BD714F-9576-45BA-B5B7-F00649BE00D2"), Name = "Mouse" },
                new Category() { Id = 3, CategoryId = new Guid("79BD714F-9576-45BA-B5B7-F00649BE00D3"), Name = "Earphone" },
                new Category() { Id = 4, CategoryId = new Guid("79BD714F-9576-45BA-B5B7-F00649BE00D4"), Name = "Keycap" },
                new Category() { Id = 5, CategoryId = new Guid("79BD714F-9576-45BA-B5B7-F00649BE00D5"), Name = "Micro" }
            );
            modelBuilder.Entity<Brand>().HasData(
                new Brand() { Id = 1, BrandId = new Guid("89BD714F-9576-45BA-B5B7-F00649BE00D1"), CategoryId = new Guid("79BD714F-9576-45BA-B5B7-F00649BE00D1"), Name = "Logitech" },
                new Brand() { Id = 2, BrandId = new Guid("89BD714F-9576-45BA-B5B7-F00649BE00D2"), CategoryId = new Guid("79BD714F-9576-45BA-B5B7-F00649BE00D1"), Name = "Razor" },
                new Brand() { Id = 3, BrandId = new Guid("89BD714F-9576-45BA-B5B7-F00649BE00D3"), CategoryId = new Guid("79BD714F-9576-45BA-B5B7-F00649BE00D2"), Name = "Logitech" },
                new Brand() { Id = 4, BrandId = new Guid("89BD714F-9576-45BA-B5B7-F00649BE00D4"), CategoryId = new Guid("79BD714F-9576-45BA-B5B7-F00649BE00D2"), Name = "Razor" },
                new Brand() { Id = 5, BrandId = new Guid("89BD714F-9576-45BA-B5B7-F00649BE00D5"), CategoryId = new Guid("79BD714F-9576-45BA-B5B7-F00649BE00D3"), Name = "Logitech" },
                new Brand() { Id = 6, BrandId = new Guid("89BD714F-9576-45BA-B5B7-F00649BE00D6"), CategoryId = new Guid("79BD714F-9576-45BA-B5B7-F00649BE00D3"), Name = "Sony" },
                new Brand() { Id = 7, BrandId = new Guid("89BD714F-9576-45BA-B5B7-F00649BE00D7"), CategoryId = new Guid("79BD714F-9576-45BA-B5B7-F00649BE00D4"), Name = "Sakura" },
                new Brand() { Id = 8, BrandId = new Guid("89BD714F-9576-45BA-B5B7-F00649BE00D8"), CategoryId = new Guid("79BD714F-9576-45BA-B5B7-F00649BE00D4"), Name = "Razor" },
                new Brand() { Id = 9, BrandId = new Guid("89BD714F-9576-45BA-B5B7-F00649BE00D9"), CategoryId = new Guid("79BD714F-9576-45BA-B5B7-F00649BE00D5"), Name = "Sony" },
                new Brand() { Id = 10, BrandId = new Guid("89BD714F-9576-45BA-B5B7-F00649BE00D0"), CategoryId = new Guid("79BD714F-9576-45BA-B5B7-F00649BE00D5"), Name = "AzAudio" }
            );
            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    Id = 1,
                    BrandId = new Guid("89BD714F-9576-45BA-B5B7-F00649BE00D1"),
                    ProductId = new Guid("99BD714F-9576-45BA-B5B7-F00649BE00D1"),
                    Name = "Keyboard-1",
                    Price = 100,
                    Quantity = 10,
                    Status = (byte)PcAccessoriesEnum.ProductStatus.New
                },
                new Product
                {
                    Id = 2,
                    BrandId = new Guid("89BD714F-9576-45BA-B5B7-F00649BE00D1"),
                    ProductId = new Guid("99BD714F-9576-45BA-B5B7-F00649BE00D2"),
                    Name = "Keyboard-2",
                    Price = 1000,
                    Quantity = 10,
                    Status = (byte)PcAccessoriesEnum.ProductStatus.New
                },
                new Product
                {
                    Id = 3,
                    BrandId = new Guid("89BD714F-9576-45BA-B5B7-F00649BE00D2"),
                    ProductId = new Guid("99BD714F-9576-45BA-B5B7-F00649BE00D3"),
                    Name = "Keyboard-3",
                    Price = 1500,
                    Quantity = 20,
                    Status = (byte)PcAccessoriesEnum.ProductStatus.New
                }, new Product
                {
                    Id = 4,
                    BrandId = new Guid("89BD714F-9576-45BA-B5B7-F00649BE00D2"),
                    ProductId = new Guid("99BD714F-9576-45BA-B5B7-F00649BE00D4"),
                    Name = "Keyboard-4",
                    Price = 2000,
                    Quantity = 15,
                    Status = (byte)PcAccessoriesEnum.ProductStatus.New
                }, new Product
                {
                    Id = 5,
                    BrandId = new Guid("89BD714F-9576-45BA-B5B7-F00649BE00D3"),
                    ProductId = new Guid("99BD714F-9576-45BA-B5B7-F00649BE00D5"),
                    Name = "Mouse-1",
                    Price = 150,
                    Quantity = 10,
                    Status = (byte)PcAccessoriesEnum.ProductStatus.New
                }, new Product
                {
                    Id = 6,
                    BrandId = new Guid("89BD714F-9576-45BA-B5B7-F00649BE00D3"),
                    ProductId = new Guid("99BD714F-9576-45BA-B5B7-F00649BE00D6"),
                    Name = "Mouse-2",
                    Price = 200,
                    Quantity = 10,
                    Status = (byte)PcAccessoriesEnum.ProductStatus.New
                }, new Product
                {
                    Id = 7,
                    BrandId = new Guid("89BD714F-9576-45BA-B5B7-F00649BE00D4"),
                    ProductId = new Guid("99BD714F-9576-45BA-B5B7-F00649BE00D7"),
                    Name = "Mouse-3",
                    Price = 150,
                    Quantity = 10,
                    Status = (byte)PcAccessoriesEnum.ProductStatus.New
                }, new Product
                {
                    Id = 8,
                    BrandId = new Guid("89BD714F-9576-45BA-B5B7-F00649BE00D4"),
                    ProductId = new Guid("99BD714F-9576-45BA-B5B7-F00649BE00D8"),
                    Name = "Mouse-4",
                    Price = 200,
                    Quantity = 10,
                    Status = (byte)PcAccessoriesEnum.ProductStatus.New
                },
                new Product
                {
                    Id = 9,
                    BrandId = new Guid("89BD714F-9576-45BA-B5B7-F00649BE00D5"),
                    ProductId = new Guid("99BD714F-9576-45BA-B5B7-F00649BE00D9"),
                    Name = "Earphone-1",
                    Price = 350,
                    Quantity = 10,
                    Status = (byte)PcAccessoriesEnum.ProductStatus.New
                }, new Product
                {
                    Id = 10,
                    BrandId = new Guid("89BD714F-9576-45BA-B5B7-F00649BE00D5"),
                    ProductId = new Guid("99BD714F-9576-45BA-B5B7-F00649BE0D10"),
                    Name = "Earphone-2",
                    Price = 200,
                    Quantity = 10,
                    Status = (byte)PcAccessoriesEnum.ProductStatus.New
                }, new Product
                {
                    Id = 11,
                    BrandId = new Guid("89BD714F-9576-45BA-B5B7-F00649BE00D6"),
                    ProductId = new Guid("99BD714F-9576-45BA-B5B7-F00649BE0D11"),
                    Name = "Earphone-3",
                    Price = 550,
                    Quantity = 10,
                    Status = (byte)PcAccessoriesEnum.ProductStatus.New
                }, new Product
                {
                    Id = 12,
                    BrandId = new Guid("89BD714F-9576-45BA-B5B7-F00649BE00D6"),
                    ProductId = new Guid("99BD714F-9576-45BA-B5B7-F00649BE0D12"),
                    Name = "Earphone-4",
                    Price = 400,
                    Quantity = 10,
                    Status = (byte)PcAccessoriesEnum.ProductStatus.New
                }
            );
        }
    }
}
