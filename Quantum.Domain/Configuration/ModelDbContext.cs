using Microsoft.EntityFrameworkCore;
using Quantum.Domain.Entities;
using Quantum.Domain.Entities.Nodes;
using Quantum.Domain.Entities.Nodes.Sections;
using Quantum.Domain.Enums;

namespace Quantum.Domain.Configuration;

public class ModelDbContext : DbContext
{
    public DbSet<Node> Nodes { get; set; }
    public DbSet<Page> Pages { get; set; }
    public DbSet<Section> Sections { get; set; }
    public DbSet<Heading> Headings { get; set; }
    public DbSet<Paragraph> Paragraphs { get; set; }
    public DbSet<Image> Images { get; set; }
    public DbSet<Description> Descriptions { get; set; }
    
    public ModelDbContext(DbContextOptions<ModelDbContext> options) : base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Node>()
            .HasDiscriminator<string>("TYPE")
            .HasValue<Page>(ENodeType.PAGE.ToString())
            .HasValue<Heading>(ENodeType.HEADING.ToString())
            .HasValue<Paragraph>(ENodeType.PARAGRAPH.ToString())
            .HasValue<Image>(ENodeType.IMAGE.ToString())
            .HasValue<Description>(ENodeType.DESCRIPTION.ToString());

        modelBuilder.Entity<Node>()
            .HasOne(n => n.Parent)
            .WithMany(n => n.Children)
            .HasForeignKey(n => n.ParentId);
    }
}