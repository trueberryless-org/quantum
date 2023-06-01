using Mapster;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Quantum.Application.Services.Interfaces;
using Quantum.Domain.Entities;
using Quantum.WebAPI.Dtos;

namespace Quantum.WebAPI.Controllers;

[ApiController]
[Route("/nodes")]
public class NodeController : AController<Node, ReadNodeDto>
{
    public NodeController(INodeRepository repository) : base(repository)
    {
        
    }
}