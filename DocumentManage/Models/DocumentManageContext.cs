﻿using System;
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
        public virtual DbSet<Request> Requests { get; set; } = null!;
        public virtual DbSet<Status> Statuses { get; set; } = null!;
        public virtual DbSet<Type> Types { get; set; } = null!;
        public virtual DbSet<Urgency> Urgencies { get; set; } = null!;
        public virtual DbSet<WStatus> WStatuses { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=TAKA\\SQLEXPRESS;Database=DocumentManage;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Document>(entity =>
            {
                entity.ToTable("Document");

                entity.Property(e => e.DocumentId).HasColumnName("DocumentID");

                entity.Property(e => e.DateSend).HasMaxLength(50);

                entity.Property(e => e.Receiver).HasMaxLength(50);

                entity.Property(e => e.Sender).HasMaxLength(50);

                entity.Property(e => e.TypeId).HasColumnName("TypeID");

                entity.Property(e => e.UrgencyId).HasColumnName("UrgencyID");

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
            });

            modelBuilder.Entity<Position>(entity =>
            {
                entity.ToTable("Position");

                entity.Property(e => e.PositionId).HasColumnName("PositionID");

                entity.Property(e => e.Position1)
                    .HasMaxLength(50)
                    .HasColumnName("Position");
            });

            modelBuilder.Entity<Profile>(entity =>
            {
                entity.ToTable("Profile");

                entity.Property(e => e.ProfileId).HasColumnName("ProfileID");

                entity.Property(e => e.Address).HasMaxLength(50);

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.Password).HasMaxLength(50);

                entity.Property(e => e.PositionId).HasColumnName("PositionID");

                entity.Property(e => e.WStatusId).HasColumnName("wStatusID");

                entity.HasOne(d => d.Position)
                    .WithMany(p => p.Profiles)
                    .HasForeignKey(d => d.PositionId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_Profile_Position");

                entity.HasOne(d => d.WStatus)
                    .WithMany(p => p.Profiles)
                    .HasForeignKey(d => d.WStatusId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_Profile_wStatus");
            });

            modelBuilder.Entity<Request>(entity =>
            {
                entity.ToTable("Request");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Deadline).HasColumnType("date");

                entity.Property(e => e.DocumentId).HasColumnName("DocumentID");

                entity.Property(e => e.ProfileId).HasColumnName("ProfileID");

                entity.Property(e => e.StatusId).HasColumnName("StatusID");

                entity.HasOne(d => d.Document)
                    .WithMany(p => p.Requests)
                    .HasForeignKey(d => d.DocumentId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_Request_Document");

                entity.HasOne(d => d.Profile)
                    .WithMany(p => p.Requests)
                    .HasForeignKey(d => d.ProfileId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_Request_Profile");

                entity.HasOne(d => d.Status)
                    .WithMany(p => p.Requests)
                    .HasForeignKey(d => d.StatusId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_Request_Status");
            });

            modelBuilder.Entity<Status>(entity =>
            {
                entity.ToTable("Status");

                entity.Property(e => e.StatusId).HasColumnName("StatusID");

                entity.Property(e => e.Status1)
                    .HasMaxLength(10)
                    .HasColumnName("Status")
                    .IsFixedLength();
            });

            modelBuilder.Entity<Type>(entity =>
            {
                entity.ToTable("Type");

                entity.Property(e => e.TypeId).HasColumnName("TypeID");

                entity.Property(e => e.DocumentType).HasMaxLength(50);
            });

            modelBuilder.Entity<Urgency>(entity =>
            {
                entity.ToTable("Urgency");

                entity.Property(e => e.UrgencyId).HasColumnName("UrgencyID");

                entity.Property(e => e.Urgency1)
                    .HasMaxLength(50)
                    .HasColumnName("Urgency");
            });

            modelBuilder.Entity<WStatus>(entity =>
            {
                entity.ToTable("wStatus");

                entity.Property(e => e.WStatusId).HasColumnName("wStatusID");

                entity.Property(e => e.WStatus1)
                    .HasMaxLength(10)
                    .HasColumnName("wStatus")
                    .IsFixedLength();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}