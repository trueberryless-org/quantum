using System.ComponentModel.DataAnnotations.Schema;
using Quantum.Domain.Enums;

namespace Quantum.Domain.Entities.Nodes.Sections;

[Table("HEADINGS")]
public class Heading : Section
{
    public Heading() : base(ENodeType.HEADING)
    {
    }
}