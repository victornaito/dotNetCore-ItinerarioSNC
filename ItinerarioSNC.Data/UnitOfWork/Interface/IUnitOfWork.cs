using ItinerarioSNC.Domain.Entities;
using ItinerarioSNC.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ItinerarioSNC.Data.UnitOfWork.Interface
{
    public interface IUnitOfWork
    {
        void Roolback();   
        void CommitAsync();   
    }
}