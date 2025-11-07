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
    public class AppVeiculo : InterfaceVeiculoApp
    {
        private readonly IVeiculo _IVeiculo;
        public AppVeiculo(IVeiculo IVeiculo)
        {
            _IVeiculo = IVeiculo;   
        }

        public async Task AddAsync(Veiculo entity)
        {
            await _IVeiculo.AddAsync(entity);
        }

        public async Task DeleteAsync(Veiculo entity)
        {
            await _IVeiculo.DeleteAsync(entity);
        }

        public async Task<IEnumerable<Veiculo>> GetAllAsync()
        {
            return await _IVeiculo.GetAllAsync();
        }

        public async Task<Veiculo> GetByIdAsync(int id)
        {
            return await _IVeiculo.GetByIdAsync(id);
        }

        public async Task UpdateAsync(Veiculo entity)
        {
            await _IVeiculo.UpdateAsync(entity);
        }
    }
}
