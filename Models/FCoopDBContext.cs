using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Ф_КООП.Models
{
    public partial class FCoopDBContext : DbContext
    {
        public FCoopDBContext()
        {
        }

        public FCoopDBContext(DbContextOptions<FCoopDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<Contract> Contracts { get; set; }
        public virtual DbSet<Deal> Deals { get; set; }
        public virtual DbSet<Plot> Plots { get; set; }
        public virtual DbSet<Rent> Rents { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;Database=FCoopDB;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Client>(entity =>
            {
                entity.HasIndex(e => e.IdcardNum, "UQ__Clients__85759C327CCABAF0")
                    .IsUnique();

                entity.Property(e => e.ClientId).HasColumnName("ClientID");

                entity.Property(e => e.Address).HasMaxLength(30);

                entity.Property(e => e.Email).HasMaxLength(30);

                entity.Property(e => e.IdcardNum)
                    .HasMaxLength(9)
                    .HasColumnName("IDCardNum");

                entity.Property(e => e.Name).HasMaxLength(20);

                entity.Property(e => e.Residence).HasMaxLength(30);
            });

            modelBuilder.Entity<Contract>(entity =>
            {
                entity.Property(e => e.ContractId)
                    .HasMaxLength(8)
                    .HasColumnName("ContractID");

                entity.Property(e => e.Date).HasColumnType("date");

                entity.Property(e => e.Plant).HasMaxLength(20);
            });

            modelBuilder.Entity<Deal>(entity =>
            {
                entity.HasKey(e => e.ContractId)
                    .HasName("PK__Deals__C90D3409D39E2391");

                entity.Property(e => e.ContractId)
                    .HasMaxLength(8)
                    .HasColumnName("ContractID");

                entity.Property(e => e.ClientId).HasColumnName("ClientID");

                entity.Property(e => e.PlotId)
                    .HasMaxLength(7)
                    .HasColumnName("PlotID");

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.Deals)
                    .HasForeignKey(d => d.ClientId)
                    .HasConstraintName("fk_Deals_Clients");

                entity.HasOne(d => d.Contract)
                    .WithOne(p => p.Deal)
                    .HasForeignKey<Deal>(d => d.ContractId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Deals_Contracts");

                entity.HasOne(d => d.Plot)
                    .WithMany(p => p.Deals)
                    .HasForeignKey(d => d.PlotId)
                    .HasConstraintName("fk_Deals_Plots");
            });

            modelBuilder.Entity<Plot>(entity =>
            {
                entity.Property(e => e.PlotId)
                    .HasMaxLength(7)
                    .HasColumnName("PlotID");

                entity.Property(e => e.Area).HasColumnType("decimal(10, 1)");

                entity.Property(e => e.Location).HasMaxLength(20);

                entity.Property(e => e.Municipality).HasMaxLength(20);

                entity.HasOne(d => d.TypeNavigation)
                    .WithMany(p => p.Plots)
                    .HasForeignKey(d => d.Type)
                    .HasConstraintName("fk_Plots_Rents");
            });

            modelBuilder.Entity<Rent>(entity =>
            {
                entity.HasKey(e => e.Type)
                    .HasName("PK__Rents__F9B8A48ACA5EFC75");

                entity.Property(e => e.Type).ValueGeneratedNever();

                entity.Property(e => e.Rent1)
                    .HasColumnType("money")
                    .HasColumnName("Rent");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
