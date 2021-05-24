using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace CORE.Models
{
    public partial class COREContext : DbContext
    {
        public COREContext()
        {
        }

        public COREContext(DbContextOptions<COREContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<Permission> Permissions { get; set; }
        public virtual DbSet<RefreshToken> RefreshTokens { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<User> Users { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Department>(entity =>
            {
                entity.ToTable("Department");

                entity.Property(e => e.DepartmentName).HasMaxLength(255);
            });

            modelBuilder.Entity<Permission>(entity =>
            {
                entity.ToTable("Permission");

                entity.Property(e => e.PermissionId).HasColumnName("PermissionID");

                entity.Property(e => e.PermissionName).HasMaxLength(255);
            });

            modelBuilder.Entity<RefreshToken>(entity =>
            {
                entity.HasKey(e => e.TokenId);

                entity.ToTable("RefreshToken");

                entity.Property(e => e.ExpiryDate).HasColumnType("datetime");

                entity.Property(e => e.Token)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.RefreshTokens)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__RefreshTo__Expir__36B12243");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("Role");

                entity.Property(e => e.CreatedAt)
                    .IsRequired()
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.Property(e => e.CreatedBy).HasMaxLength(100);

                entity.Property(e => e.RoleName)
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User");

                entity.Property(e => e.CreatedAt)
                    .IsRequired()
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.Property(e => e.CreatedBy).HasMaxLength(255);

                entity.Property(e => e.FirstName).HasMaxLength(255);

                entity.Property(e => e.JobTitle).HasMaxLength(255);

                entity.Property(e => e.LastName).HasMaxLength(255);

                entity.Property(e => e.UserApprovalStatus).HasMaxLength(100);

                entity.Property(e => e.UserBiography).HasMaxLength(255);

                entity.Property(e => e.UserEmail).HasMaxLength(255);

                entity.Property(e => e.UserName).HasMaxLength(255);

                entity.Property(e => e.UserPassword).HasMaxLength(255);

                entity.Property(e => e.UserProfilePic).HasMaxLength(255);

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.DepartmentId)
                    .HasConstraintName("FK__User__Department__2B3F6F97");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK__User__RoleId__2A4B4B5E");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
