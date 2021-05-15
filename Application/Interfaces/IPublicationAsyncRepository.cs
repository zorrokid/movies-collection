using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Domain.Entities;

namespace Application.Interfaces
{
    public interface IPublicationAsyncRepository
    {
        Task<IReadOnlyList<Publication>> GetAllAsync(Expression<Func<Publication, bool>> expression);
    }
}