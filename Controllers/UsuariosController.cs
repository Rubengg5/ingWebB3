using WebAPI.Models;
using WebAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsuariosController : ControllerBase
{
    private readonly UsuariosService usuariosService;

    public UsuariosController(UsuariosService usuariosService) =>
        this.usuariosService = usuariosService;

    [HttpGet]
    public async Task<List<Usuario>> Get() =>
        await usuariosService.GetUsuarios();


    [HttpGet("{telefono}")]
    public async Task<ActionResult<Usuario>> Get(int telefono)
    {
        var usuario = await usuariosService.GetUsuariosByTelefono(telefono);

        if (usuario is null)
        {
            return NotFound();
        }

        return usuario;
    }

    [HttpPost]
    public async Task<IActionResult> Post(Usuario newUsuario)
    {
        await usuariosService.CreateUsuario(newUsuario);

        return CreatedAtAction(nameof(Get), new { Telefono = newUsuario.Telefono }, newUsuario);
    }

    [HttpPut("{telefono}")]
    public async Task<IActionResult> Update(int telefono, Usuario updatedTrinos)
    {
        var usuario = await usuariosService.GetUsuariosByTelefono(telefono);

        if (usuario is null)
        {
            return NotFound();
        }

        updatedTrinos.Telefono = usuario.Telefono;

        await usuariosService.UpdateUsuario(telefono, updatedTrinos);

        return NoContent();
    }

    [HttpDelete("{telefono}")]
    public async Task<IActionResult> Delete(int telefono)
    {
        var usuario = await usuariosService.GetUsuariosByTelefono(telefono);

        if (usuario is null)
        {
            return NotFound();
        }

        await usuariosService.RemoveUsuario(telefono);

        return NoContent();
    }


    [HttpGet("getByAlias/{alias}")]
    public async Task<ActionResult<List<Usuario>>> UsuarioPorAlias(string alias)
    {
        var usuario = await usuariosService.GetUsuarioPorAlias(alias);

        if (usuario is null)
        {
            return NotFound();
        }

        return usuario;
    }

    [HttpGet("getContactos/{telefono}")]
    public async Task<List<Usuario>> Contactos(int telefono)
    {
        return await usuariosService.GetContactos(telefono);
    }


    [HttpGet("getContacto/{telefono}/{telefonoContacto}")]
    public async Task<ActionResult<Usuario>> ContactoPorTelefono(int telefono, int telefonoContacto)
    {
        var usuario = await usuariosService.GetContactoPorTelefono(telefono, telefonoContacto);

        if (usuario is null)
        {
            return NotFound();
        }

        return usuario;
    }

    [HttpPost("{telefono}")]
    public async Task<IActionResult> PostContacto(int telefono, Usuario newContacto)
    {
        await usuariosService.CreateContacto(telefono, newContacto);

        return CreatedAtAction(nameof(Get), new { Telefono = newContacto.Telefono }, newContacto);
    }

    //[HttpPut("{telefono}")]
    //public async Task<IActionResult> Update(int telefono, Usuario updatedTrinos)
    //{
    //    var usuario = await usuariosService.GetUsuariosByTelefono(telefono);

    //    if (usuario is null)
    //    {
    //        return NotFound();
    //    }

    //    updatedTrinos.Telefono = usuario.Telefono;

    //    await usuariosService.UpdateUsuario(telefono, updatedTrinos);

    //    return NoContent();
    //}

    //[HttpDelete("{telefono}")]
    //public async Task<IActionResult> Delete(int telefono)
    //{
    //    var usuario = await usuariosService.GetUsuariosByTelefono(telefono);

    //    if (usuario is null)
    //    {
    //        return NotFound();
    //    }

    //    await usuariosService.RemoveUsuario(telefono);

    //    return NoContent();
    //}


    //[HttpGet("getByAlias/{alias}")]
    //public async Task<ActionResult<List<Usuario>>> UsuarioPorAlias(string alias)
    //{
    //    var usuario = await usuariosService.GetUsuarioPorAlias(alias);

    //    if (usuario is null)
    //    {
    //        return NotFound();
    //    }

    //    return usuario;
    //}

    //[HttpGet("{id}")]
    //public async Task<ActionResult<Trinos>> Get(Guid id)
    //{
    //    var trinos = await usuariosService.GetUsuariosById(id);

    //    if (trinos is null)
    //    {
    //        return NotFound();
    //    }

    //    return trinos;
    //}


    //[HttpGet("getTrinosPorTema/{tema}")]
    //public async Task<ActionResult<List<Trinos>>> trinosPorTema(string tema)
    //{
    //    var trinos = await usuariosService.GetTrinosPorTema(tema);

    //    if (trinos is null)
    //    {
    //        return NotFound();
    //    }

    //    return trinos;
    //}

    //[HttpGet("getTrinosSeguidos/{email}")]
    //public async Task<ActionResult<List<Trinos>>> trinosSeguidos(string email)
    //{
    //    var trinos = await usuariosService.GetTrinosSeguidos(email);

    //    if (trinos is null)
    //    {
    //        return NotFound();
    //    }

    //    return trinos;
    //}

    //[HttpGet("getByDate/{date}")]
    //public async Task<ActionResult<List<Trinos>>> trinosPorFecha(DateTime date)
    //{
    //    var trinos = await usuariosService.GetTrinosPorFecha(date);

    //    if (trinos is null)
    //    {
    //        return NotFound();
    //    }

    //    return trinos;
    //}

    ////[HttpGet("getByLocalidad/")]
    ////public async Task<ActionResult<List<Trinos>>> GetByLocalidad(string localidad)
    ////{
    ////    var viviendas = await viviendasService.GetViviendasByLocalidad(localidad);

    ////    if (viviendas is null)
    ////    {
    ////        return NotFound();
    ////    }

    ////    return viviendas;
    ////}

}