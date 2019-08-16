using ItinerarioSNC.Domain.Dtos;
using ItinerarioSNC.Domain.Entities;
using ItinerarioSNC.Service.Services;
using ItinerarioSNC.Service.Validators;
using Microsoft.AspNetCore.Mvc;
using System;
using AutoMapper;

namespace ItinerarioSNC.Application.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class AnaliseAgendamentoController : ControllerBase
    {
        private readonly BaseService<AnaliseAgendamento> analiseAgendamentoService;

        public AnaliseAgendamentoController(BaseService<AnaliseAgendamento> analiseAgendamentoService)
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