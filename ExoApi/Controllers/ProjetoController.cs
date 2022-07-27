using ExoApi.Models;
using ExoApi.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExoApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class ProjetoController : ControllerBase
    {
        private readonly ProjetoRepository _projetoRepository;

        public ProjetoController(ProjetoRepository projetoRepository)
        {
            _projetoRepository = projetoRepository;
        }
        [HttpGet]
        public IActionResult Listar()
        {
            try
            {
                return Ok(_projetoRepository.Listar());
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        [HttpGet("{id}")]

        public ActionResult BuscarPorId(int id)

        {

            try
            {
                Projeto ProjetoBuscado = _projetoRepository.BuscarPorId(id);

                if (ProjetoBuscado == null)
                {
                    return NotFound();
                }

                return Ok(ProjetoBuscado);
            }

            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        [HttpPost]
        public IActionResult Cadastrar(Projeto projeto)
        {
            try
            {
                _projetoRepository.Cadastrar(projeto);
                //return StatusCode(201);
                return Ok("Projeto criado com sucesso");
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            try
            {
                _projetoRepository.Deletar(id);
                return Ok("Projeto removido");
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        [HttpPut("{id}")]

        public IActionResult Alterar(int id, Projeto projeto)
        {
            try
            {
                _projetoRepository.Atualizar(id, projeto);
                return StatusCode(204);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

    }
}
