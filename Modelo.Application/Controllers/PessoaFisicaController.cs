using ItinerarioSNC.Application.Utils;
using ItinerarioSNC.Domain.Dtos;
using ItinerarioSNC.Domain.Entities;
using ItinerarioSNC.Infra.Data.AutoMapper;
using ItinerarioSNC.Service.Validators;
using ItnerarioSNC.Generics;
using ItnerarioSNC.Generics.ApplicationCore.Base.Interfaces.Services;
using ItnerarioSNC.Generics.Infra.Base.TokenJWT;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
[Role(new string[] { "Admin" })]
public class PessoaFisicaController : BaseController
{
    private readonly IBaseService<PessoaFisica> pessoaFisicaService;

    public PessoaFisicaController(ITokenJWTService tokenJWTService,
                                  IBaseService<PessoaFisica> pessoaFisicaService
                                 ) : base(tokenJWTService)
    {
        this.pessoaFisicaService = pessoaFisicaService;
        var role = Attribute.GetCustomAttributes(typeof(PessoaFisicaController)).FirstOrDefault(r => r is RoleAttribute);
        System.Console.WriteLine(((RoleAttribute)role).RolesDescription);
    }

    [HttpPost]
    public IActionResult Post([FromBody] PessoaFisicaDto item)
    {
        var pessoaFisica = AutoMapperProfile.Map<PessoaFisicaDto, PessoaFisica>(item);
        var retorno = pessoaFisicaService.Post<PessoaFisicaValidator>(pessoaFisica);

        return new OkObjectResult(retorno.Id);
    }

    [HttpPost("login")]
    public IActionResult Login([FromBody] PessoaFisicaDto item)
    {
        var person = new { Id = 1, Nome = "victor naito"};
        return new OkObjectResult(person);
    }

    [HttpPut]
    public async Task<IActionResult> PutAsync([FromBody] PessoaFisicaDto item)
    {

        PessoaFisica pessoaFisica = AutoMapperProfile.Map<PessoaFisicaDto, PessoaFisica>(item);
        await pessoaFisicaService.Put<PessoaFisicaValidator>(pessoaFisica);

        return new OkObjectResult(item);
    }

    [HttpDelete]
    public IActionResult Delete(int id)
    {
        pessoaFisicaService.Delete(id);

        return new OkResult();
    }


    [HttpGet]
    public IActionResult Get()
    {
        return new OkObjectResult(pessoaFisicaService.GetAll());
    }

    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
        return new OkObjectResult(pessoaFisicaService.Get(id));
    }
}