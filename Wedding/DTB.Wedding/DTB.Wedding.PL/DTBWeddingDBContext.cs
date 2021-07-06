using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace DTB.Wedding.PL
{
    public partial class WeddingEntities : DbContext
    {
        public WeddingEntities()
        {
        }

        public WeddingEntities(DbContextOptions<WeddingEntities> options)
            : base(options)
        {
        }

        public virtual DbSet<TblFamily> TblFamilies { get; set; }
        public virtual DbSet<TblGuest> TblGuests { get; set; }
        public virtual DbSet<TblTable> TblTables { get; set; }
        public virtual DbSet<TblUser> TblUsers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

                optionsBuilder.UseSqlServer("Server=(localdb)\\ProjectsV13;Database=DTB.Wedding.DB;Integrated Security=True");
                
                optionsBuilder.UseLazyLoadingProxies();
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<TblFamily>(entity =>
            {
                entity.ToTable("tblFamily");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblGuest>(entity =>
            {
                entity.ToTable("tblGuest");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name).IsRequired().HasMaxLength(50).IsUnicode(false);

                entity.HasOne(d => d.Table)
                    .WithMany(p => p.TblGuests)
                    .HasForeignKey(d => d.TableId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("tblGuest_TableId");

                entity.HasOne(d => d.Family)
                    .WithMany(p => p.TblGuests)
                    .HasForeignKey(d => d.FamilyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("tblGuest_UserId");
            });

            

            

            modelBuilder.Entity<TblTable>(entity =>
            {
                entity.ToTable("tblTable");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

            });

            

            modelBuilder.Entity<TblUser>(entity =>
            {
                entity.ToTable("tblUser");

                entity.HasIndex(e => e.Username, "UQ__tblUser__536C85E48783A64C")
                    .IsUnique();

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Password)
                    .IsRequired();

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

            });

            

            modelBuilder.Entity<spCalcRemainingChairs>().HasNoKey();

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
