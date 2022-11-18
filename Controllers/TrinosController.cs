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

    [HttpGet("getTrinos/{email}")]
    public async Task<ActionResult<List<Trinos>>> trinosPorUsuario(string email)
    {
        var trinos = await trinosService.GetTrinosPorUsuario(email);

        if (trinos is null)
        {
            return NotFound();
        }

        return trinos;
    }

    [HttpGet("getTrinosPorTema/{tema}")]
    public async Task<ActionResult<List<Trinos>>> trinosPorTema(string tema)
    {
        var trinos = await trinosService.GetTrinosPorTema(tema);

        if (trinos is null)
        {
            return NotFound();
        }

        return trinos;
    }

    [HttpGet("getTrinosSeguidos/{email}")]
    public async Task<ActionResult<List<Trinos>>> trinosSeguidos(string email)
    {
        var trinos = await trinosService.GetTrinosSeguidos(email);

        if (trinos is null)
        {
            return NotFound();
        }

        return trinos;
    }

    [HttpGet("getByDate/{date}")]
    public async Task<ActionResult<List<Trinos>>> trinosPorFecha(DateTime date)
    {
        var trinos = await trinosService.GetTrinosPorFecha(date);

        if (trinos is null)
        {
            return NotFound();
        }

        return trinos;
    }

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

    //[HttpPut("{id}")]
    //public async Task<IActionResult> Update(Guid id, Trinos updatedTrinos)
    //{
    //    var trinos = await trinosService.GetTrinosById(id);

    //    if (trinos is null)
    //    {
    //        return NotFound();
    //    }

    //    updatedTrinos.Id = trinos.Id;

    //    await trinosService.UpdateTrinos(id, updatedTrinos);

    //    return NoContent();
    //}

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