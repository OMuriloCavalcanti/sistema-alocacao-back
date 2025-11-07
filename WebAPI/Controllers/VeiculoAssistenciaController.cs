using Application.Interfaces;
using Domain.Interfaces.InterfacesServices;
using Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VeiculoAssistenciaController : ControllerBase
    {
        private readonly InterfaceVeiculoAssistenciaApp _interfaceVeiculoAssistenciaApp;
        private readonly IVeiculoAssistenciaService _veiculoAssistenciaService;

        public VeiculoAssistenciaController(IVeiculoAssistenciaService veiculoAssistenciaService, InterfaceVeiculoAssistenciaApp InterfaceVeiculoAssistenciaApp)
        {
            _veiculoAssistenciaService = veiculoAssistenciaService;
            _interfaceVeiculoAssistenciaApp = InterfaceVeiculoAssistenciaApp;
        }

        [HttpPost]
        public async Task<IActionResult> AddVeiculoAssistencia([FromBody] VeiculosPlanosDTO dto)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                await _veiculoAssistenciaService.AddVeiculosAssistencia(dto.VeiculoId, dto.PlanoId);
                return Ok("Associação veículo-plano criada com sucesso!");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro ao adicionar veículo à assistência: {ex.Message}");
            }
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<VeiculosPlanosDTO>>> ListarVeiculosComPlanos()
        {
            try
            {
                var lista = await _veiculoAssistenciaService.ListarVeiculosComPlanosAsync();

                if (lista == null || !lista.Any())
                    return NotFound("Nenhuma associação de veículo e plano encontrada.");

                return Ok(lista);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro ao listar associações: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<VeiculosPlanosDTO>> Update(int id, VeiculosPlanosDTO veiculosPlanosDTO)
        {
            try
            {
                if (id <= 0)
                    return BadRequest("O ID informado é inválido.");

                var veiculoAssistencia = await _interfaceVeiculoAssistenciaApp.GetByIdAsync(id);
                if (veiculoAssistencia == null)
                    return NotFound("Associação não encontrada.");

                veiculoAssistencia.VeiculoId = veiculosPlanosDTO.VeiculoId;
                veiculoAssistencia.PlanoId = veiculosPlanosDTO.PlanoId;

                await _interfaceVeiculoAssistenciaApp.UpdateAsync(veiculoAssistencia);
                return Ok(veiculoAssistencia);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro ao buscar associação: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<VeiculoAssistencia>> GetById(int id)
        {
            try
            {
                if (id <= 0)
                    return BadRequest("O ID informado é inválido.");

                var veiculoAssistencia = await _veiculoAssistenciaService.GetById(id);
                if (veiculoAssistencia == null)
                    return NotFound("Associação não encontrada.");

                return Ok(veiculoAssistencia);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro ao buscar associação: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<VeiculoAssistencia>> Delete(int id)
        {
            try
            {
                if (id <= 0)
                    return BadRequest("O ID informado é inválido.");

                var veiculoAssistencia = await _interfaceVeiculoAssistenciaApp.GetByIdAsync(id);
                if (veiculoAssistencia == null)
                    return NotFound("Associação não encontrada.");

                await _interfaceVeiculoAssistenciaApp.DeleteAsync(veiculoAssistencia);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro ao excluir associação: {ex.Message}");
            }
        }
    }
}
