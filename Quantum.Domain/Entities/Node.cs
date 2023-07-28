using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Quantum.Domain.Entities.Nodes;
using Quantum.Domain.Entities.Nodes.Sections;

namespace Quantum.Domain.Entities;

[Table("NODES")]
public abstract class Node
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("ID")]
    public int Id { get; set; }

    [Column("PARENT_ID")] public int? ParentId { get; set; }
    public Node? Parent { get; set; }

    [Column("CONTENT")] public string Content { get; set; }

    [Column("ORDER")] public int Order { get; set; } = 0;

    public IEnumerable<Node> Children { get; set; } = null!;

    public string Path
    {
        get
        {
            if (Parent == null)
                return Content;
            if (this is Heading && Parent is Page)
                return Parent.Path + "#" + Content;
            return Parent.Path + "/" + Content;
        }
    }
}