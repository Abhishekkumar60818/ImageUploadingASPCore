using Microsoft.EntityFrameworkCore;

namespace ImageUploadingASPCore.Models;

public partial class ImageDbContext : DbContext
{
    public ImageDbContext()
    {
    }

    public ImageDbContext(DbContextOptions<ImageDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Product> Products { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        //if (!optionsBuilder.IsConfigured)
        //{

        //}



    }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Product__3214EC072E885942");

            entity.ToTable("Product");

            entity.Property(e => e.ImagePath)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("image_path");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Price).HasColumnName("price");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
