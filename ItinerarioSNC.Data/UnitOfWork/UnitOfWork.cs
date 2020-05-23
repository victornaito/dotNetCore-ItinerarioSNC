using System.Threading.Tasks;
using ItinerarioSNC.Data.UnitOfWork.Interface;
using Microsoft.EntityFrameworkCore;

namespace ItinerarioSNC.Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DbContext context;

        public UnitOfWork(DbContext context)
        {
            this.context = context;
        }

        public async Task CommitAsync()
        {
            await context.SaveChangesAsync();
        }

        public void Roolback()
        {
            context.Dispose();
        }
    }
}