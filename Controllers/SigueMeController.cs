using WebAPI.Models;
using WebAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SigueMeController : ControllerBase
{
    private readonly SigueMeService sigueMeService;

    public SigueMeController(SigueMeService sigueMeService) =>
        this.sigueMeService = sigueMeService;

    [HttpGet]
    public async Task<List<SigueMe>> Get() =>
        await sigueMeService.GetSigueMe();

    [HttpGet("{id}")]
    public async Task<ActionResult<SigueMe>> Get(Guid id)
    {
        var sigueMe = await sigueMeService.GetSigueMeById(id);

        if (sigueMe is null)
        {
            return NotFound();
        }

        return sigueMe;
    }

    [HttpPost]
    public async Task<IActionResult> Post(SigueMe newSigueMe)
    {
        await sigueMeService.CreateSigueMe(newSigueMe);

        return CreatedAtAction(nameof(Get), new { id = newSigueMe.Id }, newSigueMe);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(Guid id, SigueMe updatedSigueMe)
    {
        var sigueMe = await sigueMeService.GetSigueMeById(id);

        if (sigueMe is null)
        {
            return NotFound();
        }

        updatedSigueMe.Id = sigueMe.Id;

        await sigueMeService.UpdateSigueMe(id, updatedSigueMe);

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var sigueMe = await sigueMeService.GetSigueMeById(id);

        if (sigueMe is null)
        {
            return NotFound();
        }

        await sigueMeService.RemoveSigueMe(id);

        return NoContent();
    }

    //[HttpGet("getByInquilino/{inquilinoId}")]
    //public async Task<ActionResult<SigueMe>> GetByInquilino(Guid inquilinoId)
    //{
    //    var reserva = await sigueMeService.GetReservaByInquilinoId(inquilinoId);

    //    if (reserva is null)
    //    {
    //        return NotFound();
    //    }

    //    return reserva;
    //}

    //[HttpGet("getByVivienda/{viviendaId}")]
    //public async Task<ActionResult<List<SigueMe>>> GetByVivienda(Guid id)
    //{
    //    var sigueMes = await sigueMeService.GetReservasByVivienda(id);

    //    if (sigueMes is null)
    //    {
    //        return NotFound();
    //    }

    //    return sigueMes;
    //}

    //[HttpGet("getByFecha")]
    //public async Task<ActionResult<List<SigueMe>>> GetByVivienda(string fechaEntrada, string fechaSalida)
    //{
    //    var sigueMes = await sigueMeService.GetSigueMeByFecha(fechaEntrada, fechaSalida);

    //    if (sigueMes is null)
    //    {
    //        return NotFound();
    //    }

    //    return sigueMes;
    //}
}