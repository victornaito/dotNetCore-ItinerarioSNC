using ItinerarioSNC.Domain.Dtos;
using ItinerarioSNC.Domain.Entities;
using ItinerarioSNC.Infra.Data.AutoMapper;
using ItinerarioSNC.Service.Validators;
using ItnerarioSNC.Generics;
using ItnerarioSNC.Generics.ApplicationCore.Base.Interfaces.Services;
using ItnerarioSNC.Generics.Infra.Base.TokenJWT;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;


public class PessoaFisicaController : BaseController
{
    private readonly ITokenJWTService tokenJWTService;
    private readonly IBaseService<PessoaFisica> pessoaFisicaService;

    public PessoaFisicaController(ITokenJWTService tokenJWTService
        , IBaseService<PessoaFisica> pessoaFisicaService
        ) : base(tokenJWTService)
    {
        this.tokenJWTService = tokenJWTService;
        this.pessoaFisicaService = pessoaFisicaService;
    }

    [HttpPost]
    public IActionResult Post([FromBody] PessoaFisicaDto item)
    {
        try
        {
            PessoaFisica pessoaFisica = AutoMapperProfile.Map<PessoaFisicaDto, PessoaFisica>(item);
            PessoaFisica retorno = pessoaFisicaService.Post<PessoaFisicaValidator>(pessoaFisica);

            return new ObjectResult(retorno.Id);
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
    public async Task<IActionResult> PutAsync([FromBody] PessoaFisicaDto item)
    {
        try
        {
            PessoaFisica pessoaFisica = AutoMapperProfile.Map<PessoaFisicaDto, PessoaFisica>(item);
            await pessoaFisicaService.Put<PessoaFisicaValidator>(pessoaFisica);

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
    public IActionResult GetToken() => Ok(this.tokenJWTService.GerarToken());

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