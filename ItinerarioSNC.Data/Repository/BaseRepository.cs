using ItinerarioSNC.Domain.Entities;
using ItinerarioSNC.Domain.Interfaces;
using ItinerarioSNC.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ItinerarioSNC.Infra.Data.Repository
{
    public class BaseRepository<T> : IRepository<T> where T : BaseEntity
    {

        private readonly MySqlServerContext sqlServerContext;

        public BaseRepository()
        {
        }

        public BaseRepository(MySqlServerContext sqlServerContext)
        {
            this.sqlServerContext = sqlServerContext;
        }

        public async Task<T> GetAsync(int id)
        {
            return await sqlServerContext.Set<T>().FindAsync(id);
        }

        public IList<T> GetAll()
        {
            return sqlServerContext.Set<T>().ToList();
        }

        public void Insert(T obj)
        {
            this.sqlServerContext.Set<T>().Add(obj);
            this.sqlServerContext.SaveChanges();
        }

        public async void Remove(int id)
        {
            this.sqlServerContext.Set<T>().Remove(await this.GetAsync(id));
            await this.sqlServerContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(T obj)
        {
            this.sqlServerContext.Entry(obj).State = EntityState.Modified;
            await this.sqlServerContext.SaveChangesAsync();
        }
    }
}
