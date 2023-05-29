using System.ComponentModel.DataAnnotations.Schema;
using Quantum.Domain.Enums;

namespace Quantum.Domain.Entities.Nodes;

[Table("IMAGES")]
public class Image : Node
{
    public string Url { get; set; } = null!;

    public Image() : base(ENodeType.IMAGE)
    {
    }
}