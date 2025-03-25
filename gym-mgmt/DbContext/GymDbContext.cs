using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace GymDbContext;

public partial class GymDbContext : DbContext
{
    public GymDbContext(DbContextOptions<GymDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Member> Members { get; set; }

    public virtual DbSet<MemberCheckIn> MemberCheckIns { get; set; }

    public virtual DbSet<MemberProduct> MemberProducts { get; set; }

    public virtual DbSet<OnlineProduct> OnlineProducts { get; set; }

    public virtual DbSet<PayType> PayTypes { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<ProductType> ProductTypes { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Member>(entity =>
        {
            entity.HasKey(e => e.Account);

            entity.ToTable("Member");

            entity.Property(e => e.Account)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Address).HasMaxLength(2048);
            entity.Property(e => e.Barcode)
                .HasMaxLength(8)
                .IsUnicode(false);
            entity.Property(e => e.Email)
                .HasMaxLength(256)
                .IsUnicode(false);
            entity.Property(e => e.EmgContact).HasMaxLength(256);
            entity.Property(e => e.EmgContactTel)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Gender)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.Name).HasMaxLength(256);
        });

        modelBuilder.Entity<MemberCheckIn>(entity =>
        {
            entity.ToTable("MemberCheckIn");

            entity.Property(e => e.EnterTime).HasColumnType("datetime");
            entity.Property(e => e.ExitTime).HasColumnType("datetime");
            entity.Property(e => e.MemberAccount)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.MemberAccountNavigation).WithMany(p => p.MemberCheckIns)
                .HasForeignKey(d => d.MemberAccount)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_MemberCheckIn_Member");
        });

        modelBuilder.Entity<MemberProduct>(entity =>
        {
            entity.ToTable("MemberProduct");

            entity.Property(e => e.MemberAccount)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.MemberAccountNavigation).WithMany(p => p.MemberProducts)
                .HasForeignKey(d => d.MemberAccount)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_MemberProduct_Member");

            entity.HasOne(d => d.Product).WithMany(p => p.MemberProducts)
                .HasForeignKey(d => d.ProductID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_MemberProduct_Product");
        });

        modelBuilder.Entity<OnlineProduct>(entity =>
        {
            entity.ToTable("OnlineProduct");
        });

        modelBuilder.Entity<PayType>(entity =>
        {
            entity.ToTable("PayType");

            entity.Property(e => e.Description).HasMaxLength(256);
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.ToTable("Product");

            entity.Property(e => e.Description).HasMaxLength(2048);

            entity.HasOne(d => d.PayTypeNavigation).WithMany(p => p.Products)
                .HasForeignKey(d => d.PayType)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Product_PayType");

            entity.HasOne(d => d.ProductTypeNavigation).WithMany(p => p.Products)
                .HasForeignKey(d => d.ProductType)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Product_ProductType");
        });

        modelBuilder.Entity<ProductType>(entity =>
        {
            entity.ToTable("ProductType");

            entity.Property(e => e.Abbr).HasMaxLength(50);
            entity.Property(e => e.Description).HasMaxLength(256);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
