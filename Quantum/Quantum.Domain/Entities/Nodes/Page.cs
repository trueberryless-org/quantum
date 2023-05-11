using Quantum.Domain.Enums;

namespace Quantum.Domain.Entities.Nodes;

public class Page : Node
{
    public string? Content { get; set; }

    public Page() : base(ENodeType.PAGE)
    {
    }
}