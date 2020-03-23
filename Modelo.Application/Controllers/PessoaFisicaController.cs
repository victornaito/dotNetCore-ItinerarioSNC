using ItinerarioSNC.Domain.Entities;
using ItinerarioSNC.Service.Services;
using ItinerarioSNC.Service.Validators;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

[Produces("application/json")]
[Route("api/[controller]")]
[ApiController]
public class PessoaFisicaController : ControllerBase
{
    private readonly BaseService<PessoaFisica> pessoaFisicaService;

    public PessoaFisicaController(BaseService<PessoaFisica> pessoaFisicaService)
    {
        this.pessoaFisicaService = pessoaFisicaService;
    }

    [HttpPost]
    public IActionResult Post([FromBody] PessoaFisica item)
    {
        try
        {
            pessoaFisicaService.Post<PessoaFisicaValidator>(item);

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

    [HttpPut]
    public async Task<IActionResult> PutAsync([FromBody] PessoaFisica item)
    {
        try
        {
            await pessoaFisicaService.Put<PessoaFisicaValidator>(item);

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

    [HttpDelete]
    public IActionResult Delete(int id)
    {
        try
        {
            pessoaFisicaService.Delete(id);

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

    [AllowAnonymous]
    [HttpGet("Token")]
    public IActionResult GetToken() => Ok(pessoaFisicaService.tokenJWTService.GerarToken());

    [Authorize]
    [HttpGet]

    public IActionResult Get()
    {
        try
        {
            return new ObjectResult(pessoaFisicaService.GetAll());
        }
        catch (Exception ex)
        {
            return BadRequest(ex);
        }
    }

    [HttpGet("GetPersonById/{id}")]
    public IActionResult Get(int id)
    {
        try
        {
            return new ObjectResult(pessoaFisicaService.Get(id));
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
    public string Ping()
    {
        return  "A data eh:" + DateTime.Now.ToString();
    }
}