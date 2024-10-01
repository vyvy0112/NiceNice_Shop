using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace NiceNice_Shop.Data;

public partial class NiceNiceShopContext : DbContext
{
    public NiceNiceShopContext()
    {
    }

    public NiceNiceShopContext(DbContextOptions<NiceNiceShopContext> options)
        : base(options)
    {
    }

    public virtual DbSet<ChiTietHd> ChiTietHds { get; set; }

    public virtual DbSet<GioHang> GioHangs { get; set; }

    public virtual DbSet<HangHoa> HangHoas { get; set; }

    public virtual DbSet<HoaDon> HoaDons { get; set; }

    public virtual DbSet<KhachHang> KhachHangs { get; set; }

    public virtual DbSet<LoaiSp> LoaiSps { get; set; }

    public virtual DbSet<NhanVien> NhanViens { get; set; }

    public virtual DbSet<TrangThai> TrangThais { get; set; }

   // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
// #warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
//        => optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=NiceNiceShop;Integrated Security=True;Trust Server Certificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ChiTietHd>(entity =>
        {
            entity.HasKey(e => e.MaCthd).HasName("PK__ChiTietH__1E4FA771AFE64785");

            entity.ToTable("ChiTietHD");

            entity.Property(e => e.MaCthd)
                .ValueGeneratedNever()
                .HasColumnName("MaCTHD");
            entity.Property(e => e.MaHd).HasColumnName("MaHD");
            entity.Property(e => e.MaHh).HasColumnName("MaHH");

            entity.HasOne(d => d.MaHdNavigation).WithMany(p => p.ChiTietHds)
                .HasForeignKey(d => d.MaHd)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ChiTietHD__MaHD__46E78A0C");

            entity.HasOne(d => d.MaHhNavigation).WithMany(p => p.ChiTietHds)
                .HasForeignKey(d => d.MaHh)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ChiTietHD__MaHH__47DBAE45");
        });

        modelBuilder.Entity<GioHang>(entity =>
        {
            entity.HasKey(e => e.MaGh).HasName("PK__GioHang__2725AE8513E82CCA");

            entity.ToTable("GioHang");

            entity.Property(e => e.MaGh)
                .HasMaxLength(10)
                .HasColumnName("MaGH");
            entity.Property(e => e.MaKh)
                .HasMaxLength(20)
                .HasColumnName("MaKH");
            entity.Property(e => e.MaLoaiSp).HasColumnName("MaLoaiSP");

            entity.HasOne(d => d.MaKhNavigation).WithMany(p => p.GioHangs)
                .HasForeignKey(d => d.MaKh)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__GioHang__MaKH__4BAC3F29");

            entity.HasOne(d => d.MaLoaiSpNavigation).WithMany(p => p.GioHangs)
                .HasForeignKey(d => d.MaLoaiSp)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__GioHang__MaLoaiS__4AB81AF0");
        });

        modelBuilder.Entity<HangHoa>(entity =>
        {
            entity.HasKey(e => e.MaHh).HasName("PK__HangHoa__2725A6E464F79DB4");

            entity.ToTable("HangHoa");

            entity.Property(e => e.MaHh)
                .ValueGeneratedNever()
                .HasColumnName("MaHH");
            entity.Property(e => e.Hinh).HasMaxLength(100);
            entity.Property(e => e.MaLoaiSp).HasColumnName("MaLoaiSP");
            entity.Property(e => e.NgaySx)
                .HasColumnType("datetime")
                .HasColumnName("NgaySX");
            entity.Property(e => e.TenHh)
                .HasMaxLength(1)
                .HasColumnName("TenHH");

            entity.HasOne(d => d.MaLoaiSpNavigation).WithMany(p => p.HangHoas)
                .HasForeignKey(d => d.MaLoaiSp)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__HangHoa__MaLoaiS__3F466844");
        });

        modelBuilder.Entity<HoaDon>(entity =>
        {
            entity.HasKey(e => e.MaHd).HasName("PK__HoaDon__2725A6E02F70C6AD");

            entity.ToTable("HoaDon");

            entity.Property(e => e.MaHd)
                .ValueGeneratedNever()
                .HasColumnName("MaHD");
            entity.Property(e => e.CachThanhToan).HasMaxLength(50);
            entity.Property(e => e.CachVanChuyen).HasMaxLength(50);
            entity.Property(e => e.DiaChi).HasMaxLength(100);
            entity.Property(e => e.GhiChu).HasMaxLength(100);
            entity.Property(e => e.HoTen).HasMaxLength(50);
            entity.Property(e => e.MaKh)
                .HasMaxLength(20)
                .HasColumnName("MaKH");
            entity.Property(e => e.MaNv)
                .HasMaxLength(50)
                .HasColumnName("MaNV");
            entity.Property(e => e.NgayDat).HasColumnType("datetime");
            entity.Property(e => e.NgayGiao).HasColumnType("datetime");

            entity.HasOne(d => d.MaKhNavigation).WithMany(p => p.HoaDons)
                .HasForeignKey(d => d.MaKh)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__HoaDon__MaKH__4222D4EF");

            entity.HasOne(d => d.MaNvNavigation).WithMany(p => p.HoaDons)
                .HasForeignKey(d => d.MaNv)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__HoaDon__MaNV__440B1D61");

            entity.HasOne(d => d.MaTrangThaiNavigation).WithMany(p => p.HoaDons)
                .HasForeignKey(d => d.MaTrangThai)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__HoaDon__MaTrangT__4316F928");
        });

        modelBuilder.Entity<KhachHang>(entity =>
        {
            entity.HasKey(e => e.MaKh).HasName("PK__khachHan__2725CF1ECDA9F2E3");

            entity.ToTable("khachHang");

            entity.Property(e => e.MaKh)
                .HasMaxLength(20)
                .HasColumnName("MaKH");
            entity.Property(e => e.DiaChi).HasMaxLength(100);
            entity.Property(e => e.Email)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.Hoten).HasMaxLength(50);
            entity.Property(e => e.MatKhau).HasMaxLength(50);
            entity.Property(e => e.Sdt)
                .HasMaxLength(10)
                .IsUnicode(false);
        });

        modelBuilder.Entity<LoaiSp>(entity =>
        {
            entity.HasKey(e => e.MaLoaiSp).HasName("PK__LoaiSP__1224CA7C5DAEB5E1");

            entity.ToTable("LoaiSP");

            entity.Property(e => e.MaLoaiSp)
                .ValueGeneratedNever()
                .HasColumnName("MaLoaiSP");
            entity.Property(e => e.Hinh).HasMaxLength(50);
            entity.Property(e => e.TenLoaiSp)
                .HasMaxLength(50)
                .HasColumnName("TenLoaiSP");
        });

        modelBuilder.Entity<NhanVien>(entity =>
        {
            entity.HasKey(e => e.MaNv).HasName("PK__NhanVien__2725D70A4EB27D51");

            entity.ToTable("NhanVien");

            entity.Property(e => e.MaNv)
                .HasMaxLength(50)
                .HasColumnName("MaNV");
            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.HoTen).HasMaxLength(50);
            entity.Property(e => e.MatKhau).HasMaxLength(50);
        });

        modelBuilder.Entity<TrangThai>(entity =>
        {
            entity.HasKey(e => e.MaTrangThai).HasName("PK__TrangTha__AADE4138058E71A7");

            entity.ToTable("TrangThai");

            entity.Property(e => e.MaTrangThai).ValueGeneratedNever();
            entity.Property(e => e.TenTrangThai).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
