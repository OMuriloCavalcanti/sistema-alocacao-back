using Application.Interfaces;
using Domain.Interfaces;
using Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlanoAssistenciaController : ControllerBase
    {
        private readonly InterfacePlanoAssistenciaApp _interfacePlanoAssistenciaApp;
        public PlanoAssistenciaController(InterfacePlanoAssistenciaApp InterfacePlanoAssistenciaApp)
        {
            _interfacePlanoAssistenciaApp = InterfacePlanoAssistenciaApp;   
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PlanoAssistencia>>> GetAll()
        {
            try
            {
                var planoAssistencia = await _interfacePlanoAssistenciaApp.GetAllAsync();
                return Ok(planoAssistencia);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno ao obter planos: {ex.Message}");
            }
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<PlanoAssistencia>> GetById(int id)
        {

            try
            {
                if (id <= 0)
                    return BadRequest("O ID informado é inválido.");

                var planoAssistencia = await _interfacePlanoAssistenciaApp.GetByIdAsync(id);
                if (planoAssistencia == null)
                    return NotFound("Plano não encontrado.");

                return Ok(planoAssistencia);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro ao buscar plano: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<PlanoAssistencia>> Delete(int id)
        {
            try
            {
                if (id <= 0)
                    return BadRequest("O ID informado é inválido.");

                var planoAssistencia = await _interfacePlanoAssistenciaApp.GetByIdAsync(id);
                if (planoAssistencia == null)
                    return NotFound("Plano não encontrado.");

                await _interfacePlanoAssistenciaApp.DeleteAsync(planoAssistencia);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro ao excluir plano: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<ActionResult<PlanoAssistencia>> Create(PlanoAssistencia planoAssistencia)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                await _interfacePlanoAssistenciaApp.AddAsync(planoAssistencia);
                return CreatedAtAction(nameof(GetById), new { id = planoAssistencia.Id }, planoAssistencia);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro ao criar plano: {ex.Message}");
            }
        }


        [HttpPut("{id}")]
        public async Task<ActionResult<PlanoAssistencia>> Update(int id, PlanoAssistencia planoAssistencia)
        {
            try
            {
                if (id <= 0)
                    return BadRequest("O ID informado é inválido.");

                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var existingPlanoAssistenciaa = await _interfacePlanoAssistenciaApp.GetByIdAsync(id);
                if (existingPlanoAssistenciaa == null)
                    return NotFound("Veículo não encontrado.");

                existingPlanoAssistenciaa.Cobertura = planoAssistencia.Cobertura;
                existingPlanoAssistenciaa.Descricao = planoAssistencia.Descricao;

                await _interfacePlanoAssistenciaApp.UpdateAsync(existingPlanoAssistenciaa);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro ao atualizar veículo: {ex.Message}");
            }
        }

    }
}
