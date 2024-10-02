using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace KoiDeliv.DataAccess.Models
{
    public partial class KoiDeliveryDBContext : DbContext
    {
        public KoiDeliveryDBContext()
        {
        }

        public KoiDeliveryDBContext(DbContextOptions<KoiDeliveryDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Blog> Blogs { get; set; } = null!;
        public virtual DbSet<CustomerProfile> CustomerProfiles { get; set; } = null!;
        public virtual DbSet<Order> Orders { get; set; } = null!;
        public virtual DbSet<PriceList> PriceLists { get; set; } = null!;
        public virtual DbSet<RatingsFeedback> RatingsFeedbacks { get; set; } = null!;
        public virtual DbSet<Shipment> Shipments { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=.;Database=KoiDeliveryDB;Uid=sa;Pwd=admin12345;TrustServerCertificate=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Blog>(entity =>
            {
                entity.Property(e => e.BlogId).HasColumnName("BlogID");

                entity.Property(e => e.AuthorId).HasColumnName("AuthorID");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ImagePath).HasMaxLength(255);

                entity.Property(e => e.PriceListId).HasColumnName("PriceListID");

                entity.Property(e => e.Title).HasMaxLength(255);

                entity.HasOne(d => d.Author)
                    .WithMany(p => p.Blogs)
                    .HasForeignKey(d => d.AuthorId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK__Blogs__AuthorID__66603565");

                entity.HasOne(d => d.PriceList)
                    .WithMany(p => p.Blogs)
                    .HasForeignKey(d => d.PriceListId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK__Blogs__PriceList__6754599E");
            });

            modelBuilder.Entity<CustomerProfile>(entity =>
            {
                entity.HasKey(e => e.ProfileId)
                    .HasName("PK__Customer__290C888492D92791");

                entity.Property(e => e.ProfileId).HasColumnName("ProfileID");

                entity.Property(e => e.CustomerId).HasColumnName("CustomerID");

                entity.Property(e => e.LastOrderDate).HasColumnType("datetime");

                entity.Property(e => e.TotalOrders).HasDefaultValueSql("((0))");

                entity.Property(e => e.TotalSpent)
                    .HasColumnType("decimal(18, 0)")
                    .HasDefaultValueSql("((0))");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.CustomerProfiles)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK__CustomerP__Custo__656C112C");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.Property(e => e.OrderId).HasColumnName("OrderID");

                entity.Property(e => e.AdditionalServices).HasMaxLength(255);

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CustomerId).HasColumnName("CustomerID");

                entity.Property(e => e.Destination).HasMaxLength(255);

                entity.Property(e => e.Origin).HasMaxLength(255);

                entity.Property(e => e.ShippingMethod).HasMaxLength(100);

                entity.Property(e => e.Status)
                    .HasMaxLength(50)
                    .HasDefaultValueSql("('Pending')");

                entity.Property(e => e.TotalWeight).HasColumnType("decimal(18, 0)");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK__Orders__Customer__60A75C0F");
            });

            modelBuilder.Entity<PriceList>(entity =>
            {
                entity.HasKey(e => e.PriceId)
                    .HasName("PK__PriceLis__4957584F551C9DB8");

                entity.ToTable("PriceList");

                entity.Property(e => e.PriceId).HasColumnName("PriceID");

                entity.Property(e => e.AdditionalServicePrice).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.BasePrice).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.WeightRange).HasMaxLength(50);
            });

            modelBuilder.Entity<RatingsFeedback>(entity =>
            {
                entity.HasKey(e => e.FeedbackId)
                    .HasName("PK__RatingsF__6A4BEDF67E6C106B");

                entity.Property(e => e.FeedbackId).HasColumnName("FeedbackID");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Feedback).HasMaxLength(1000);

                entity.Property(e => e.OrderId).HasColumnName("OrderID");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.RatingsFeedbacks)
                    .HasForeignKey(d => d.OrderId)
                    .HasConstraintName("FK__RatingsFe__Order__6477ECF3");
            });

            modelBuilder.Entity<Shipment>(entity =>
            {
                entity.Property(e => e.ShipmentId).HasColumnName("ShipmentID");

                entity.Property(e => e.CertificateIssued).HasMaxLength(255);

                entity.Property(e => e.DeliveringStaffId).HasColumnName("DeliveringStaffID");

                entity.Property(e => e.DeliveryDate).HasColumnType("datetime");

                entity.Property(e => e.ForeignImportStatus).HasMaxLength(50);

                entity.Property(e => e.HealthCheckStatus).HasMaxLength(50);

                entity.Property(e => e.OrderId).HasColumnName("OrderID");

                entity.Property(e => e.PackingStatus).HasMaxLength(50);

                entity.Property(e => e.SalesStaffId).HasColumnName("SalesStaffID");

                entity.Property(e => e.ShippingStatus)
                    .HasMaxLength(50)
                    .HasDefaultValueSql("('In-Progress')");

                entity.HasOne(d => d.DeliveringStaff)
                    .WithMany(p => p.ShipmentDeliveringStaffs)
                    .HasForeignKey(d => d.DeliveringStaffId)
                    .HasConstraintName("FK__Shipments__Deliv__6383C8BA");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.Shipments)
                    .HasForeignKey(d => d.OrderId)
                    .HasConstraintName("FK__Shipments__Order__619B8048");

                entity.HasOne(d => d.SalesStaff)
                    .WithMany(p => p.ShipmentSalesStaffs)
                    .HasForeignKey(d => d.SalesStaffId)
                    .HasConstraintName("FK__Shipments__Sales__628FA481");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasIndex(e => e.Email, "UQ__Users__A9D105348A145F52")
                    .IsUnique();

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.Address).HasMaxLength(255);

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Email).HasMaxLength(100);

                entity.Property(e => e.FullName).HasMaxLength(100);

                entity.Property(e => e.PasswordHash).HasMaxLength(255);

                entity.Property(e => e.PhoneNumber).HasMaxLength(15);

                entity.Property(e => e.Role).HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
