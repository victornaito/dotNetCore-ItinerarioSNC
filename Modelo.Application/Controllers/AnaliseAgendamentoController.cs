using ItinerarioSNC.Domain.Dtos;
using ItinerarioSNC.Domain.Entities;
using ItinerarioSNC.Infra.Data.AutoMapper;
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

        [HttpPost]
        public IActionResult Post([FromBody] AnaliseAgendamentoDto item)
        {
            try
            {
                var analiseAgendamento = AutoMapperProfile.Map<AnaliseAgendamentoDto, AnaliseAgendamento>(item);
                analiseAgendamentoService.Post<AnaliseAgendamentoValidator>(analiseAgendamento);

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

        [HttpGet]
        public IActionResult Get([FromQuery] AnaliseAgendamentoDto item)
        {
            try
            {
                //var analiseAgendamento = AutoMapperProfile.Map<AnaliseAgendamentoDto, AnaliseAgendamento>(item);
                return new ObjectResult(analiseAgendamentoService.GetAll());
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