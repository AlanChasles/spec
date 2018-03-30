using Microsoft.EntityFrameworkCore;

namespace rh.Models
{
    public class RhContext : DbContext
    {
        public RhContext (DbContextOptions<RhContext> options)
            : base(options)
        {            
        }
        public DbSet<rh.Models.Projet> Projet { get; set; }
        public DbSet<rh.Models.Module> Module { get; set; }
        public DbSet<rh.Models.Page> Page { get; set; }
        public DbSet<rh.Models.Page> Info { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=rh.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {       
            modelBuilder.Entity<Module>()
                .HasOne<Projet>(m => m.projet)
                .WithMany(p => p.modules)
                .HasForeignKey(m => m.projetId);
            
            modelBuilder.Entity<Page>()
                .HasOne<Module>(p => p.module)
                .WithMany(m => m.pages)
                .HasForeignKey(p => p.moduleId);

            modelBuilder.Entity<Info>()
                .HasOne<Page>(i => i.page)
                .WithMany(p => p.infos)
                .HasForeignKey( i => i.pageId);
    
            modelBuilder.Entity<Image>()
                .HasOne<Page>(i => i.page)
                .WithMany(p => p.images)
                .HasForeignKey( i => i.pageId);
            
            modelBuilder.Entity<Lien>()
                .HasOne<Page>(l => l.entreePage)
                .WithMany(p => p.entreeLiens)
                .HasForeignKey( l => l.entreePageId);
            
            modelBuilder.Entity<Lien>()
                .HasOne<Page>(l => l.sortiePage)
                .WithMany(p => p.sortieLiens)
                .HasForeignKey( l => l.sortiePageId);            
        }
    }
}