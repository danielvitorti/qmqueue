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
        public virtual DbSet<MENSAGEM_ENTRADA_CABECALHO> mensagemEntradaCabecalho { get; set; }
        public virtual DbSet<MENSAGEM_ENTRADA_CORPO> mensagemEntradaCorpo { get; set; }
        public virtual DbSet<MENSAGEM_SAIDA_CORPO> mensagemSaidaCorpo { get; set; }
        public virtual DbSet<MENSAGEM_SAIDA_CABECALHO> mensagemSaidaCabecalho { get; set; }

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
            
            modelBuilder.Entity<MENSAGEM_ENTRADA_CORPO>(entity =>
            {
                entity.HasKey(e => new { e.SISTEMA_ORIGEM, e.ID_MENSAGEM, e.SEQUENCIAL });

                entity.ToTable("MENSAGEM_ENTRADA_CORPO");

                entity.Property(e => e.CAMPO).HasColumnType("CHAR(40)");

                entity.Property(e => e.VALOR).HasColumnType("VARCHAR(1000)");

                entity.HasOne(d => d.mensagemEntradaCabecalho)
                    .WithMany(p => p.mensagemEntradaCorpo)
                    .HasForeignKey(d => new { d.SISTEMA_ORIGEM, d.ID_MENSAGEM })
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            
            modelBuilder.Entity<MENSAGEM_ENTRADA_CABECALHO>(entity =>
            {
                entity.HasKey(e => new { e.SISTEMA_ORIGEM, e.ID_MENSAGEM });

                entity.ToTable("MENSAGEM_ENTRADA_CABECALHO");

                entity.Property(e => e.STATUS).HasColumnType("CHAR(1)");

                entity.Property(e => e.OBSERVACAO).HasColumnType("VARCHAR(40)");
            });

            modelBuilder.Entity<MENSAGEM_SAIDA_CORPO>(entity =>
            {
                entity.HasKey(e => new { e.SISTEMA_ORIGEM, e.ID_MENSAGEM, e.SEQUENCIAL });

                entity.ToTable("MENSAGEM_SAIDA_CORPO");

                entity.Property(e => e.CAMPO).HasColumnType("CHAR(40)");

                entity.Property(e => e.VALOR).HasColumnType("VARCHAR(1000)");

                entity.HasOne(d => d.mensagemSaidaCabecalho)

                    .WithMany(p => p.mensagemSaidaCorpo)
                    .HasForeignKey(d => new { d.SISTEMA_ORIGEM, d.ID_MENSAGEM })
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            
            modelBuilder.Entity<MENSAGEM_SAIDA_CABECALHO>(entity =>
            {
                entity.HasKey(e => new { e.SISTEMA_DESTINO, e.ID_MENSAGEM });

                entity.ToTable("MENSAGEM_SAIDA_CABECALHO");

                entity.Property(e => e.STATUS).HasColumnType("CHAR(1)");

                entity.Property(e => e.OBSERVACAO).HasColumnType("VARCHAR(40)");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

        public DbSet<QMessage.Models.MENSAGEM_ENTRADA_CABECALHO> MensagemEntradaCabecalho { get; set; }

        public DbSet<QMessage.Models.MENSAGEM_ENTRADA_CORPO> MensagemEntradaCorpo { get; set; }

        public DbSet<QMessage.Models.MENSAGEM_SAIDA_CABECALHO> MensagemSaidaCabecalho { get; set; }

        public DbSet<QMessage.Models.MENSAGEM_SAIDA_CORPO> MensagemSaidaCorpo { get; set; }
        
    }
}
