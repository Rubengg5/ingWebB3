using WebAPI.Models;
using WebAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ReservasController : ControllerBase
{
    private readonly ReservasService reservasService;

    public ReservasController(ReservasService reservasService) =>
        this.reservasService = reservasService;

    [HttpGet]
    public async Task<List<Reserva>> Get() =>
        await reservasService.GetAsync();

    [HttpGet("{id}")]
    public async Task<ActionResult<Reserva>> Get(Guid id)
    {
        var reserva = await reservasService.GetAsync(id);

        if (reserva is null)
        {
            return NotFound();
        }

        return reserva;
    }

    [HttpPost]
    public async Task<IActionResult> Post(Reserva newReserva)
    {
        await reservasService.CreateAsync(newReserva);

        return CreatedAtAction(nameof(Get), new { id = newReserva.Id }, newReserva);
    }

    //[HttpPut("{id:length(24)}")]
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(Guid id, Reserva updatedReserva)
    {
        var reserva = await reservasService.GetAsync(id);

        if (reserva is null)
        {
            return NotFound();
        }

        updatedReserva.Id = reserva.Id;

        await reservasService.UpdateAsync(id, updatedReserva);

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var reserva = await reservasService.GetAsync(id);

        if (reserva is null)
        {
            return NotFound();
        }

        await reservasService.RemoveAsync(id);

        return NoContent();
    }
}