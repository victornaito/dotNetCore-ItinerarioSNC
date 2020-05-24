using ItinerarioSNC.Data.UnitOfWork.Interface;
using ItinerarioSNC.Infra.Data.Context;
using System.Threading.Tasks;

namespace ItinerarioSNC.Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MySqlServerContext context;

        public UnitOfWork(MySqlServerContext context)
        {
            this.context = context;
        }

        public async Task CommitAsync()
        {
            await context.SaveChangesAsync();
        }

        public void Rollback()
        {
            context.Dispose();
        }
    }
}