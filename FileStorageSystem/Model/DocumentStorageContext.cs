using System.Collections.Generic;
using System.Reflection.Emit;
using Microsoft.EntityFrameworkCore;

namespace FileStorageSystem.Model
{
    public class DocumentStorageContext : DbContext
    {
        public DocumentStorageContext(DbContextOptions<DocumentStorageContext> options) : base(options) { }

        public DbSet<Document> Documents { get; set; }
        public DbSet<Counterparty> Counterparties { get; set; }
        public DbSet<DocumentType> DocumentTypes { get; set; }
        public DbSet<Extension> Extensions { get; set; }
        public DbSet<Keyword> Keywords { get; set; }
        public DbSet<DocumentKeyword> DocumentKeywords { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Настройка составного ключа для DocumentKeywords (junction table)
            modelBuilder.Entity<DocumentKeyword>()
                .HasKey(dk => new { dk.DocumentId, dk.KeywordId });

            // Настройка связей, если нужно (EF Core обычно infer их автоматически, но можно уточнить)
            modelBuilder.Entity<DocumentKeyword>()
                .HasOne(dk => dk.Document)
                .WithMany(d => d.DocumentKeywords)
                .HasForeignKey(dk => dk.DocumentId);

            modelBuilder.Entity<DocumentKeyword>()
                .HasOne(dk => dk.Keyword)
                .WithMany(k => k.DocumentKeywords)
                .HasForeignKey(dk => dk.KeywordId);
        }
    }
}
