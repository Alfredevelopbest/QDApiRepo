using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace QD_API.Models;

public partial class QueenDreamsDatabaseContext : DbContext
{
    public QueenDreamsDatabaseContext()
    {
    }

    public QueenDreamsDatabaseContext(DbContextOptions<QueenDreamsDatabaseContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<CategoryGetList> CategoryGetLists { get; set; }

    public virtual DbSet<City> Cities { get; set; }

    public virtual DbSet<CityGetList> CityGetLists { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<CustomerGetList> CustomerGetLists { get; set; }

    public virtual DbSet<DetailInvoice> DetailInvoices { get; set; }

    public virtual DbSet<DocumentGetList> DocumentGetLists { get; set; }

    public virtual DbSet<DocumentType> DocumentTypes { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<ProductImage> ProductImages { get; set; }

    public virtual DbSet<ProductImageReferenceGetList> ProductImageReferenceGetLists { get; set; }

    public virtual DbSet<SaleInvoice> SaleInvoices { get; set; }

    public virtual DbSet<StandardSize> StandardSizes { get; set; }

    public virtual DbSet<StandardSizeGetList> StandardSizeGetLists { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("DefaultConnection");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("category_pkey");

            entity.ToTable("category");

            entity.HasIndex(e => e.CategoryName, "category_category_name_key").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CategoryName)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("category_name");
        });

        modelBuilder.Entity<CategoryGetList>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("category_get_list");

            entity.Property(e => e.CategoryName)
                .HasMaxLength(50)
                .HasColumnName("category_name");
            entity.Property(e => e.Id).HasColumnName("id");
        });

        modelBuilder.Entity<City>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("city_pkey");

            entity.ToTable("city");

            entity.HasIndex(e => e.CityName, "city_city_name_key").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CityName)
                .IsRequired()
                .HasMaxLength(40)
                .HasColumnName("city_name");
        });

        modelBuilder.Entity<CityGetList>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("city_get_list");

            entity.Property(e => e.CityName)
                .HasMaxLength(40)
                .HasColumnName("city_name");
            entity.Property(e => e.Id).HasColumnName("id");
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("custom_pkey");

            entity.ToTable("customer");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("nextval('custom_id_seq'::regclass)")
                .HasColumnName("id");
            entity.Property(e => e.Address)
                .HasMaxLength(50)
                .HasColumnName("address");
            entity.Property(e => e.CityId)
                .HasDefaultValueSql("nextval('custom_city_id_seq'::regclass)")
                .HasColumnName("city_id");
            entity.Property(e => e.CustomerLastname)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("customer_lastname");
            entity.Property(e => e.CustomerName)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("customer_name");
            entity.Property(e => e.DocumentNumber)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("document_number");
            entity.Property(e => e.DocumentTypeId)
                .HasDefaultValueSql("nextval('custom_document_type_id_seq'::regclass)")
                .HasColumnName("document_type_id");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .HasColumnName("email");
            entity.Property(e => e.TelephoneNumber)
                .IsRequired()
                .HasMaxLength(30)
                .HasColumnName("telephone_number");

            entity.HasOne(d => d.City).WithMany(p => p.Customers)
                .HasForeignKey(d => d.CityId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_city_id");

            entity.HasOne(d => d.DocumentType).WithMany(p => p.Customers)
                .HasForeignKey(d => d.DocumentTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_document_type");
        });

        modelBuilder.Entity<CustomerGetList>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("customer_get_list");

            entity.Property(e => e.Address)
                .HasMaxLength(50)
                .HasColumnName("address");
            entity.Property(e => e.CityId).HasColumnName("city_id");
            entity.Property(e => e.CustomerLastname)
                .HasMaxLength(50)
                .HasColumnName("customer_lastname");
            entity.Property(e => e.CustomerName)
                .HasMaxLength(50)
                .HasColumnName("customer_name");
            entity.Property(e => e.DocumentNumber)
                .HasMaxLength(50)
                .HasColumnName("document_number");
            entity.Property(e => e.DocumentTypeId).HasColumnName("document_type_id");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .HasColumnName("email");
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.TelephoneNumber)
                .HasMaxLength(30)
                .HasColumnName("telephone_number");
        });

        modelBuilder.Entity<DetailInvoice>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("detail_invoice_pkey");

            entity.ToTable("detail_invoice");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ProductId)
                .ValueGeneratedOnAdd()
                .HasColumnName("product_id");
            entity.Property(e => e.TotalPriceInvoice)
                .HasPrecision(19)
                .HasColumnName("total_price_invoice");
            entity.Property(e => e.Units).HasColumnName("units");

            entity.HasOne(d => d.Product).WithMany(p => p.DetailInvoices)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_product_id");
        });

        modelBuilder.Entity<DocumentGetList>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("document_get_list");

            entity.Property(e => e.DocumentName)
                .HasMaxLength(40)
                .HasColumnName("document_name");
            entity.Property(e => e.Id).HasColumnName("id");
        });

        modelBuilder.Entity<DocumentType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("document_type_pkey");

            entity.ToTable("document_type");

            entity.HasIndex(e => e.DocumentName, "document_type_document_name_key").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.DocumentName)
                .IsRequired()
                .HasMaxLength(40)
                .HasColumnName("document_name");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("product_pkey");

            entity.ToTable("product");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CategoryId)
                .ValueGeneratedOnAdd()
                .HasColumnName("category_id");
            entity.Property(e => e.ProductImageId)
                .ValueGeneratedOnAdd()
                .HasColumnName("product_image_id");
            entity.Property(e => e.ProductName)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("product_name");
            entity.Property(e => e.ReferenceCode)
                .IsRequired()
                .HasMaxLength(15)
                .HasColumnName("reference_code");
            entity.Property(e => e.SaleProductPrice)
                .HasPrecision(19)
                .HasColumnName("sale_product_price");
            entity.Property(e => e.SizeStandardId)
                .ValueGeneratedOnAdd()
                .HasColumnName("size_standard_id");

            entity.HasOne(d => d.Category).WithMany(p => p.Products)
                .HasForeignKey(d => d.CategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_category_id");

            entity.HasOne(d => d.ProductImage).WithMany(p => p.Products)
                .HasForeignKey(d => d.ProductImageId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_product_image");

            entity.HasOne(d => d.SizeStandard).WithMany(p => p.Products)
                .HasForeignKey(d => d.SizeStandardId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_size_standard");
        });

        modelBuilder.Entity<ProductImage>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("product_image_pkey");

            entity.ToTable("product_image");

            entity.HasIndex(e => e.IdIdentifier, "product_image_id_identifier_key").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.IdIdentifier)
                .HasMaxLength(50)
                .HasColumnName("id_identifier");
            entity.Property(e => e.ImageName)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("image_name");
        });

        modelBuilder.Entity<ProductImageReferenceGetList>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("product_image_reference_get_list");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.IdIdentifier)
                .HasMaxLength(50)
                .HasColumnName("id_identifier");
            entity.Property(e => e.ImageName)
                .HasMaxLength(50)
                .HasColumnName("image_name");
        });

        modelBuilder.Entity<SaleInvoice>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("sale_invoice_pkey");

            entity.ToTable("sale_invoice");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CustomId)
                .ValueGeneratedOnAdd()
                .HasColumnName("custom_id");
            entity.Property(e => e.DeliveryAddress)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("delivery_address");
            entity.Property(e => e.DeliveryDate).HasColumnName("delivery_date");
            entity.Property(e => e.DetailInvoiceId)
                .ValueGeneratedOnAdd()
                .HasColumnName("detail_invoice_id");
            entity.Property(e => e.SaleDate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("sale_date");

            entity.HasOne(d => d.Custom).WithMany(p => p.SaleInvoices)
                .HasForeignKey(d => d.CustomId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_custom_id");

            entity.HasOne(d => d.DetailInvoice).WithMany(p => p.SaleInvoices)
                .HasForeignKey(d => d.DetailInvoiceId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_detail_invoice");
        });

        modelBuilder.Entity<StandardSize>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("standard_size_pkey");

            entity.ToTable("standard_size");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.DimensionLenght)
                .HasPrecision(19)
                .HasColumnName("dimension_lenght");
            entity.Property(e => e.SizeName)
                .IsRequired()
                .HasMaxLength(30)
                .HasColumnName("size_name");
        });

        modelBuilder.Entity<StandardSizeGetList>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("standard_size_get_list");

            entity.Property(e => e.DimensionLenght)
                .HasPrecision(19)
                .HasColumnName("dimension_lenght");
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.SizeName)
                .HasMaxLength(30)
                .HasColumnName("size_name");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
