using Microsoft.EntityFrameworkCore;

namespace rh.Models
{
    public class RhContext : DbContext
    {
        public RhContext (DbContextOptions<RhContext> options)
            : base(options)
        {            
        }

        public DbSet<rh.Models.Collaborateur> Collaborateur { get; set; }
        public DbSet<rh.Models.Conge> Conge { get; set; }
        public DbSet<rh.Models.TypeConge> TypeConge { get; set; }
        public DbSet<rh.Models.Contrat> Contrat { get; set; }
        public DbSet<rh.Models.TypeContrat> TypeContrat { get; set; }
        public DbSet<rh.Models.Service> Service { get; set; }
        public DbSet<rh.Models.Depense> Depense { get; set; }
        public DbSet<rh.Models.TypeDepense> TypeDepense { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=rh.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Collaborateur>()
                .HasOne<Service>(c => c.Service)
                .WithMany(s => s.Collaborateurs)
                .HasForeignKey(c => c.ServiceId);

            modelBuilder.Entity<Conge>()
                .HasOne<Collaborateur>(con => con.Collaborateur)
                .WithMany(col => col.Conges)
                .HasForeignKey(con => con.CollaborateurId);

            modelBuilder.Entity<Conge>()
                .HasOne<TypeConge>(c => c.TypeConge)
                .WithMany(tc => tc.Conges)
                .HasForeignKey(c => c.TypeCongeId);

            modelBuilder.Entity<Contrat>()
                .HasOne<Collaborateur>(con => con.Collaborateur)
                .WithMany(col => col.Contrats)
                .HasForeignKey(con => con.CollaborateurId);

            modelBuilder.Entity<Contrat>()
                .HasOne<TypeContrat>(c => c.TypeContrat)
                .WithMany(tc => tc.Contrats)
                .HasForeignKey(c => c.TypeContratId);

            modelBuilder.Entity<Depense>()
                .HasOne<TypeDepense>(d => d.TypeDepense)
                .WithMany(td => td.Depenses)
                .HasForeignKey(d => d.TypeDepenseId);
        }
    }
}