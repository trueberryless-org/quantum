using System.ComponentModel.DataAnnotations.Schema;
using Quantum.Domain.Enums;

namespace Quantum.Domain.Entities.Nodes;

[Table("PAGES")]
public class Page : Node
{
    public string Title { get; set; }
    
    public string? Content { get; set; }

    public Page() : base(ENodeType.PAGE)
    {
    }
}