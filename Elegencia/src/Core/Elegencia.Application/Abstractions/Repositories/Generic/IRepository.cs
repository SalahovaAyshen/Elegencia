using Elegencia.Application.ViewModels.Manage;
using Elegencia.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Elegencia.Application.Abstractions.Repositories
{
    public interface IRepository<T> where T : BaseNameableEntity, new()
    {
        IQueryable<T> GetAllWithSearch(string? search, Expression<Func<T, bool>>? expression=null, params string[] includes);
        Task<IQueryable<T>> GetAllWithoutSearch( Expression<Func<T, bool>>? expression = null,params string[] includes);
        Task<PaginationVM<T>> GetAllPagination(
            Expression<Func<T, bool>>? expression = null, 
            int page = 0, int take = 0, int count = 0,
            params string[] includes);
        IQueryable<T> GetAllWithOrder(Expression<Func<T, bool>>? expression = null, 
            Expression<Func<T, object>>? orderExpression = null, 
            params string[] includes);
        IQueryable<T> GetAll(params string[] includes);
        Task<T> GetByIdAsync(int id, params string[] includes);
        Task AddAsync(T entity);
        void Update(T entity);
        void Delete(T entity);
        Task SaveChangesAsync();
        Task<int> CountAsync();


    }
}
