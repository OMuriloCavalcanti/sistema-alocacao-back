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
    public class AppEmpresasAssistencia : InterfaceEmpresasAssistenciaApp
    {
        private readonly IEmpresaAssistencia _IEmpresaAssistencia;
        public AppEmpresasAssistencia(IEmpresaAssistencia IEmpresaAssistencia)
        {
            _IEmpresaAssistencia = IEmpresaAssistencia;
        }

        public async Task AddAsync(EmpresaAssistencia entity)
        {
            await _IEmpresaAssistencia.AddAsync(entity);
        }

        public async Task DeleteAsync(EmpresaAssistencia entity)
        {
            await _IEmpresaAssistencia.DeleteAsync(entity);
        }

        public async Task<IEnumerable<EmpresaAssistencia>> GetAllAsync()
        {
            return await _IEmpresaAssistencia.GetAllAsync();
        }

        public async Task<EmpresaAssistencia> GetByIdAsync(int id)
        {
            return await _IEmpresaAssistencia.GetByIdAsync(id);
        }

        public async Task UpdateAsync(EmpresaAssistencia entity)
        {
            await _IEmpresaAssistencia.UpdateAsync(entity);
        }
    }
}
