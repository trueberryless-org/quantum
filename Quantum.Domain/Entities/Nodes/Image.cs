using Quantum.Domain.Enums;

namespace Quantum.Domain.Entities.Nodes;

public class Image : Node
{
    public string Url { get; set; } = null!;

    public Image() : base(ENodeType.IMAGE)
    {
    }
}