using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging.Abstractions;
using Quantum.Domain.Entities;
using Quantum.Domain.Entities.Nodes;
using Quantum.Domain.Entities.Nodes.Sections;

namespace Quantum.Domain.Configuration;

public class ModelDbContext : DbContext
{
    public DbSet<Node> Nodes { get; set; }
    public DbSet<Image> Images { get; set; }
    public DbSet<Page> Pages { get; set; }
    public DbSet<Section> Sections { get; set; }
    public DbSet<Heading> Headings { get; set; }
    public DbSet<Paragraph> Paragraphs { get; set; }
    
    public ModelDbContext(DbContextOptions<ModelDbContext> options) : base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Node>()
            .Property(n => n.Type)
            .HasConversion<string>();

        modelBuilder.Entity<Node>()
            .HasOne(n => n.Parent)
            .WithMany(n => n.Children)
            .HasForeignKey(n => n.ParentId);
    }
}