using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Quantum.Domain.Entities;

[Table("NODES")]
public abstract class Node
{
    [Column("ID")]
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    
    [Column("PARENT_ID")]
    public int? ParentId { get; set; }
    public Node? Parent { get; set; }
    
    [Column("CONTENT")]
    public string Content { get; set; }

    [Column("ORDER")]
    public int Order { get; set; } = 0;

    public IEnumerable<Node> Children { get; set; } = null!;
}