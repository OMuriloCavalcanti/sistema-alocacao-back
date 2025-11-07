using Application.Interfaces;
using Domain.Interfaces;
using Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpresaAssistenciaController : ControllerBase
    {
        private readonly InterfaceEmpresasAssistenciaApp _interfaceEmpresasAssistenciaApp;
        public EmpresaAssistenciaController(InterfaceEmpresasAssistenciaApp InterfaceEmpresasAssistenciaApp)
        {
            _interfaceEmpresasAssistenciaApp = InterfaceEmpresasAssistenciaApp;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmpresaAssistencia>>> GetAll()
        {
            try
            {
                var empresaAssistencia = await _interfaceEmpresasAssistenciaApp.GetAllAsync();
                return Ok(empresaAssistencia);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno ao obter empresas de assistência: {ex.Message}");
            }
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<EmpresaAssistencia>> GetById(int id)
        {
            try
            {
                if (id <= 0)
                    return BadRequest("O ID informado é inválido.");

                var empresaAssistencia = await _interfaceEmpresasAssistenciaApp.GetByIdAsync(id);
                if (empresaAssistencia == null)
                    return NotFound("Empresa de assistênica não encontrada.");

                return Ok(empresaAssistencia);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro ao buscar empresa de assistênica: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<EmpresaAssistencia>> Delete(int id)
        {
            try
            {
                if (id <= 0)
                    return BadRequest("O ID informado é inválido.");

                var empresaAssistencia = await _interfaceEmpresasAssistenciaApp.GetByIdAsync(id);
                if (empresaAssistencia == null)
                    return NotFound("Empresa de assistência não encontrado.");

                await _interfaceEmpresasAssistenciaApp.DeleteAsync(empresaAssistencia);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro ao excluir empresa de assistência: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<ActionResult<EmpresaAssistencia>> Create(EmpresaAssistencia empresaAssistencia)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                await _interfaceEmpresasAssistenciaApp.AddAsync(empresaAssistencia);
                return CreatedAtAction(nameof(GetById), new { id = empresaAssistencia.Id }, empresaAssistencia);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro ao criar empresa de assistência: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<EmpresaAssistencia>> Update(int id, EmpresaAssistencia empresaAssistencia)
        {
            try
            {
                if (id <= 0)
                    return BadRequest("O ID informado é inválido.");

                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var existingempresaAssistencia = await _interfaceEmpresasAssistenciaApp.GetByIdAsync(id);
                if (existingempresaAssistencia == null)
                    return NotFound("Veículo não encontrado.");

                existingempresaAssistencia.Nome = empresaAssistencia.Nome;
                existingempresaAssistencia.Endereco = empresaAssistencia.Endereco;

                await _interfaceEmpresasAssistenciaApp.UpdateAsync(existingempresaAssistencia);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro ao atualizar veículo: {ex.Message}");
            }
        }
    }
}
