using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WebApplication1.Models
{
    public partial class KalbeContext : DbContext
    {
        public KalbeContext()
        {
        }

        public KalbeContext(DbContextOptions<KalbeContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Customer> Customer { get; set; }
        public virtual DbSet<Penjualan> Penjualan { get; set; }
        public virtual DbSet<Product> Product { get; set; }        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasKey(e => e.IntCustomerId);

                entity.Property(e => e.IntCustomerId).HasColumnName("intCustomerID");

                entity.Property(e => e.BitGender).HasColumnName("bitGender");

                entity.Property(e => e.DtmBirthDate)
                    .HasColumnName("dtmBirthDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.Inserted).HasColumnType("datetime");

                entity.Property(e => e.TxtCustomerAddress)
                    .HasColumnName("txtCustomerAddress")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.TxtCustomerName)
                    .HasColumnName("txtCustomerName")
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Penjualan>(entity =>
            {
                entity.HasKey(e => e.IntSalesOrderId);

                entity.Property(e => e.IntSalesOrderId).HasColumnName("intSalesOrderID");

                entity.Property(e => e.DtSalesOrder)
                    .HasColumnName("dtSalesOrder")
                    .HasColumnType("datetime");

                entity.Property(e => e.IntCustomerId).HasColumnName("intCustomerID");

                entity.Property(e => e.IntProductId).HasColumnName("intProductID");

                entity.Property(e => e.IntQty).HasColumnName("intQty");

                entity.HasOne(d => d.IntCustomer)
                    .WithMany(p => p.Penjualan)
                    .HasForeignKey(d => d.IntCustomerId)
                    .HasConstraintName("FK_Penjualan_Customer");

                entity.HasOne(d => d.IntProduct)
                    .WithMany(p => p.Penjualan)
                    .HasForeignKey(d => d.IntProductId)
                    .HasConstraintName("FK_Penjualan_Product");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(e => e.IntProductId);

                entity.Property(e => e.IntProductId).HasColumnName("intProductID");

                entity.Property(e => e.DecPrice)
                    .HasColumnName("decPrice")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.DtInserted)
                    .HasColumnName("dtInserted")
                    .HasColumnType("datetime");

                entity.Property(e => e.IntQty).HasColumnName("intQty");

                entity.Property(e => e.TxtProductCode)
                    .HasColumnName("txtProductCode")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.TxtProductName)
                    .HasColumnName("txtProductName")
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });
        }
    }
}
