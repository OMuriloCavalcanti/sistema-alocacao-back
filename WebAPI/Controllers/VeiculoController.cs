using Application.Interfaces;
using Domain.Interfaces;
using Domain.Models;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VeiculoController : ControllerBase
    {
        
        private readonly InterfaceVeiculoApp _InterfaceVeiculoApp;
        public VeiculoController(InterfaceVeiculoApp InterfaceVeiculoApp)
        {
            _InterfaceVeiculoApp = InterfaceVeiculoApp;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Veiculo>>> GetAll()
        {
            try
            {
                var veiculos = await _InterfaceVeiculoApp.GetAllAsync();
                return Ok(veiculos);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno ao obter veículos: {ex.Message}");
            }
        }
        
        [HttpGet("{id}")]
        public async Task<ActionResult<Veiculo>> GetById(int id)
        {
            try
            {
                if (id <= 0)
                    return BadRequest("O ID informado é inválido.");

                var veiculo = await _InterfaceVeiculoApp.GetByIdAsync(id);
                if (veiculo == null)
                    return NotFound("Veículo não encontrado.");

                return Ok(veiculo);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro ao buscar veículo: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Veiculo>> Delete(int id)
        {
            try
            {
                if (id <= 0)
                    return BadRequest("O ID informado é inválido.");

                var veiculo = await _InterfaceVeiculoApp.GetByIdAsync(id);
                if (veiculo == null)
                    return NotFound("Veículo não encontrado.");

                await _InterfaceVeiculoApp.DeleteAsync(veiculo);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro ao excluir veículo: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<ActionResult<Veiculo>> Create(Veiculo veiculo)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                await _InterfaceVeiculoApp.AddAsync(veiculo);
                return CreatedAtAction(nameof(GetById), new { id = veiculo.Id }, veiculo);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro ao criar veículo: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Veiculo>> Update(int id, Veiculo veiculo)
        {
            try
            {
                if (id <= 0)
                    return BadRequest("O ID informado é inválido.");

                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var existingVeiculo = await _InterfaceVeiculoApp.GetByIdAsync(id);
                if (existingVeiculo == null)
                    return NotFound("Veículo não encontrado.");

                existingVeiculo.Modelo = veiculo.Modelo;
                existingVeiculo.Placa = veiculo.Placa;
                existingVeiculo.GrupoId = veiculo.GrupoId;

                await _InterfaceVeiculoApp.UpdateAsync(existingVeiculo);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro ao atualizar veículo: {ex.Message}");
            }
        }
    }
}
