using Microsoft.EntityFrameworkCore;
using Quantum.Application.Services.Interfaces;
using Quantum.Domain.Configuration;
using Quantum.Domain.Entities;

namespace Quantum.Application.Services.Implementations;

public class NodeRepository : ARepository<Node>, INodeRepository
{
    public NodeRepository(ModelDbContext context) : base(context)
    {
    }

    public async Task<Node> IncludeChildren(Node currentNode, int levelAmount)
    {
        if (levelAmount <= 0)
            return currentNode;

        // Including immediate children
        currentNode = await Context.Nodes
            .Include(n => n.Children)
            .FirstAsync(n => n.Id == currentNode.Id);

        // Including children's children recursively
        foreach (var child in currentNode.Children)
        {
            await IncludeChildren(child, levelAmount - 1);
        }

        return currentNode;
    }
}