using WebAPI.Models;
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
        await viviendasService.GetAsync();

    [HttpGet("{id}")]
    public async Task<ActionResult<Vivienda>> Get(Guid id)
    {
        var vivienda = await viviendasService.GetAsync(id);

        if (vivienda is null)
        {
            return NotFound();
        }

        return vivienda;
    }

    [HttpPost]
    public async Task<IActionResult> Post(Vivienda newVivienda)
    {
        await viviendasService.CreateAsync(newVivienda);

        return CreatedAtAction(nameof(Get), new { id = newVivienda.Id }, newVivienda);
    }

    //[HttpPut("{id:length(24)}")]
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(Guid id, Vivienda updatedVivienda)
    {
        var vivienda = await viviendasService.GetAsync(id);

        if (vivienda is null)
        {
            return NotFound();
        }

        updatedVivienda.Id = vivienda.Id;

        await viviendasService.UpdateAsync(id, updatedVivienda);

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var vivienda = await viviendasService.GetAsync(id);

        if (vivienda is null)
        {
            return NotFound();
        }

        await viviendasService.RemoveAsync(id);

        return NoContent();
    }
}