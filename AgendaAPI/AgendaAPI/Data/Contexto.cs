using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using AgendaApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgendaApi.Data
{
    public class Contexto : DbContext
    {
        public DbSet<Agenda> agendas { get; set; }
        public DbSet<Contato> contatos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new MapAgenda());
            modelBuilder.ApplyConfiguration(new MapContato());
            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL("server=localhost; user id=root;password=root;persistsecurityinfo=True;port=3306;database=apiagenda;SslMode = none");
            base.OnConfiguring(optionsBuilder);
        }
    }

    public class MapContato : IEntityTypeConfiguration<Contato>
    {
        public void Configure(EntityTypeBuilder<Contato> builder)
        {
            builder.ToTable("Contato");
            builder.HasKey(w => w.id).HasName("PK");
            builder.Property(w => w.id).HasColumnName("ID").ValueGeneratedOnAdd();
            builder.Property(w => w.nome).HasColumnName("NOME").HasMaxLength(255).IsRequired();
            builder.Property(w => w.telefone).HasColumnName("TELEFONE").HasMaxLength(9).IsRequired();
            builder.Property(w => w.idagenda).HasColumnName("IDAGENDA").IsRequired();
            builder.HasOne(w => w.agenda).WithMany(w => w.contatos).HasForeignKey(w => w.idagenda).HasConstraintName("FK").OnDelete(DeleteBehavior.Cascade);
        }
    }

    public class MapAgenda : IEntityTypeConfiguration<Agenda>
    {
        public void Configure(EntityTypeBuilder<Agenda> builder)
        {
            builder.ToTable("Agenda");
            builder.HasKey(w => w.id).HasName("PK");
            builder.Property(w => w.id).HasColumnName("ID").ValueGeneratedOnAdd();
            builder.Property(w => w.nome).HasColumnName("NOME").HasMaxLength(255).IsRequired();
        }
    }
}
