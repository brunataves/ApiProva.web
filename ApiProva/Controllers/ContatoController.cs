using ApiProva.Service.Service;
using ApiProva.Service.Service.Interface;
using Microsoft.AspNetCore.Mvc;

namespace ApiProva.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ContatoController : ControllerBase
    {
        private readonly IContatoService _contatoService;
        private readonly ILogger<ContatoController> _logger;

        //construtor
        public ContatoController(ILogger<ContatoController> logger, IContatoService contato)
        {
            _contatoService = contato;
            _logger = logger;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _contatoService.GetAll());
        }
    }
}
