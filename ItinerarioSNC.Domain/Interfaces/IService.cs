using FluentValidation;
using ItinerarioSNC.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ItinerarioSNC.Domain.Interfaces
{
    public interface IService<T> where T : BaseEntity {
        T Post<V>(T obj) where V : AbstractValidator<T>;
        Task<T> Put<V>(T obj) where V : AbstractValidator<T>;
        void Delete(int id);
        Task<T> Get(int id);
        IList<T> GetAll();
    }
}