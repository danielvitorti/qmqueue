using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using QMessage.Models;

#nullable disable

namespace QMessage
{
    public partial class qmessageContext : DbContext
    {
        public qmessageContext()
        {
        }

        public qmessageContext(DbContextOptions<qmessageContext> options)
            : base(options)
        {
        }

        //public virtual DbSet<qmqdb> QMQDbs { get; set; }
        public virtual DbSet<QMQ_IN_BODY> QMQ_IN_BODies { get; set; }
        public virtual DbSet<QMQ_IN_BODY_H> QMQ_IN_BODY_Hs { get; set; }
        public virtual DbSet<QMQ_IN_ERRORLOG> QMQ_IN_ERRORLOGs { get; set; }
        public virtual DbSet<QMQ_IN_ERRORLOG_H> QMQ_IN_ERRORLOG_Hs { get; set; }
        public virtual DbSet<QMQ_IN_HEADER> QMQ_IN_HEADERs { get; set; }
        public virtual DbSet<QMQ_OUT_BODY> QMQ_OUT_BODies { get; set; }
        public virtual DbSet<QMQ_OUT_BODY_H> QMQ_OUT_BODY_Hs { get; set; }
        public virtual DbSet<QMQ_OUT_ERRORLOG> QMQ_OUT_ERRORLOGs { get; set; }
        public virtual DbSet<QMQ_OUT_ERRORLOG_H> QMQ_OUT_ERRORLOG_Hs { get; set; }
        public virtual DbSet<QMQ_OUT_HEADER> QMQ_OUT_HEADERs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlite("Data Source=qmessage.db");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            /*modelBuilder.Entity<QMQDb>(entity =>
            {
                entity.HasKey(e => new { e.Telegramm, e.FieldSeq, e.Feature });

                entity.ToTable("QMQDb");

                entity.Property(e => e.Telegramm).HasColumnType("VARCHAR(50)");

                entity.Property(e => e.Feature).HasColumnType("VARCHAR(50)");

                entity.Property(e => e.ColumnName).HasColumnType("VARCHAR(50)");

                entity.Property(e => e.Factor).HasColumnType("VARCHAR(50)");

                entity.Property(e => e.TableName).HasColumnType("VARCHAR(50)");

                entity.Property(e => e.Type).HasColumnType("VARCHAR(20)");
            }); */

            modelBuilder.Entity<QMQ_IN_BODY>(entity =>
            {
                entity.HasKey(e => new { e.SOURCE, e.MESSAGE_ID, e.FIELD_SEQ });

                entity.ToTable("QMQ_IN_BODY");

                entity.Property(e => e.FEATURE).HasColumnType("CHAR(40)");

                entity.Property(e => e.VALUE).HasColumnType("VARCHAR(1000)");

                entity.HasOne(d => d.QMQ_IN_HEADER)
                    .WithMany(p => p.QMQ_IN_BODies)
                    .HasForeignKey(d => new { d.SOURCE, d.MESSAGE_ID })
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<QMQ_IN_BODY_H>(entity =>
            {
                entity.HasKey(e => new { e.SOURCE, e.MESSAGE_ID, e.FIELD_SEQ });

                entity.ToTable("QMQ_IN_BODY_H");

                entity.Property(e => e.FEATURE).HasColumnType("CHAR(40)");

                entity.Property(e => e.VALUE).HasColumnType("VARCHAR(1000)");

                entity.HasOne(d => d.QMQ_IN_HEADER)
                    .WithMany(p => p.QMQ_IN_BODY_Hs)
                    .HasForeignKey(d => new { d.SOURCE, d.MESSAGE_ID })
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<QMQ_IN_ERRORLOG>(entity =>
            {
                entity.HasKey(e => new { e.SOURCE, e.MESSAGE_ID, e.DATE_TIME_ERROR });

                entity.ToTable("QMQ_IN_ERRORLOG");

                entity.Property(e => e.ERROR_TEXT).HasColumnType("VARCHAR(4000)");

                entity.HasOne(d => d.QMQ_IN_HEADER)
                    .WithMany(p => p.QMQ_IN_ERRORLOGs)
                    .HasForeignKey(d => new { d.SOURCE, d.MESSAGE_ID })
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<QMQ_IN_ERRORLOG_H>(entity =>
            {
                entity.HasKey(e => new { e.SOURCE, e.MESSAGE_ID, e.DATE_TIME_ERROR });

                entity.ToTable("QMQ_IN_ERRORLOG_H");

                entity.Property(e => e.ERROR_TEXT).HasColumnType("VARCHAR(4000)");

                entity.HasOne(d => d.QMQ_IN_HEADER)
                    .WithMany(p => p.QMQ_IN_ERRORLOG_Hs)
                    .HasForeignKey(d => new { d.SOURCE, d.MESSAGE_ID })
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<QMQ_IN_HEADER>(entity =>
            {
                entity.HasKey(e => new { e.SOURCE, e.MESSAGE_ID });

                entity.ToTable("QMQ_IN_HEADER");

                entity.Property(e => e.MSG_STATUS).HasColumnType("CHAR(1)");

                entity.Property(e => e.REMARKS).HasColumnType("VARCHAR(40)");
            });

            modelBuilder.Entity<QMQ_OUT_BODY>(entity =>
            {
                entity.HasKey(e => new { e.SOURCE, e.MESSAGE_ID, e.FIELD_SEQ });

                entity.ToTable("QMQ_OUT_BODY");

                entity.Property(e => e.FEATURE).HasColumnType("CHAR(40)");

                entity.Property(e => e.VALUE).HasColumnType("VARCHAR(1000)");

                entity.HasOne(d => d.QMQ_OUT_HEADER)
                    .WithMany(p => p.QMQ_OUT_BODies)
                    .HasForeignKey(d => new { d.SOURCE, d.MESSAGE_ID })
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<QMQ_OUT_BODY_H>(entity =>
            {
                entity.HasKey(e => new { e.SOURCE, e.MESSAGE_ID, e.FIELD_SEQ });

                entity.ToTable("QMQ_OUT_BODY_H");

                entity.Property(e => e.FEATURE).HasColumnType("CHAR(40)");

                entity.Property(e => e.VALUE).HasColumnType("VARCHAR(1000)");

                entity.HasOne(d => d.QMQ_OUT_HEADER)
                    .WithMany(p => p.QMQ_OUT_BODY_Hs)
                    .HasForeignKey(d => new { d.SOURCE, d.MESSAGE_ID })
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<QMQ_OUT_ERRORLOG>(entity =>
            {
                entity.HasKey(e => new { e.SOURCE, e.MESSAGE_ID, e.DATE_TIME_ERROR });

                entity.ToTable("QMQ_OUT_ERRORLOG");

                entity.Property(e => e.ERROR_TEXT).HasColumnType("VARCHAR(4000)");

                entity.HasOne(d => d.QMQ_OUT_HEADER)
                    .WithMany(p => p.QMQ_OUT_ERRORLOGs)
                    .HasForeignKey(d => new { d.SOURCE, d.MESSAGE_ID })
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<QMQ_OUT_ERRORLOG_H>(entity =>
            {
                entity.HasKey(e => new { e.SOURCE, e.MESSAGE_ID, e.DATE_TIME_ERROR });

                entity.ToTable("QMQ_OUT_ERRORLOG_H");

                entity.Property(e => e.ERROR_TEXT).HasColumnType("VARCHAR(4000)");

                entity.HasOne(d => d.QMQ_OUT_HEADER)
                    .WithMany(p => p.QMQ_OUT_ERRORLOG_Hs)
                    .HasForeignKey(d => new { d.SOURCE, d.MESSAGE_ID })
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<QMQ_OUT_HEADER>(entity =>
            {
                entity.HasKey(e => new { e.SOURCE, e.MESSAGE_ID });

                entity.ToTable("QMQ_OUT_HEADER");

                entity.Property(e => e.MSG_STATUS).HasColumnType("CHAR(1)");

                entity.Property(e => e.REMARKS).HasColumnType("VARCHAR(40)");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

        public DbSet<QMessage.Models.QMQ_IN_HEADER> QmqInHeader { get; set; }

        public DbSet<QMessage.Models.QMQ_IN_BODY> QmqInBody { get; set; }

        public DbSet<QMessage.Models.QMQ_OUT_HEADER> QmqOutHeader { get; set; }

        public DbSet<QMessage.Models.QMQ_OUT_BODY> QmqOutBody { get; set; }

        public DbSet<QMessage.Models.QMQ_IN_BODY_H> QmqInBodyH { get; set; }

        public DbSet<QMessage.Models.QMQ_OUT_BODY_H> QmqOutBodyH { get; set; }

        public DbSet<QMessage.Models.QMQ_IN_ERRORLOG_H> QmqInErrorlogH { get; set; }

        public DbSet<QMessage.Models.QMQ_IN_ERRORLOG> QmqInErrorlog { get; set; }

        public DbSet<QMessage.Models.QMQ_OUT_ERRORLOG> QmqOutErrorlog { get; set; }

        public DbSet<QMessage.Models.QMQ_OUT_ERRORLOG_H> QmqOutErrorlogH { get; set; }
    }
}
