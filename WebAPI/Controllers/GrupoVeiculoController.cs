using Application.Interfaces;
using Domain.Interfaces;
using Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GrupoVeiculoController : ControllerBase
    {
        private readonly InterfaceGrupoVeiculoApp _interfaceGrupoVeiculoApp;
        public GrupoVeiculoController(InterfaceGrupoVeiculoApp InterfaceGrupoVeiculoApp)
        {
            _interfaceGrupoVeiculoApp = InterfaceGrupoVeiculoApp;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<GrupoVeiculos>>> GetAll()
        {
            try
            {
                var grupoVeiculo = await _interfaceGrupoVeiculoApp.GetAllAsync();
                return Ok(grupoVeiculo);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno ao obter grupo de veículos: {ex.Message}");
            }
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<GrupoVeiculos>> GetById(int id)
        {
            try
            {
                if (id <= 0)
                    return BadRequest("O ID informado é inválido.");

                var grupoVeiculo = await _interfaceGrupoVeiculoApp.GetByIdAsync(id);
                if (grupoVeiculo == null)
                    return NotFound("Veículo não encontrado.");

                return Ok(grupoVeiculo);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro ao buscar veículo: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<GrupoVeiculos>> Delete(int id)
        {

            try
            {
                if (id <= 0)
                    return BadRequest("O ID informado é inválido.");

                var grupoVeiculo = await _interfaceGrupoVeiculoApp.GetByIdAsync(id);
                if (grupoVeiculo == null)
                    return NotFound("Veículo não encontrado.");

                await _interfaceGrupoVeiculoApp.DeleteAsync(grupoVeiculo);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro ao excluir veículo: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<ActionResult<GrupoVeiculos>> Create(GrupoVeiculos grupoVeiculo)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                await _interfaceGrupoVeiculoApp.AddAsync(grupoVeiculo);
                return CreatedAtAction(nameof(GetById), new { id = grupoVeiculo.Id }, grupoVeiculo);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro ao criar veículo: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<GrupoVeiculos>> Update(int id, GrupoVeiculos grupoVeiculo)
        {
            try
            {
                if (id <= 0)
                    return BadRequest("O ID informado é inválido.");

                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var existingGrupoVeiculo = await _interfaceGrupoVeiculoApp.GetByIdAsync(id);
                if (existingGrupoVeiculo == null)
                    return NotFound("Veículo não encontrado.");

                existingGrupoVeiculo.Nome = grupoVeiculo.Nome;
                existingGrupoVeiculo.Descricao = grupoVeiculo.Descricao;

                await _interfaceGrupoVeiculoApp.UpdateAsync(existingGrupoVeiculo);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro ao atualizar veículo: {ex.Message}");
            }
        }
    }
}
