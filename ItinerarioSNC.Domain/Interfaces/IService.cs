using FluentValidation;
using ItinerarioSNC.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ItinerarioSNC.Domain.Interfaces
{
    public interface IService<T> where T : BaseEntity {
        T Post<V>(T obj) where V : AbstractValidator<T>;
        T Put<V>(T obj) where V : AbstractValidator<T>;
        void Delete(int id);
        void Get(int id);
        IList<T> GetAll();
    }
}
