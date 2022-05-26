using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace LocalVendorAppDAL.Models
{
    public partial class demoAppContext : DbContext
    {
        public demoAppContext()
        {
        }

        public demoAppContext(DbContextOptions<demoAppContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Category> Categories { get; set; } = null!;
        public virtual DbSet<Customer> Customers { get; set; } = null!;
        public virtual DbSet<Sellerdetail> Sellerdetails { get; set; } = null!;
        public virtual DbSet<Shopdetail> Shopdetails { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var builder = new ConfigurationBuilder()
                      .SetBasePath(Directory.GetCurrentDirectory())
                      .AddJsonFile("appsettings.json");

            var config = builder.Build();
            var connectionString = config.GetConnectionString("demoAppDBConnectionString");

            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(connectionString);

            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>(entity =>
            {
                entity.ToTable("CATEGORY");

                entity.Property(e => e.Categoryid)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("CATEGORYID");

                entity.Property(e => e.Categoryname)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("CATEGORYNAME");
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.ToTable("CUSTOMER");

                entity.Property(e => e.Customerid).HasColumnName("CUSTOMERID");

                entity.Property(e => e.Emailid)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("EMAILID");

                entity.Property(e => e.Mobilenumber).HasColumnName("MOBILENUMBER");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("NAME");

                entity.Property(e => e.Password)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasColumnName("PASSWORD");
            });

            modelBuilder.Entity<Sellerdetail>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("SELLERDETAILS");

                entity.Property(e => e.Emailid)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("EMAILID");

                entity.Property(e => e.Mobilenumber).HasColumnName("MOBILENUMBER");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("NAME");

                entity.Property(e => e.Password)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasColumnName("PASSWORD");

                entity.Property(e => e.Shopid).HasColumnName("SHOPID");

                entity.HasOne(d => d.Shop)
                    .WithMany()
                    .HasForeignKey(d => d.Shopid)
                    .HasConstraintName("FK__SELLERDET__SHOPI__5DCAEF64");
            });

            modelBuilder.Entity<Shopdetail>(entity =>
            {
                entity.HasKey(e => e.ShopId)
                    .HasName("PK__SHOPDETA__67C557C975FBA634");

                entity.ToTable("SHOPDETAILS");

                entity.Property(e => e.Address)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ShopName)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Shopdetails)
                    .HasForeignKey(d => d.CategoryId)
                    .HasConstraintName("FK__SHOPDETAI__Categ__6383C8BA");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
