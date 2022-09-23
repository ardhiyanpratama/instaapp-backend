using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace instaapp_backend.Models
{
    public partial class InstaContext : DbContext
    {
        public InstaContext()
        {
        }

        public InstaContext(DbContextOptions<InstaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Like> Likes { get; set; } = null!;
        public virtual DbSet<Posting> Postings { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql("Name=DefaultConnection");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Like>(entity =>
            {
                entity.ToTable("like");

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("id")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("'-infinity'::timestamp with time zone");

                entity.Property(e => e.PostingId).HasColumnName("posting_id");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updated_at")
                    .HasDefaultValueSql("'-infinity'::timestamp with time zone");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.Property(e => e.UserLike).HasColumnName("user_like");

                entity.Property(e => e.Uuid).HasColumnName("uuid");

                entity.HasOne(d => d.IdNavigation)
                    .WithOne(p => p.Like)
                    .HasForeignKey<Like>(d => d.Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("like_fk_1");

                entity.HasOne(d => d.Id1)
                    .WithOne(p => p.Like)
                    .HasForeignKey<Like>(d => d.Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("like_fk");
            });

            modelBuilder.Entity<Posting>(entity =>
            {
                entity.ToTable("posting");

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("id")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("'-infinity'::timestamp with time zone");

                entity.Property(e => e.Image).HasColumnName("image");

                entity.Property(e => e.Posts).HasColumnName("posts");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updated_at")
                    .HasDefaultValueSql("'-infinity'::timestamp with time zone");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.Property(e => e.Uuid).HasColumnName("uuid");

                entity.HasOne(d => d.IdNavigation)
                    .WithOne(p => p.Posting)
                    .HasForeignKey<Posting>(d => d.Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("posting_fk");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("user");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("'-infinity'::timestamp with time zone");

                entity.Property(e => e.Fullname).HasColumnName("fullname");

                entity.Property(e => e.Iscomment).HasColumnName("iscomment");

                entity.Property(e => e.Islike).HasColumnName("islike");

                entity.Property(e => e.Ispost).HasColumnName("ispost");

                entity.Property(e => e.MobileNumber)
                    .HasMaxLength(16)
                    .HasColumnName("mobile_number")
                    .HasDefaultValueSql("16")
                    .IsFixedLength();

                entity.Property(e => e.Password).HasColumnName("password");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updated_at")
                    .HasDefaultValueSql("'-infinity'::timestamp with time zone");

                entity.Property(e => e.Username).HasColumnName("username");

                entity.Property(e => e.Uuid).HasColumnName("uuid");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
