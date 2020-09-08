using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Seat_Booking_Sys
{
    public partial class GamedayContext : DbContext
    {
        public GamedayContext()
        {
        }

        public GamedayContext(DbContextOptions<GamedayContext> options)
            : base(options)
        {
        }

        public virtual DbSet<GameSeats> GameSeats { get; set; }
        public virtual DbSet<Opposition> Opposition { get; set; }
        public virtual DbSet<Seating> Seating { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Gameday;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GameSeats>(entity =>
            {
                entity.Property(e => e.GameSeatsId).HasColumnName("Game_SeatsID");

                entity.Property(e => e.GameId).HasColumnName("GameID");

                entity.Property(e => e.SeatId).HasColumnName("SeatID");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.Game)
                    .WithMany(p => p.GameSeats)
                    .HasForeignKey(d => d.GameId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_GameSeats_ToOpposition");

                entity.HasOne(d => d.Seat)
                    .WithMany(p => p.GameSeats)
                    .HasForeignKey(d => d.SeatId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_GameSeats_ToSeating");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.GameSeats)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_GameSeats_ToUser");
            });

            modelBuilder.Entity<Opposition>(entity =>
            {
                entity.HasKey(e => e.GameId)
                    .HasName("PK__tmp_ms_x__2AB897DD5922F0A8");

                entity.Property(e => e.GameId).HasColumnName("GameID");

                entity.Property(e => e.Opposition1)
                    .HasColumnName("Opposition")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Seating>(entity =>
            {
                entity.HasKey(e => e.SeatId)
                    .HasName("PK__tmp_ms_x__311713D3C309AFC2");

                entity.Property(e => e.SeatId).HasColumnName("SeatID");

                entity.Property(e => e.Seat)
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PK__tmp_ms_x__1788CCAC91C3FAFE");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.Address)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.BirthDate).HasColumnType("date");

                entity.Property(e => e.City)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Phone)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Postcode)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.SecondName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Username)
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
