using Domain.Interfaces.InterfacesServices;
using Domain.Models;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class VeiculoAssistenciaService : IVeiculoAssistenciaService
    {
        private readonly AppDbContext _OptionsBuilder;
        public VeiculoAssistenciaService(AppDbContext AppDbContext)
        {
            _OptionsBuilder = AppDbContext;
        }
        public async Task AddVeiculosAssistencia(int veiculoId, int planoId)
        {
            var existing = await _OptionsBuilder.VeiculosAssistencia
               .AnyAsync(x => x.VeiculoId == veiculoId && x.PlanoId == planoId);

            if (!existing)
            {
                await _OptionsBuilder.VeiculosAssistencia.AddAsync(new VeiculoAssistencia
                {
                    VeiculoId = veiculoId,
                    PlanoId = planoId
                });

                await _OptionsBuilder.SaveChangesAsync();
            }
        }

        public async Task<List<VeiculosPlanosDTO>> ListarVeiculosComPlanosAsync()
        {

            var query = from va in _OptionsBuilder.VeiculosAssistencia
                        join v in _OptionsBuilder.Veiculos on va.VeiculoId equals v.Id
                        join p in _OptionsBuilder.PlanosAssistencia on va.PlanoId equals p.Id
                        select new VeiculosPlanosDTO
                        {
                            VeiculoAssistenciaId = va.Id,
                            VeiculoId = v.Id,
                            ModeloVeiculo = v.Modelo,
                            PlanoId = p.Id,
                            PlanoDesc = p.Descricao
                        };

            return await query.AsNoTracking().ToListAsync();
        }

        public async Task<VeiculosPlanosDTO> GetById(int id)
        {
            var query = from va in _OptionsBuilder.VeiculosAssistencia
                        join v in _OptionsBuilder.Veiculos on va.VeiculoId equals v.Id
                        join p in _OptionsBuilder.PlanosAssistencia on va.PlanoId equals p.Id
                        where va.Id == id
                        select new VeiculosPlanosDTO
                        {
                            VeiculoAssistenciaId = va.Id,
                            VeiculoId = v.Id,
                            ModeloVeiculo = v.Modelo,
                            PlanoId = p.Id,
                            PlanoDesc = p.Descricao
                        };

            return await query.AsNoTracking().FirstOrDefaultAsync();
        }
    }
}
