using ItinerarioSNC.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ItinerarioSNC.Domain.Interfaces
{
    public interface IRepository<T> where T: BaseEntity {
        void Insert(T obj);
        void Remove(int id);
        Task<T> GetAsync(int id);
        IList<T> GetAll();
        Task UpdateAsync(T obj);
    }
}
