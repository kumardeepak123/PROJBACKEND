using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace LMS.Models
{
    public partial class LMS_Team5_Project10Context : DbContext
    {
        public LMS_Team5_Project10Context()
        {
        }

        public LMS_Team5_Project10Context(DbContextOptions<LMS_Team5_Project10Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Leave> Leaves { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=10.3.117.39;Database=LMS_Team5_Project10;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasKey(e => e.Empid)
                    .HasName("PK__employee__AF4CE8656D695629");

                entity.ToTable("employee");

                entity.Property(e => e.Empid).HasColumnName("empid");

                entity.Property(e => e.Department)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("department");

                entity.Property(e => e.Empaddress)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("empaddress");

                entity.Property(e => e.Empemail)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("empemail");

                entity.Property(e => e.Empname)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("empname");

                entity.Property(e => e.Emppassword)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("emppassword");

                entity.Property(e => e.Empusername)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("empusername");

                entity.Property(e => e.Leaveinhand).HasColumnName("leaveinhand");

                entity.Property(e => e.Managerid).HasColumnName("managerid");

                entity.Property(e => e.Phnumber)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("phnumber");

                entity.HasOne(d => d.Manager)
                    .WithMany(p => p.InverseManager)
                    .HasForeignKey(d => d.Managerid)
                    .HasConstraintName("fk_manid");
            });

            modelBuilder.Entity<Leave>(entity =>
            {
                entity.ToTable("leave");

                entity.Property(e => e.Leaveid).HasColumnName("leaveid");

                entity.Property(e => e.Empid).HasColumnName("empid");

                entity.Property(e => e.Leavefrom)
                    .HasColumnType("datetime")
                    .HasColumnName("leavefrom");

                entity.Property(e => e.Leavestatus)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("leavestatus")
                    .HasDefaultValueSql("('pending')");

                entity.Property(e => e.Leaveto)
                    .HasColumnType("datetime")
                    .HasColumnName("leaveto");

                entity.Property(e => e.Leavetype)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("leavetype");

                entity.Property(e => e.Manid).HasColumnName("manid");

                entity.Property(e => e.Noofdays).HasColumnName("noofdays");

                entity.HasOne(d => d.Emp)
                    .WithMany(p => p.Leaves)
                    .HasForeignKey(d => d.Empid)
                    .HasConstraintName("FK__leave__empid__398D8EEE");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
