using FluentValidation;
using ItinerarioSNC.Domain.Entities;
using ItinerarioSNC.Domain.Interfaces;
using ItinerarioSNC.Infra.Data.Repository;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ItinerarioSNC.Service.Services
{
    public class BaseService<T> : IService<T> where T : BaseEntity
    {
        private readonly BaseRepository<T> repository;

        public BaseService(BaseRepository<T> repository)
        {
            this.repository = repository;
        }

        public T Post<V>(T obj) where V : AbstractValidator<T>
        {
            Validate(obj, Activator.CreateInstance<V>());

            repository.Insert(obj);
            return obj;
        }

        public async Task<T> Put<V>(T obj) where V : AbstractValidator<T>
        {
            Validate(obj, Activator.CreateInstance<V>());

            await repository.UpdateAsync(obj);
            return obj;
        }

        public void Delete(int id)
        {
            if (id == 0)
                throw new ArgumentException("The id can't be zero.");

            repository.Remove(id);
        }

        public IList<T> GetAll() => repository.GetAll();

        public async Task<T> Get(int id)
        {
            if (id == 0)
                throw new ArgumentException("The id can't be zero.");

            return await repository.GetAsync(id);
        }

        private void Validate(T obj, AbstractValidator<T> validator)
        {
            if (obj == null)
                throw new Exception("Registros não detectados!");

            validator.ValidateAndThrow(obj);
        }
    }
}
