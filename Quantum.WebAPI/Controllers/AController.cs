using System.Linq.Expressions;
using Mapster;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Quantum.Application.Services.Interfaces;
using Quantum.WebAPI.Services;

namespace Quantum.WebAPI.Controllers;

public class AController<TEntity, TEntityDto> : ControllerBase where TEntity : class
{
    private readonly IRepository<TEntity> _repository;

    public AController(IRepository<TEntity> repository)
    {
        _repository = repository;
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<TEntityDto?>> ReadAsync(int id)
    {
        var entity = await _repository.ReadAsync(id);
        if (entity is null) return NotFound();
        return Ok(entity.Adapt<TEntityDto>());
    }

    [HttpGet("{filter}")]
    public async Task<ActionResult<List<TEntityDto>>> ReadAsync([FromBody] FilterModel<TEntity> filterModel)
    {
        var filter = filterModel.GetFilterExpression();
        var entities = await _repository.ReadAsync(filter);
        return Ok(entities.Select(e => e.Adapt<TEntityDto>()));
    }
    
    [HttpGet("{start:int}/{count:int}")]
    public async Task<ActionResult<TEntityDto?>> ReadAsync(int start, int count)
    {
        var entities = await _repository.ReadAsync(start, count);
        return Ok(entities.Select(e => e.Adapt<TEntityDto>()));
    }
    
    [HttpGet]
    public async Task<ActionResult<TEntityDto?>> ReadAsync()
    {
        var entities = await _repository.ReadAsync();
        return Ok(entities.Select(e => e.Adapt<TEntityDto>()));
    }
}