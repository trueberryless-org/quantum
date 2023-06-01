using System.Linq.Expressions;
using Mapster;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Quantum.Application.Services.Interfaces;
using Quantum.WebAPI.Services;

namespace Quantum.WebAPI.Controllers;

public abstract class AController<TEntity, TReadEntityDto> : ControllerBase
    where TEntity : class
    where TReadEntityDto : class
{
    private readonly IRepository<TEntity> _repository;

    public AController(IRepository<TEntity> repository)
    {
        _repository = repository;
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<TReadEntityDto?>> ReadAsync(int id)
    {
        var entity = await _repository.ReadAsync(id);
        if (entity is null) return NotFound();
        return Ok(entity.Adapt<TReadEntityDto>());
    }

    [HttpGet("{filter}")]
    public async Task<ActionResult<List<TReadEntityDto>>> ReadAsync([FromBody] FilterModel<TEntity> filterModel)
    {
        var filter = filterModel.GetFilterExpression();
        var entities = await _repository.ReadAsync(filter);
        return Ok(entities.Select(e => e.Adapt<TReadEntityDto>()));
    }

    [HttpGet("{start:int}/{count:int}")]
    public async Task<ActionResult<TReadEntityDto?>> ReadAsync(int start, int count)
    {
        var entities = await _repository.ReadAsync(start, count);
        return Ok(entities.Select(e => e.Adapt<TReadEntityDto>()));
    }

    [HttpGet]
    public async Task<ActionResult<TReadEntityDto?>> ReadAsync()
    {
        var entities = await _repository.ReadAsync();
        return Ok(entities.Select(e => e.Adapt<TReadEntityDto>()));
    }
}