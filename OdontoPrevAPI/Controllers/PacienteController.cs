using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;
using OdontoPrevAPI.Model;
using OdontoPrevAPI.Repository.Interface;


namespace OdontoPrevAPI.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class PacienteController : ControllerBase
    {
        private readonly IPacienteRepository _IPacienteRepository;
        private static int _id = 0;

        public PacienteController(IPacienteRepository IPacienteRepository)
        {
            _IPacienteRepository = IPacienteRepository;
        }
        
        /// Retorna todos os pacientes cadastrados.
        /// <returns>Lista de pacientes.</returns>
        /// <response code="200">Retorna a lista de pacientes</response>
        [HttpGet]
        public async Task<ActionResult> Index()
        {
            return Ok(await _IPacienteRepository.Listar());
        }
        
        /// Retorna os dados de um paciente específico pelo ID.
        /// <param name="id">ID do paciente</param>
        /// <returns>Dados do paciente</returns>
        /// <response code="200">Paciente encontrado</response>
        /// <response code="404">Paciente não encontrado</response>
        [HttpGet("{id}")]
        public async Task<ActionResult> ObterPorId(int id)
        {
            var paciente = await _IPacienteRepository.ObterPorId(id);
            if (paciente == null)
            {
                return NotFound(new { message = "Paciente não encontrado." });
            }
            return Ok(paciente);
        }
        
        /// Atualiza os dados de um paciente existente.
        /// <param name="id">ID do paciente</param>
        /// <param name="paciente">Dados atualizados do paciente</param>
        /// <returns>Paciente atualizado</returns>
        /// <response code="200">Paciente atualizado com sucesso</response>
        /// <response code="400">ID inválido ou dados incorretos</response>
        /// <response code="409">Erro de concorrência</response>
        [HttpPut("atualizar/{id}")]
        public async Task<ActionResult> Atualizar(int id, [FromBody] Paciente paciente)
        {
            if (id != paciente.id_paciente)
            {
                return BadRequest(new { message = "O ID informado não corresponde ao do Paciente." });
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(new { message = "Dados inválidos." });
            }

            try
            {
                await _IPacienteRepository.Atualizar(paciente);
            }
            catch (DbUpdateConcurrencyException)
            {
                return Conflict(new { message = "Erro de concorrência, ao atualizar o Paciente." });
            }

            return Ok(new { message = "Paciente atualizado!", data = paciente });
        }
        
        /// Exclui um paciente pelo ID.
        /// <param name="id">ID do paciente</param>
        /// <returns>Status da exclusão</returns>
        /// <response code="200">Paciente excluído com sucesso</response>
        /// <response code="404">Paciente não encontrado</response>
        [HttpDelete("excluir/{id}")]
        public async Task<ActionResult> Excluir(int id)
        {
            var paciente = await _IPacienteRepository.ObterPorId(id);
            if (paciente == null)
            {
                return NotFound(new { message = "Paciente não encontrado." });
            }

            await _IPacienteRepository.Excluir(paciente);
            return Ok(new { message = "Paciente excluído com sucesso!" });
        }
        
        /// Cadastra um novo paciente.
        /// <param name="paciente">Objeto paciente a ser cadastrado</param>
        /// <returns>Paciente cadastrado</returns>
        /// <response code="200">Paciente cadastrado com sucesso</response>
        /// <response code="400">Dados inválidos</response>

        [HttpPost("adicionar")]
        public async Task<ActionResult> Adicionar([FromBody] Paciente paciente)
        {
            // Verifica se os dados enviados são válidos
            if (!ModelState.IsValid)
            {
                return BadRequest(new { message = "Dados inválidos." });
            }
            
            await _IPacienteRepository.Adicionar(paciente);

            // Retorna que o paciente foi cadastrado com sucesso
            return Ok(new { message = "Paciente cadastrado!", data = paciente });
        }
    }

}
