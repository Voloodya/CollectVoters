using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using CollectVoters.Models;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace CollectVoters.Data
{
    public partial class Db_usersContext : DbContext
    {
        public Db_usersContext()
        {
        }

        public Db_usersContext(DbContextOptions<Db_usersContext> options)
            : base(options)
        {
        }

        public virtual DbSet<City> City { get; set; }
        public virtual DbSet<District> District { get; set; }
        public virtual DbSet<Fieldactivity> Fieldactivity { get; set; }
        public virtual DbSet<Friend> Friend { get; set; }
        public virtual DbSet<PollingStation> PollingStation { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<User> User { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseMySql("server=localhost;port=3306;user=root;password=root;database=db_users", x => x.ServerVersion("8.0.22-mysql"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<City>(entity =>
            {
                entity.HasKey(e => e.IdCity)
                    .HasName("PRIMARY");

                entity.Property(e => e.Name)
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");
            });

            modelBuilder.Entity<District>(entity =>
            {
                entity.HasKey(e => e.IdDistrict)
                    .HasName("PRIMARY");

                entity.Property(e => e.Name)
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");
            });

            modelBuilder.Entity<Fieldactivity>(entity =>
            {
                entity.HasKey(e => e.IdFieldActivity)
                    .HasName("PRIMARY");

                entity.Property(e => e.Name)
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");
            });

            modelBuilder.Entity<Friend>(entity =>
            {
                entity.HasKey(e => e.IdFriend)
                    .HasName("PRIMARY");

                entity.HasIndex(e => e.CityId)
                    .HasName("FK_Friend_City");

                entity.HasIndex(e => e.DistrictId)
                    .HasName("FK_Friend_District");

                entity.HasIndex(e => e.FieldActivityId)
                    .HasName("FK_Friend_FieldActivity");

                entity.HasIndex(e => e.PollingStationId)
                    .HasName("FK_Friend_Polling_station");

                entity.HasIndex(e => e.UserId)
                    .HasName("FK_Friend_User");

                entity.Property(e => e.Apartment)
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Description)
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.FamilyName)
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.House)
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Name)
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Organization)
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.PatronymicName)
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.PhoneNumberResponsible)
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Street)
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Telephone)
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Voter)
                   .HasCharSet("utf8mb4")
                   .HasCollation("utf8mb4_0900_ai_ci");

                entity.HasOne(d => d.City)
                    .WithMany(p => p.Friends)
                    .HasForeignKey(d => d.CityId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK_Friend_City");

                entity.HasOne(d => d.District)
                    .WithMany(p => p.Friends)
                    .HasForeignKey(d => d.DistrictId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK_Friend_District");

                entity.HasOne(d => d.FieldActivity)
                    .WithMany(p => p.Friends)
                    .HasForeignKey(d => d.FieldActivityId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK_Friend_FieldActivity");

                entity.HasOne(d => d.PollingStation)
                    .WithMany(p => p.Friends)
                    .HasForeignKey(d => d.PollingStationId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK_Friend_Polling_station");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Friends)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK_Friend_User");
            });

            modelBuilder.Entity<PollingStation>(entity =>
            {
                entity.HasKey(e => e.IdPollingStation)
                    .HasName("PRIMARY");

                entity.Property(e => e.Name)
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.HasKey(e => e.IdRole)
                    .HasName("PRIMARY");

                entity.Property(e => e.Name)
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.IdUser)
                    .HasName("PRIMARY");

                entity.HasIndex(e => e.RoleId)
                    .HasName("FK_User_Role");

                entity.Property(e => e.FamilyName)
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Name)
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Password)
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.PatronymicName)
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Telephone)
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.UserName)
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.User)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK_User_Role");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
