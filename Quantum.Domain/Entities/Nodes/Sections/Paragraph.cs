using System.ComponentModel.DataAnnotations.Schema;
using Quantum.Domain.Enums;

namespace Quantum.Domain.Entities.Nodes.Sections;

[Table("PARAGRAPHS")]
public class Paragraph : Section
{
    public Paragraph() : base(ENodeType.PARAGRAPH)
    {
    }
}