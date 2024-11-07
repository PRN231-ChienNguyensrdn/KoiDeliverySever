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
        public virtual DbSet<Gsp> Gsps { get; set; } = null!;
        public virtual DbSet<Order> Orders { get; set; } = null!;
        public virtual DbSet<PriceList> PriceLists { get; set; } = null!;
        public virtual DbSet<RatingsFeedback> RatingsFeedbacks { get; set; } = null!;
        public virtual DbSet<Route> Routes { get; set; } = null!;
        public virtual DbSet<Shipment> Shipments { get; set; } = null!;
        public virtual DbSet<Transaction> Transactions { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=(local);Database= KoiDeliveryDB;Uid=sa;Pwd=admin12345;TrustServerCertificate=True;");
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
                    .HasConstraintName("FK__Blogs__AuthorID__75A278F5");

                entity.HasOne(d => d.PriceList)
                    .WithMany(p => p.Blogs)
                    .HasForeignKey(d => d.PriceListId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK__Blogs__PriceList__76969D2E");
            });

            modelBuilder.Entity<CustomerProfile>(entity =>
            {
                entity.HasKey(e => e.ProfileId)
                    .HasName("PK__Customer__290C8884D738E605");

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
                    .HasConstraintName("FK__CustomerP__Custo__778AC167");
            });

            modelBuilder.Entity<Gsp>(entity =>
            {
                entity.ToTable("GSP");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Freg).HasColumnName("freg");

                entity.Property(e => e.Index).HasColumnName("index");

                entity.Property(e => e.Label).HasColumnName("label");

                entity.Property(e => e.PEnd)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("pEnd");

                entity.Property(e => e.PStart)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("pStart");

                entity.Property(e => e.PTerm)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("pTerm");

                entity.Property(e => e.PreRouted)
                    .HasMaxLength(1000)
                    .HasColumnName("preRouted");

                entity.Property(e => e.Regions)
                    .HasMaxLength(1000)
                    .HasColumnName("regions");

                entity.Property(e => e.VehicleId)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("vehicleID");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.Property(e => e.OrderId).HasColumnName("OrderID");

                entity.Property(e => e.AdditionalServices).HasMaxLength(255);

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CustomerId).HasColumnName("CustomerID");

                entity.Property(e => e.DateShip).HasColumnType("datetime");

                entity.Property(e => e.Destination).HasMaxLength(255);

                entity.Property(e => e.FishType).HasMaxLength(250);

                entity.Property(e => e.NameUserGet).HasMaxLength(50);

                entity.Property(e => e.Origin).HasMaxLength(255);

                entity.Property(e => e.PaymentMethod).HasMaxLength(50);

                entity.Property(e => e.PhoneContact).HasMaxLength(15);

                entity.Property(e => e.ShippingMethod).HasMaxLength(100);

                entity.Property(e => e.Status)
                    .HasMaxLength(50)
                    .HasDefaultValueSql("('Pending')");

                entity.Property(e => e.TotalPrice).HasColumnType("decimal(13, 0)");

                entity.Property(e => e.TotalWeight).HasColumnType("decimal(18, 0)");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK__Orders__Customer__787EE5A0");
            });

            modelBuilder.Entity<PriceList>(entity =>
            {
                entity.HasKey(e => e.PriceId)
                    .HasName("PK__PriceLis__4957584F8015DBAE");

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
                    .HasName("PK__RatingsF__6A4BEDF667F8AC4A");

                entity.Property(e => e.FeedbackId).HasColumnName("FeedbackID");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Feedback).HasMaxLength(1000);

                entity.Property(e => e.OrderId).HasColumnName("OrderID");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.RatingsFeedbacks)
                    .HasForeignKey(d => d.OrderId)
                    .HasConstraintName("FK__RatingsFe__Order__797309D9");
            });

            modelBuilder.Entity<Route>(entity =>
            {
                entity.HasKey(e => e.RoutedId);

                entity.ToTable("Route");

                entity.Property(e => e.RoutedId).HasColumnName("RoutedID");

                entity.Property(e => e.Adress).HasMaxLength(50);

                entity.Property(e => e.DateSetting).HasColumnType("date");

                entity.Property(e => e.DateUpdate).HasColumnType("date");

                entity.Property(e => e.DestinationLatitude).HasColumnName("destinationLatitude");

                entity.Property(e => e.DestinationLongitude).HasColumnName("destinationLongitude");

                entity.Property(e => e.Notice).HasMaxLength(250);

                entity.Property(e => e.Price).HasColumnType("decimal(13, 0)");

                entity.Property(e => e.ShipmentId).HasColumnName("ShipmentID");

                entity.Property(e => e.SourceLatitude).HasColumnName("sourceLatitude");

                entity.Property(e => e.SourceLongitude).HasColumnName("sourceLongitude");

                entity.HasOne(d => d.Shipment)
                    .WithMany(p => p.Routes)
                    .HasForeignKey(d => d.ShipmentId)
                    .HasConstraintName("FK_Route_Shipments");
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

                entity.Property(e => e.TotalPrice).HasColumnType("decimal(13, 0)");

                entity.HasOne(d => d.DeliveringStaff)
                    .WithMany(p => p.ShipmentDeliveringStaffs)
                    .HasForeignKey(d => d.DeliveringStaffId)
                    .HasConstraintName("FK__Shipments__Deliv__7B5B524B");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.Shipments)
                    .HasForeignKey(d => d.OrderId)
                    .HasConstraintName("FK__Shipments__Order__7C4F7684");

                entity.HasOne(d => d.SalesStaff)
                    .WithMany(p => p.ShipmentSalesStaffs)
                    .HasForeignKey(d => d.SalesStaffId)
                    .HasConstraintName("FK__Shipments__Sales__7D439ABD");
            });

            modelBuilder.Entity<Transaction>(entity =>
            {
                entity.HasKey(e => e.PaymentId)
                    .HasName("PK_Payment");

                entity.ToTable("Transaction");

                entity.Property(e => e.PaymentId).HasColumnName("PaymentID");

                entity.Property(e => e.OrderId).HasColumnName("OrderID");

                entity.Property(e => e.PayDate).HasColumnType("datetime");

                entity.Property(e => e.PaymentMethod).HasMaxLength(100);

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.Transactions)
                    .HasForeignKey(d => d.OrderId)
                    .HasConstraintName("FK_Transaction_Orders");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasIndex(e => e.Email, "UQ__Users__A9D10534D2ED00FB")
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
