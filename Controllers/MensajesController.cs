using WebAPI.Models;
using WebAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MensajesController : ControllerBase
{
    private readonly MensajesService mensajesService;

    public MensajesController(MensajesService mensajesService) =>
        this.mensajesService = mensajesService;

    [HttpGet]
    public async Task<List<Mensaje>> Get() =>
        await mensajesService.GetMensajes();

    [HttpGet("{id}")]
    public async Task<ActionResult<Mensaje>> Get(Guid id)
    {
        var mensaje = await mensajesService.GetMensajesById(id);

        if (mensaje is null)
        {
            return NotFound();
        }

        return mensaje;
    }

    [HttpPost]
    public async Task<IActionResult> Post(Mensaje newMensaje)
    {
        await mensajesService.CreateMensaje(newMensaje);

        return CreatedAtAction(nameof(Get), new { Identificador = newMensaje.Identificador }, newMensaje);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(Guid id, Mensaje updatedMensaje)
    {
        var mensaje = await mensajesService.GetMensajesById(id);

        if (mensaje is null)
        {
            return NotFound();
        }

        updatedMensaje.Identificador = mensaje.Identificador;

        await mensajesService.UpdateMensaje(id, updatedMensaje);

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var mensaje = await mensajesService.GetMensajesById(id);

        if (mensaje is null)
        {
            return NotFound();
        }

        await mensajesService.RemoveMensaje(id);

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

    //[HttpGet("getSeguidores")]
    //public async Task<ActionResult<List<string>>> seguidores(string email)
    //{
    //    var seguidores = await sigueMeService.GetSeguidores(email);

    //    if (seguidores is null)
    //    {
    //        return NotFound();
    //    }

    //    return seguidores;
    //}
}