using ItinerarioSNC.Domain.Entities;
using ItinerarioSNC.Service.Validators;
using ItnerarioSNC.Generics;
using ItnerarioSNC.Generics.ApplicationCore.Base.Interfaces.Services;
using ItnerarioSNC.Generics.Infra.Base.TokenJWT;
using Microsoft.AspNetCore.Mvc;
using System;

namespace ItinerarioSNC.Application.Controllers
{
    public class AnaliseAgendamentoController : BaseController
    {
        private readonly IBaseService<AnaliseAgendamento> analiseAgendamentoService;

        public AnaliseAgendamentoController(ITokenJWTService tokenJWTService, IBaseService<AnaliseAgendamento> analiseAgendamentoService) : base(tokenJWTService)
        {
            this.analiseAgendamentoService = analiseAgendamentoService;
        }

        public IActionResult Post([FromBody] AnaliseAgendamento item)
        {
            try
            {
                analiseAgendamentoService.Post<AnaliseAgendamentoValidator>(item);

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
    }
}