using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DocumentManage.Models
{
    public partial class DocumentManageContext : DbContext
    {
        public DocumentManageContext()
        {
        }

        public DocumentManageContext(DbContextOptions<DocumentManageContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Document> Documents { get; set; } = null!;
        public virtual DbSet<Position> Positions { get; set; } = null!;
        public virtual DbSet<Profile> Profiles { get; set; } = null!;
        public virtual DbSet<Status> Statuses { get; set; } = null!;
        public virtual DbSet<Type> Types { get; set; } = null!;
        public virtual DbSet<Urgency> Urgencies { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=TAKA\\SQLEXPRESS;Database=DocumentManage;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Document>(entity =>
            {
                entity.ToTable("Document");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.DateSend).HasColumnType("date");

                entity.Property(e => e.Deadline).HasColumnType("date");

                entity.Property(e => e.Receiver).HasMaxLength(50);

                entity.Property(e => e.Sender).HasMaxLength(50);

                entity.Property(e => e.StatusId).HasColumnName("StatusID");

                entity.Property(e => e.TypeId).HasColumnName("TypeID");

                entity.Property(e => e.UrgencyId).HasColumnName("UrgencyID");

                entity.HasOne(d => d.Status)
                    .WithMany(p => p.Documents)
                    .HasForeignKey(d => d.StatusId)
                    .HasConstraintName("FK_Document_Status");

                entity.HasOne(d => d.Type)
                    .WithMany(p => p.Documents)
                    .HasForeignKey(d => d.TypeId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_Document_Classify");

                entity.HasOne(d => d.Urgency)
                    .WithMany(p => p.Documents)
                    .HasForeignKey(d => d.UrgencyId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_Document_Urgency");

                entity.HasMany(d => d.Profiles)
                    .WithMany(p => p.Documents)
                    .UsingEntity<Dictionary<string, object>>(
                        "Request",
                        l => l.HasOne<Profile>().WithMany().HasForeignKey("ProfileId").HasConstraintName("FK_Request_Profile"),
                        r => r.HasOne<Document>().WithMany().HasForeignKey("DocumentId").HasConstraintName("FK_Request_Document"),
                        j =>
                        {
                            j.HasKey("DocumentId", "ProfileId");

                            j.ToTable("Request");

                            j.IndexerProperty<int>("DocumentId").HasColumnName("DocumentID");

                            j.IndexerProperty<int>("ProfileId").HasColumnName("ProfileID");
                        });
            });

            modelBuilder.Entity<Position>(entity =>
            {
                entity.ToTable("Position");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Positionn).HasMaxLength(50);
            });

            modelBuilder.Entity<Profile>(entity =>
            {
                entity.ToTable("Profile");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Address).HasMaxLength(50);

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.Password).HasMaxLength(50);

                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.PositionId).HasColumnName("PositionID");

                entity.HasOne(d => d.Position)
                    .WithMany(p => p.Profiles)
                    .HasForeignKey(d => d.PositionId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_Profile_Position");
            });

            modelBuilder.Entity<Status>(entity =>
            {
                entity.ToTable("Status");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Statuss)
                    .HasMaxLength(10)
                    .IsFixedLength();
            });

            modelBuilder.Entity<Type>(entity =>
            {
                entity.ToTable("Type");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.DocumentType).HasMaxLength(50);
            });

            modelBuilder.Entity<Urgency>(entity =>
            {
                entity.ToTable("Urgency");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Urgencyy).HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
