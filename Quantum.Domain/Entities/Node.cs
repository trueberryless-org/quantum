using Quantum.Domain.Enums;

namespace Quantum.Domain.Entities;

public abstract class Node
{
    public int Id { get; set; }
    
    public Node? Parent { get; set; }

    public List<Node> Children { get; set; } = null!;
    
    public ENodeType Type { get; }
    
    protected Node(ENodeType type)
    {
        Type = type;
    }
}