using WebAPI.Models;
using WebAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class Trinos1Controller : ControllerBase
{
    private readonly TrinosService trinosService;

    public Trinos1Controller(TrinosService viviendasService) =>
        this.trinosService = viviendasService;

    [HttpGet]
    public async Task<List<Trinos>> Get() =>
        await trinosService.GetTrinos();

    //[HttpGet("{id}")]
    //public async Task<ActionResult<Trinos>> Get(Guid id)
    //{
    //    var vivienda = await viviendasService.GetViviendaById(id);

    //    if (vivienda is null)
    //    {
    //        return NotFound();
    //    }

    //    return vivienda;
    //}
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

    //[HttpPost]
    //public async Task<IActionResult> Post(Trinos newVivienda)
    //{
    //    await viviendasService.CreateVivienda(newVivienda);

    //    return CreatedAtAction(nameof(Get), new { id = newVivienda.Id }, newVivienda);
    //}

    //[HttpPut("{id}")]
    //public async Task<IActionResult> Update(Guid id, Trinos updatedVivienda)
    //{
    //    var vivienda = await viviendasService.GetViviendaById(id);

    //    if (vivienda is null)
    //    {
    //        return NotFound();
    //    }

    //    updatedVivienda.Id = vivienda.Id;

    //    await viviendasService.UpdateVivienda(id, updatedVivienda);

    //    return NoContent();
    //}

    //[HttpDelete("{id}")]
    //public async Task<IActionResult> Delete(Guid id)
    //{
    //    var vivienda = await viviendasService.GetViviendaById(id);

    //    if (vivienda is null)
    //    {
    //        return NotFound();
    //    }

    //    await viviendasService.RemoveVivienda(id);

    //    return NoContent();
    //}
}