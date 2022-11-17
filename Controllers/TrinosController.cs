using WebAPI.Models;
using WebAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TrinosController : ControllerBase
{
    private readonly TrinosService trinosService;

    public TrinosController(TrinosService trinosService) =>
        this.trinosService = trinosService;

    [HttpGet]
    public async Task<List<Trinos>> Get() =>
        await trinosService.GetTrinos();

    [HttpGet("{id}")]
    public async Task<ActionResult<Trinos>> Get(Guid id)
    {
        var trinos = await trinosService.GetTrinosById(id);

        if (trinos is null)
        {
            return NotFound();
        }

        return trinos;
    }
    //[HttpGet("getByPropietario/{id}")]
    //public async Task<ActionResult<Trinos>> GetByPropietario(Guid id)
    //{
    //    var vivienda = await viviendasService.GetViviendasByPropietario(id);

    //    if (vivienda is null)
    //    {
    //        return NotFound();
    //    }

    //    return vivienda;
    //}

    //[HttpGet("getByLocalidad/")]
    //public async Task<ActionResult<List<Trinos>>> GetByLocalidad(string localidad)
    //{
    //    var viviendas = await viviendasService.GetViviendasByLocalidad(localidad);

    //    if (viviendas is null)
    //    {
    //        return NotFound();
    //    }

    //    return viviendas;
    //}

    [HttpPost]
    public async Task<IActionResult> Post(Trinos newTrinos)
    {
        await trinosService.CreateTrinos(newTrinos);

        return CreatedAtAction(nameof(Get), new { id = newTrinos.Id }, newTrinos);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(Guid id, Trinos updatedTrinos)
    {
        var trinos = await trinosService.GetTrinosById(id);

        if (trinos is null)
        {
            return NotFound();
        }

        updatedTrinos.Id = trinos.Id;

        await trinosService.UpdateTrinos(id, updatedTrinos);

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var trinos = await trinosService.GetTrinosById(id);

        if (trinos is null)
        {
            return NotFound();
        }

        await trinosService.RemoveTrinos(id);

        return NoContent();
    }
}