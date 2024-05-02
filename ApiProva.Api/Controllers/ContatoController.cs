using ApiProva.Data.Migrations;
using ApiProva.Domain.Entities;
using ApiProva.Service.DTO;
using ApiProva.Service.Service.Interface;
using ApiProva.Service.ViewModel;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace ApiProva.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ContatoController : ControllerBase
    {
        private readonly IContatoService _contatoService;
        private readonly ILogger<ContatoController> _logger;
        private readonly IMapper _mapper;

        //construtor
        public ContatoController(ILogger<ContatoController> logger, IContatoService contato, IMapper mapper)
        {
            _contatoService = contato;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                return Ok(await _contatoService.GetAll());
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
            
        }

        [HttpPost("Incluir")]
        public async Task<IActionResult> Incluir([FromBody] ContatoDTO contato)
        {
            try
            {

                return Ok(await _contatoService.Incluir(_mapper.Map<ContatoViewModel>(contato)));
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
            
        }

        [HttpPut("Alterar/{id:guid}")]
        public async Task<IActionResult> Alterar([FromBody] ContatoViewModel obj)
        {
            try
            {
                return Ok(await _contatoService.Alterar(obj));
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
            
        }

        [HttpPut("Desativar/{id:guid}")]
        public async Task<IActionResult> Desativar([FromRoute] Guid id)
        {
            try
            {
                return Ok(await _contatoService.Desativar(id));
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }

        [HttpGet("RetornarPorId/{id:guid}")]
        public async Task<IActionResult> RetornaPorId([FromRoute] Guid id)
        {
            return Ok(await _contatoService.RetornaPorId(id));
        }

        [HttpDelete("Excluir/{id:guid}")]
        public async Task<IActionResult> Excluir([FromRoute] Guid id)
        {
            try
            {
                return Ok(await _contatoService.Excluir(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

    }
}
