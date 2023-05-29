// ReSharper disable once CheckNamespace

using System.ComponentModel.DataAnnotations.Schema;
using Quantum.Domain.Enums;

namespace Quantum.Domain.Entities.Nodes;

[Table("SECTIONS")]
public abstract class Section : Node
{
    public string Content { get; set; } = null!;

    protected Section(ENodeType type) : base(type)
    {
    }
}