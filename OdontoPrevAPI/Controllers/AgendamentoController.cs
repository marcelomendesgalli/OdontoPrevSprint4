using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OdontoPrevAPI.Model;
using OdontoPrevAPI.Repository.Interface;

namespace OdontoPrevAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AgendamentoController : ControllerBase
    {
        private readonly IAgendamentoRepository _IAgendamentoRepository;
        private static int _id = 0;

        public AgendamentoController(IAgendamentoRepository IAgendamentoRepository)
        {
            _IAgendamentoRepository = IAgendamentoRepository;
        }
        
        /// Retorna todos os agendamentos cadastrados.
        /// <returns>Lista de agendamentos.</returns>
        /// <response code="200">Listagem realizada com sucesso.</response>
        [HttpGet]
        public async Task<ActionResult> Index()
        {
            return Ok(await _IAgendamentoRepository.Listar());
        }
        
        /// Retorna um agendamento específico pelo ID.
        /// <param name="id">ID do agendamento.</param>
        /// <returns>Dados do agendamento.</returns>
        /// <response code="200">Agendamento encontrado com sucesso.</response>
        /// <response code="404">Agendamento não encontrado.</response>
        [HttpGet("{id}")]
        public async Task<ActionResult> ObterPorId(int id)
        {
            var agendamento = await _IAgendamentoRepository.ObterPorId(id);
            if (agendamento == null)
            {
                return NotFound(new { message = "Agendamento não encontrado." });
            }
            return Ok(agendamento);
        }
        
        /// Adiciona um novo agendamento.
        /// <param name="agendamento">Objeto com os dados do agendamento.</param>
        /// <returns>Agendamento cadastrado com sucesso.</returns>
        /// <response code="200">Agendamento cadastrado com sucesso.</response>
        /// <response code="400">Dados inválidos.</response>
        [HttpPost("adicionar")]
        public async Task<ActionResult> Adicionar([FromBody] Agendamento agendamento)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new { message = "Dados inválidos." });
            }

            agendamento.id_agendamento = ++_id;
            await _IAgendamentoRepository.Adicionar(agendamento);

            return Ok(new { message = "Agendamento cadastrado!", data = agendamento });
        }
        
        /// Atualiza um agendamento existente.
        /// <param name="id">ID do agendamento.</param>
        /// <param name="agendamento">Objeto com os dados atualizados.</param>
        /// <returns>Agendamento atualizado com sucesso.</returns>
        /// <response code="200">Agendamento atualizado com sucesso.</response>
        /// <response code="400">ID ou dados inválidos.</response>
        /// <response code="409">Erro de concorrência ao atualizar.</response>
        [HttpPut("atualizar/{id}")]
        public async Task<ActionResult> Atualizar(int id, [FromBody] Agendamento agendamento)
        {
            if (id != agendamento.id_agendamento)
            {
                return BadRequest(new { message = "O ID informado não corresponde ao do agendamento." });
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(new { message = "Dados inválidos." });
            }

            try
            {
                await _IAgendamentoRepository.Atualizar(agendamento);
            }
            catch (DbUpdateConcurrencyException)
            {
                return Conflict(new { message = "Erro de concorrência ao atualizar o agendamento." });
            }

            return Ok(new { message = "Agendamento atualizado!", data = agendamento });
        }
        
        /// Exclui um agendamento do sistema com base no ID.
        /// <param name="id">ID do agendamento.</param>
        /// <returns>Mensagem de sucesso.</returns>
        /// <response code="200">Agendamento excluído com sucesso.</response>
        /// <response code="404">Agendamento não encontrado.</response>
        [HttpDelete("excluir/{id}")]
        public async Task<ActionResult> Excluir(int id)
        {
            var agendamento = await _IAgendamentoRepository.ObterPorId(id);
            if (agendamento == null)
            {
                return NotFound(new { message = "Agendamento não encontrado." });
            }

            await _IAgendamentoRepository.Excluir(agendamento);

            return Ok(new { message = "Agendamento excluído com sucesso!" });
        }
    }

}


