using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace CasoPractico2_MacoteloYaritza_LopezJoselyn.Models;

public partial class TechstoreSaContext : DbContext
{
    public TechstoreSaContext()
    {
    }

    public TechstoreSaContext(DbContextOptions<TechstoreSaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<CategoriasProducto> CategoriasProductos { get; set; }

    public virtual DbSet<Cliente> Clientes { get; set; }

    public virtual DbSet<Marca> Marcas { get; set; }

    public virtual DbSet<Producto> Productos { get; set; }

    public virtual DbSet<Vendedore> Vendedores { get; set; }

    public virtual DbSet<Venta> Ventas { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CategoriasProducto>(entity =>
        {
            entity.HasKey(e => e.NombreCategoria).HasName("PK__CATEGORI__01C8327779225234");

            entity.ToTable("CATEGORIAS_PRODUCTOS");

            entity.Property(e => e.NombreCategoria)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("NOMBRE_CATEGORIA");
        });

        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.IdCliente).HasName("PK__CLIENTES__23A34130081A4DB4");

            entity.ToTable("CLIENTES");

            entity.Property(e => e.IdCliente)
                .ValueGeneratedNever()
                .HasColumnName("ID_CLIENTE");
            entity.Property(e => e.Apellido)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("APELLIDO");
            entity.Property(e => e.CorreoElectronico)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("CORREO_ELECTRONICO");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("NOMBRE");
        });

        modelBuilder.Entity<Marca>(entity =>
        {
            entity.HasKey(e => e.NombreMarca).HasName("PK__MARCAS__DF2EB891B7ADF17F");

            entity.ToTable("MARCAS");

            entity.Property(e => e.NombreMarca)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("NOMBRE_MARCA");
        });

        modelBuilder.Entity<Producto>(entity =>
        {
            entity.HasKey(e => e.NombreProducto).HasName("PK__PRODUCTO__858319A57BB53036");

            entity.ToTable("PRODUCTOS");

            entity.Property(e => e.NombreProducto)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("NOMBRE_PRODUCTO");
            entity.Property(e => e.NombreCategoria)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("NOMBRE_CATEGORIA");
            entity.Property(e => e.NombreMarca)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("NOMBRE_MARCA");
            entity.Property(e => e.Precio)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("PRECIO");

            entity.HasOne(d => d.NombreCategoriaNavigation).WithMany(p => p.Productos)
                .HasForeignKey(d => d.NombreCategoria)
                .HasConstraintName("FK_PRODUCTOS_CATEGORIA");

            entity.HasOne(d => d.NombreMarcaNavigation).WithMany(p => p.Productos)
                .HasForeignKey(d => d.NombreMarca)
                .HasConstraintName("FK_PRODUCTOS_MARCA");
        });

        modelBuilder.Entity<Vendedore>(entity =>
        {
            entity.HasKey(e => e.NombreVendedor).HasName("PK__VENDEDOR__93A4D418F25FBF68");

            entity.ToTable("VENDEDORES");

            entity.Property(e => e.NombreVendedor)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("NOMBRE_VENDEDOR");
        });

        modelBuilder.Entity<Venta>(entity =>
        {
            entity.HasKey(e => e.IdVenta).HasName("PK__VENTAS__F3B6C1B4DA1F3786");

            entity.ToTable("VENTAS");

            entity.Property(e => e.IdVenta)
                .ValueGeneratedNever()
                .HasColumnName("ID_VENTA");
            entity.Property(e => e.Cantidad).HasColumnName("CANTIDAD");
            entity.Property(e => e.FechaVenta).HasColumnName("FECHA_VENTA");
            entity.Property(e => e.IdCliente).HasColumnName("ID_CLIENTE");
            entity.Property(e => e.NombreProducto)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("NOMBRE_PRODUCTO");
            entity.Property(e => e.NombreVendedor)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("NOMBRE_VENDEDOR");

            entity.HasOne(d => d.IdClienteNavigation).WithMany(p => p.Venta)
                .HasForeignKey(d => d.IdCliente)
                .HasConstraintName("FK_VENTA_CLIENTES");

            entity.HasOne(d => d.NombreProductoNavigation).WithMany(p => p.Venta)
                .HasForeignKey(d => d.NombreProducto)
                .HasConstraintName("FK_VENTA_PRODUCTOS");

            entity.HasOne(d => d.NombreVendedorNavigation).WithMany(p => p.Venta)
                .HasForeignKey(d => d.NombreVendedor)
                .HasConstraintName("FK_VENTA_VENDEDORES");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
