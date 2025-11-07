using Domain.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Win32.SafeHandles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public class RepositoryGeneric<T> : IGeneric<T>, IDisposable where T : class
    {
        private readonly AppDbContext _OptionsBuilder;
        public RepositoryGeneric(AppDbContext OptionsBuilder) 
        {
            _OptionsBuilder = OptionsBuilder;  
        }
        public async Task AddAsync(T entity)
        {
            await _OptionsBuilder.Set<T>().AddAsync(entity);
            await _OptionsBuilder.SaveChangesAsync();
        }

        public async Task DeleteAsync(T entity)
        {
            _OptionsBuilder.Set<T>().Remove(entity);
            await _OptionsBuilder.SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _OptionsBuilder.Set<T>().ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _OptionsBuilder.Set<T>().FindAsync(id);
        }

        public async Task UpdateAsync(T entity)
        {
            _OptionsBuilder.Set<T>().Update(entity);
            await _OptionsBuilder.SaveChangesAsync();
        }

        #region Disposed https://docs.microsoft.com/pt-br/dotnet/standard/garbage-collection/implementing-dispose
        // Flag: Has Dispose already been called?
        bool disposed = false;
        // Instantiate a SafeHandle instance.
        SafeHandle handle = new SafeFileHandle(IntPtr.Zero, true);



        // Public implementation of Dispose pattern callable by consumers.
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }


        // Protected implementation of Dispose pattern.
        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
                return;

            if (disposing)
            {
                handle.Dispose();
                // Free any other managed objects here.
                //
            }

            disposed = true;
        }
        #endregion
    }
}
