using System;
using LeDucTai_206.Models;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace LeDucTai_206.Data
{
    public partial class csdl_thuephongContext : DbContext
    {
        public csdl_thuephongContext()
        {
        }

        public csdl_thuephongContext(DbContextOptions<csdl_thuephongContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Chitietphieuthue> Chitietphieuthues { get; set; }
        public virtual DbSet<Khachthue> Khachthues { get; set; }
        public virtual DbSet<Loaiphong> Loaiphongs { get; set; }
        public virtual DbSet<Phieuthue> Phieuthues { get; set; }
        public virtual DbSet<Phong> Phongs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=ASUS;Database=ThuePhong_KT;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Chitietphieuthue>(entity =>
            {
                entity.HasKey(e => new { e.Sopt, e.Maphong });

                entity.ToTable("chitietphieuthue");

                entity.Property(e => e.Sopt)
                    .HasMaxLength(50)
                    .HasColumnName("sopt");

                entity.Property(e => e.Maphong)
                    .HasMaxLength(50)
                    .HasColumnName("maphong");

                entity.Property(e => e.Dongia).HasColumnName("dongia");

                entity.Property(e => e.Songaythue).HasColumnName("songaythue");

                entity.HasOne(d => d.MaphongNavigation)
                    .WithMany(p => p.Chitietphieuthues)
                    .HasForeignKey(d => d.Maphong)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_chitietphieuthue_phong");

                entity.HasOne(d => d.SoptNavigation)
                    .WithMany(p => p.Chitietphieuthues)
                    .HasForeignKey(d => d.Sopt)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_chitietphieuthue_phieuthue");
            });

            modelBuilder.Entity<Khachthue>(entity =>
            {
                entity.HasKey(e => e.Makh);

                entity.ToTable("khachthue");

                entity.Property(e => e.Makh)
                    .HasMaxLength(50)
                    .HasColumnName("makh");

                entity.Property(e => e.Socmnd)
                    .HasMaxLength(50)
                    .HasColumnName("socmnd");

                entity.Property(e => e.Sodienthoai)
                    .HasMaxLength(50)
                    .HasColumnName("sodienthoai");

                entity.Property(e => e.Tenkh)
                    .HasMaxLength(50)
                    .HasColumnName("tenkh");
            });

            modelBuilder.Entity<Loaiphong>(entity =>
            {
                entity.HasKey(e => e.Maloai);

                entity.ToTable("loaiphong");

                entity.Property(e => e.Maloai)
                    .HasMaxLength(50)
                    .HasColumnName("maloai");

                entity.Property(e => e.Dongia).HasColumnName("dongia");

                entity.Property(e => e.Songuoi).HasColumnName("songuoi");
            });

            modelBuilder.Entity<Phieuthue>(entity =>
            {
                entity.HasKey(e => e.Sopt);

                entity.ToTable("phieuthue");

                entity.Property(e => e.Sopt)
                    .HasMaxLength(50)
                    .HasColumnName("sopt");

                entity.Property(e => e.Makh)
                    .HasMaxLength(50)
                    .HasColumnName("makh");

                entity.Property(e => e.Ngaythue)
                    .HasColumnType("date")
                    .HasColumnName("ngaythue");

                entity.HasOne(d => d.MakhNavigation)
                    .WithMany(p => p.Phieuthues)
                    .HasForeignKey(d => d.Makh)
                    .HasConstraintName("FK_phieuthue_khachthue");
            });

            modelBuilder.Entity<Phong>(entity =>
            {
                entity.HasKey(e => e.Maphong);

                entity.ToTable("phong");

                entity.Property(e => e.Maphong)
                    .HasMaxLength(50)
                    .HasColumnName("maphong");

                entity.Property(e => e.Maloai)
                    .HasMaxLength(50)
                    .HasColumnName("maloai");

                entity.Property(e => e.Tinhtrang).HasColumnName("tinhtrang");

                entity.HasOne(d => d.MaloaiNavigation)
                    .WithMany(p => p.Phongs)
                    .HasForeignKey(d => d.Maloai)
                    .HasConstraintName("FK_phong_loaiphong");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
