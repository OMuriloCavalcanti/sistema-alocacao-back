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
    public class AppPlanoAssistencia : InterfacePlanoAssistenciaApp
    {
        private readonly IPlanoAssistencia _IPlanoAssistencia;
        public AppPlanoAssistencia(IPlanoAssistencia IPlanoAssistencia)
        {
            _IPlanoAssistencia = IPlanoAssistencia;
        }
        public async Task AddAsync(PlanoAssistencia entity)
        {
            await _IPlanoAssistencia.AddAsync(entity);
        }

        public async Task DeleteAsync(PlanoAssistencia entity)
        {
            await _IPlanoAssistencia.DeleteAsync(entity);
        }

        public async Task<IEnumerable<PlanoAssistencia>> GetAllAsync()
        {
            return await _IPlanoAssistencia.GetAllAsync();
        }

        public async Task<PlanoAssistencia> GetByIdAsync(int id)
        {
            return await _IPlanoAssistencia.GetByIdAsync(id);
        }

        public async Task UpdateAsync(PlanoAssistencia entity)
        {
            await _IPlanoAssistencia.UpdateAsync(entity);
        }
    }
}
