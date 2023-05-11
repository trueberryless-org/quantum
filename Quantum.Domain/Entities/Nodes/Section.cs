// ReSharper disable once CheckNamespace

using Quantum.Domain.Enums;

namespace Quantum.Domain.Entities;

public abstract class Section : Node
{
    public string Content { get; set; } = null!;

    protected Section(ENodeType type) : base(type)
    {
    }
}