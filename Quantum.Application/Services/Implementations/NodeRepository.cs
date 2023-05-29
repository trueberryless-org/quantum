using Quantum.Application.Services.Interfaces;
using Quantum.Domain.Configuration;
using Quantum.Domain.Entities;

namespace Quantum.Application.Services.Implementations;

public class NodeRepository : ARepository<Node>, INodeRepository
{
    public NodeRepository(ModelDbContext context) : base(context)
    {
    }
}