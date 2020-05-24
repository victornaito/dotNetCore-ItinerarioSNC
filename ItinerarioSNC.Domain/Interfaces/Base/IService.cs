using FluentValidation;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ItinerarioSNC.Domain.Interfaces
{
    public interface IService<T> where T : class {
        T Post<V>(T obj) where V : AbstractValidator<T>;
        Task<T> Put<V>(T obj) where V : AbstractValidator<T>;
        void Delete(int id);
        Task<T> Get(int id);
        IList<T> GetAll();
    }
}