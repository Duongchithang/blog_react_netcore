using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace blog_backend.Models;

public partial class BlogContext : DbContext
{
    public BlogContext()
    {
    }

    public BlogContext(DbContextOptions<BlogContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AspNetRole> AspNetRoles { get; set; }

    public virtual DbSet<AspNetRoleClaim> AspNetRoleClaims { get; set; }

    public virtual DbSet<AspNetUser> AspNetUsers { get; set; }

    public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; }

    public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; }

    public virtual DbSet<AspNetUserToken> AspNetUserTokens { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Comment> Comments { get; set; }

    public virtual DbSet<InCart> InCarts { get; set; }

    public virtual DbSet<Permision> Permisions { get; set; }

    public virtual DbSet<Post> Posts { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<Review> Reviews { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-54Q93JS\\SQLEXPRESS;Database=Blog;User Id=sa;Password=123;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AspNetRole>(entity =>
        {
            entity.HasIndex(e => e.NormalizedName, "RoleNameIndex")
                .IsUnique()
                .HasFilter("([NormalizedName] IS NOT NULL)");

            entity.Property(e => e.Name).HasMaxLength(256);
            entity.Property(e => e.NormalizedName).HasMaxLength(256);
        });

        modelBuilder.Entity<AspNetRoleClaim>(entity =>
        {
            entity.HasIndex(e => e.RoleId, "IX_AspNetRoleClaims_RoleId");

            entity.HasOne(d => d.Role).WithMany(p => p.AspNetRoleClaims).HasForeignKey(d => d.RoleId);
        });

        modelBuilder.Entity<AspNetUser>(entity =>
        {
            entity.HasIndex(e => e.NormalizedEmail, "EmailIndex");

            entity.HasIndex(e => e.NormalizedUserName, "UserNameIndex")
                .IsUnique()
                .HasFilter("([NormalizedUserName] IS NOT NULL)");

            entity.Property(e => e.Email).HasMaxLength(256);
            entity.Property(e => e.NormalizedEmail).HasMaxLength(256);
            entity.Property(e => e.NormalizedUserName).HasMaxLength(256);
            entity.Property(e => e.UserName).HasMaxLength(256);

            entity.HasMany(d => d.Roles).WithMany(p => p.Users)
                .UsingEntity<Dictionary<string, object>>(
                    "AspNetUserRole",
                    r => r.HasOne<AspNetRole>().WithMany().HasForeignKey("RoleId"),
                    l => l.HasOne<AspNetUser>().WithMany().HasForeignKey("UserId"),
                    j =>
                    {
                        j.HasKey("UserId", "RoleId");
                        j.ToTable("AspNetUserRoles");
                        j.HasIndex(new[] { "RoleId" }, "IX_AspNetUserRoles_RoleId");
                    });
        });

        modelBuilder.Entity<AspNetUserClaim>(entity =>
        {
            entity.HasIndex(e => e.UserId, "IX_AspNetUserClaims_UserId");

            entity.HasOne(d => d.User).WithMany(p => p.AspNetUserClaims).HasForeignKey(d => d.UserId);
        });

        modelBuilder.Entity<AspNetUserLogin>(entity =>
        {
            entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });

            entity.HasIndex(e => e.UserId, "IX_AspNetUserLogins_UserId");

            entity.Property(e => e.LoginProvider).HasMaxLength(128);
            entity.Property(e => e.ProviderKey).HasMaxLength(128);

            entity.HasOne(d => d.User).WithMany(p => p.AspNetUserLogins).HasForeignKey(d => d.UserId);
        });

        modelBuilder.Entity<AspNetUserToken>(entity =>
        {
            entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name });

            entity.Property(e => e.LoginProvider).HasMaxLength(128);
            entity.Property(e => e.Name).HasMaxLength(128);

            entity.HasOne(d => d.User).WithMany(p => p.AspNetUserTokens).HasForeignKey(d => d.UserId);
        });

        modelBuilder.Entity<Comment>(entity =>
        {
            entity.HasKey(e => e.IdComment);

            entity.ToTable("comment");

            entity.Property(e => e.IdComment)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("id_comment");
            entity.Property(e => e.Comments)
                .HasMaxLength(250)
                .HasColumnName("comments");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.IdPost)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("id_post");

            entity.HasOne(d => d.IdPostNavigation).WithMany(p => p.Comments)
                .HasForeignKey(d => d.IdPost)
                .HasConstraintName("FK_comment_post");
        });

        modelBuilder.Entity<InCart>(entity =>
        {
            entity.HasKey(e => new { e.Id, e.ProductId, e.UserId });

            entity.HasIndex(e => e.ProductId, "IX_InCarts_ProductId");

            entity.HasIndex(e => e.UserId, "IX_InCarts_UserId");

            entity.Property(e => e.Id).ValueGeneratedOnAdd();

            entity.HasOne(d => d.Product).WithMany(p => p.InCarts).HasForeignKey(d => d.ProductId);

            entity.HasOne(d => d.User).WithMany(p => p.InCarts).HasForeignKey(d => d.UserId);
        });

        modelBuilder.Entity<Permision>(entity =>
        {
            entity.HasKey(e => e.IdPermision);

            entity.ToTable("permision");

            entity.Property(e => e.IdPermision)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("id_permision");
            entity.Property(e => e.Create).HasColumnName("create");
            entity.Property(e => e.Delete).HasColumnName("delete");
            entity.Property(e => e.IdUser)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("id_user");
            entity.Property(e => e.Read).HasColumnName("read");
            entity.Property(e => e.Update).HasColumnName("update");

            entity.HasOne(d => d.IdUserNavigation).WithMany(p => p.Permisions)
                .HasForeignKey(d => d.IdUser)
                .HasConstraintName("FK_permision_user");
        });

        modelBuilder.Entity<Post>(entity =>
        {
            entity.HasKey(e => e.IdPost);

            entity.ToTable("post");

            entity.Property(e => e.IdPost)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("id_post");
            entity.Property(e => e.Category)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("category");
            entity.Property(e => e.Content)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("content");
            entity.Property(e => e.CreatedAt)
                .IsRowVersion()
                .IsConcurrencyToken()
                .HasColumnName("created_at");
            entity.Property(e => e.IdUser)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("id_user");
            entity.Property(e => e.Status).HasColumnName("status");
            entity.Property(e => e.Title)
                .HasMaxLength(250)
                .HasColumnName("title");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
            entity.Property(e => e.UrlPost)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("url_post");

            entity.HasOne(d => d.IdUserNavigation).WithMany(p => p.Posts)
                .HasForeignKey(d => d.IdUser)
                .HasConstraintName("FK_post_user");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasIndex(e => e.CategoryId, "IX_Products_CategoryId");

            entity.HasIndex(e => e.UserId, "IX_Products_UserId");

            entity.Property(e => e.Approved)
                .IsRequired()
                .HasDefaultValueSql("(CONVERT([bit],(0)))");
            entity.Property(e => e.Title).HasMaxLength(50);

            entity.HasOne(d => d.Category).WithMany(p => p.Products).HasForeignKey(d => d.CategoryId);

            entity.HasOne(d => d.User).WithMany(p => p.Products).HasForeignKey(d => d.UserId);
        });

        modelBuilder.Entity<Review>(entity =>
        {
            entity.HasIndex(e => e.ProductId, "IX_Reviews_ProductId");

            entity.HasIndex(e => e.UserId, "IX_Reviews_UserId");

            entity.HasOne(d => d.Product).WithMany(p => p.Reviews).HasForeignKey(d => d.ProductId);

            entity.HasOne(d => d.User).WithMany(p => p.Reviews).HasForeignKey(d => d.UserId);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.IdUser);

            entity.ToTable("user");

            entity.Property(e => e.IdUser)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("id_user");
            entity.Property(e => e.Avartar)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("avartar");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.Gender)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("gender");
            entity.Property(e => e.IsAdmin)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("is_admin");
            entity.Property(e => e.Password)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("password");
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("phone_number");
            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("status");
            entity.Property(e => e.Username)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("username");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
