using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DAL.DBContext;

public partial class StoreContext : DbContext
{
    public StoreContext()
    {
    }

    public StoreContext(DbContextOptions<StoreContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Color> Colors { get; set; }

    public virtual DbSet<ColorSize> ColorSizes { get; set; }

    public virtual DbSet<Manufacturer> Manufacturers { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<Size> Sizes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=HCM2-000027;Initial Catalog=QLCH;Integrated Security=True;Trust Server Certificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.CategoryId).HasName("PK__CATEGORY__23CAF1F804813552");

            entity.ToTable("CATEGORY");

            entity.Property(e => e.CategoryId)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("categoryID");
            entity.Property(e => e.CategoryName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("categoryName");
        });

        modelBuilder.Entity<Color>(entity =>
        {
            entity.HasKey(e => e.ColorId).HasName("PK__COLOR__70A64C3DB482DF7B");

            entity.ToTable("COLOR");

            entity.Property(e => e.ColorId)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("colorID");
            entity.Property(e => e.ColorName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("colorName");

            entity.HasMany(d => d.Products).WithMany(p => p.Colors)
                .UsingEntity<Dictionary<string, object>>(
                    "ProductColor",
                    r => r.HasOne<Product>().WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("fk_productcolor_product"),
                    l => l.HasOne<Color>().WithMany()
                        .HasForeignKey("ColorId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("fk_productcolor_color"),
                    j =>
                    {
                        j.HasKey("ColorId", "ProductId").HasName("PK__PRODUCT___C2774129F31A0E14");
                        j.ToTable("PRODUCT_COLOR");
                        j.IndexerProperty<string>("ColorId")
                            .HasMaxLength(20)
                            .IsUnicode(false)
                            .HasColumnName("colorID");
                        j.IndexerProperty<string>("ProductId")
                            .HasMaxLength(20)
                            .IsUnicode(false)
                            .HasColumnName("productID");
                    });
        });

        modelBuilder.Entity<ColorSize>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("COLOR_SIZE");

            entity.Property(e => e.ColorId)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("colorID");
            entity.Property(e => e.SizeId)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("sizeID");

            entity.HasOne(d => d.Color).WithMany()
                .HasForeignKey(d => d.ColorId)
                .HasConstraintName("fk_sizecolor_color");

            entity.HasOne(d => d.Size).WithMany()
                .HasForeignKey(d => d.SizeId)
                .HasConstraintName("fk_sizecolor_size");
        });

        modelBuilder.Entity<Manufacturer>(entity =>
        {
            entity.HasKey(e => e.ManufacturerId).HasName("PK__MANUFACT__02B553A9934E03A5");

            entity.ToTable("MANUFACTURER");

            entity.Property(e => e.ManufacturerId)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("manufacturerID");
            entity.Property(e => e.ManufacturerName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("manufacturerName");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.ProductId).HasName("PK__PRODUCTS__2D10D14AA5138A32");

            entity.ToTable("PRODUCTS");

            entity.Property(e => e.ProductId)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("productID");
            entity.Property(e => e.CategoryId)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("categoryID");
            entity.Property(e => e.ManufacturerId)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("manufacturerID");
            entity.Property(e => e.ProductName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("productName");
            entity.Property(e => e.Quantity).HasColumnName("quantity");
            entity.Property(e => e.SellStatus).HasColumnName("sellStatus");

            entity.HasOne(d => d.Category).WithMany(p => p.Products)
                .HasForeignKey(d => d.CategoryId)
                .HasConstraintName("fk_product_category");

            entity.HasOne(d => d.Manufacturer).WithMany(p => p.Products)
                .HasForeignKey(d => d.ManufacturerId)
                .HasConstraintName("fk_product_manufacturer");
        });

        modelBuilder.Entity<Size>(entity =>
        {
            entity.HasKey(e => e.SizeId).HasName("PK__SIZE__55B1E5773670B2A7");

            entity.ToTable("SIZE");

            entity.Property(e => e.SizeId)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("sizeID");
            entity.Property(e => e.SizeName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("sizeName");
            entity.Property(e => e.SuitableHeight).HasColumnName("suitable_height");
            entity.Property(e => e.SuitableWidth)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("suitable_width");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
