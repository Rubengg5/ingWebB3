﻿using WebAPI.Models;
using WebAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ViviendasController : ControllerBase
{
    private readonly ViviendasService viviendasService;

    public ViviendasController(ViviendasService viviendasService) =>
        this.viviendasService = viviendasService;

    [HttpGet]
    public async Task<List<Vivienda>> Get() =>
        await viviendasService.GetViviendas();

    [HttpGet("{id}")]
    public async Task<ActionResult<Vivienda>> Get(Guid id)
    {
        var vivienda = await viviendasService.GetViviendaById(id);

        if (vivienda is null)
        {
            return NotFound();
        }

        return vivienda;
    }
    [HttpGet("/getByUsuario/{id}")]
    public async Task<ActionResult<Vivienda>> GetByUsuario(Guid id)
    {
        var vivienda = await viviendasService.GetViviendasByUsuario(id);

        if (vivienda is null)
        {
            return NotFound();
        }

        return vivienda;
    }
    [HttpPost]
    public async Task<IActionResult> Post(Vivienda newVivienda)
    {
        await viviendasService.CreateVivienda(newVivienda);

        return CreatedAtAction(nameof(Get), new { id = newVivienda.Id }, newVivienda);
    }

    //[HttpPut("{id:length(24)}")]
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(Guid id, Vivienda updatedVivienda)
    {
        var vivienda = await viviendasService.GetViviendaById(id);

        if (vivienda is null)
        {
            return NotFound();
        }

        updatedVivienda.Id = vivienda.Id;

        await viviendasService.UpdateVivienda(id, updatedVivienda);

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var vivienda = await viviendasService.GetViviendaById(id);

        if (vivienda is null)
        {
            return NotFound();
        }

        await viviendasService.RemoveVivienda(id);

        return NoContent();
    }
}