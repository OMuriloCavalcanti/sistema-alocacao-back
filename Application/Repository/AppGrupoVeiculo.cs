using Application.Interfaces;
using Domain.Interfaces;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Repository
{
    public class AppGrupoVeiculo : InterfaceGrupoVeiculoApp
    {
        private readonly IGrupoVeiculo _GrupoVeiculo;
        public AppGrupoVeiculo(IGrupoVeiculo IGrupoVeiculo)
        {
            _GrupoVeiculo = IGrupoVeiculo;
        }
        public async Task AddAsync(GrupoVeiculos entity)
        {
            await _GrupoVeiculo.AddAsync(entity);
        }

        public async Task DeleteAsync(GrupoVeiculos entity)
        {
            await _GrupoVeiculo.DeleteAsync(entity);
        }

        public async Task<IEnumerable<GrupoVeiculos>> GetAllAsync()
        {
            return await _GrupoVeiculo.GetAllAsync();
        }

        public async Task<GrupoVeiculos> GetByIdAsync(int id)
        {
            return await _GrupoVeiculo.GetByIdAsync(id);
        }

        public async Task UpdateAsync(GrupoVeiculos entity)
        {
            await _GrupoVeiculo.UpdateAsync(entity);
        }
    }
}
