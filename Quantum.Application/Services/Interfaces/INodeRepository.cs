using Quantum.Domain.Entities;

namespace Quantum.Application.Services.Interfaces;

public interface INodeRepository : IRepository<Node>
{
    Task<Node> IncludeChildren(Node currentNode, int levelAmount = 1);
}