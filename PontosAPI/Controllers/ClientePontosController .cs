using Microsoft.AspNetCore.Mvc;
using PontosAPI.Models;
using PontosAPI.Services;

namespace PontosAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientePontosController : ControllerBase
    {
        private readonly ClientePontosService _service;

        public ClientePontosController(ClientePontosService service)
        {
            _service = service;
        }

        [HttpGet("{cpf}")]
        public ActionResult<ClientePontos> GetCliente(string cpf)
        {
            var cliente = _service.GetCliente(cpf);
            if (cliente == null)
            {
                return NotFound();
            }
            return Ok(cliente);
        }

        [HttpPost("{id}/adicionar-pontos/{pontos}")]
        public IActionResult AdicionarPontos(int id, int pontos)
        {
            _service.AdicionarPontos(id, pontos);
            return Ok("Pontos adicionados com sucesso!");
        }
    }
}
