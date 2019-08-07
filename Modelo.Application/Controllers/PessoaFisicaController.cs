using ItinerarioSNC.Domain.Entities;
using ItinerarioSNC.Service.Services;
using ItinerarioSNC.Service.Validators;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

[Produces("application/json")]
[Route("api/[controller]")]
public class PessoaFisicaController : Controller
{
    private BaseService<PessoaFisica> service = new BaseService<PessoaFisica>();

    public IActionResult Post([FromBody] PessoaFisica item)
    {
        try
        {
            service.Post<PessoaFisicaValidator>(item);

            return new ObjectResult(item.Id);
        }
        catch (ArgumentNullException ex)
        {
            return NotFound(ex);
        }
        catch (Exception ex)
        {
            return BadRequest(ex);
        }
    }

    public async Task<IActionResult> PutAsync([FromBody] PessoaFisica item)
    {
        try
        {
            await service.Put<PessoaFisicaValidator>(item);

            return new ObjectResult(item);
        }
        catch (ArgumentNullException ex)
        {
            return NotFound(ex);
        }
        catch (Exception ex)
        {
            return BadRequest(ex);
        }
    }

    public IActionResult Delete(int id)
    {
        try
        {
            service.Delete(id);

            return new NoContentResult();
        }
        catch (ArgumentException ex)
        {
            return NotFound(ex);
        }
        catch (Exception ex)
        {
            return BadRequest(ex);
        }
    }

    public IActionResult Get()
    {
        try
        {
            return new ObjectResult(service.GetAll());
        }
        catch (Exception ex)
        {
            return BadRequest(ex);
        }
    }

    public IActionResult Get(int id)
    {
        try
        {
            return new ObjectResult(service.Get(id));
        }
        catch (ArgumentException ex)
        {
            return NotFound(ex);
        }
        catch (Exception ex)
        {
            return BadRequest(ex);
        }
    }

    [HttpGet("ping")]
    public DateTime Ping()
    {
        return DateTime.Now;
    }
}