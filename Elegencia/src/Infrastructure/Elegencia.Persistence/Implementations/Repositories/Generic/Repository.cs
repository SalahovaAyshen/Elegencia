using Elegencia.Application.Abstractions.Repositories;
using Elegencia.Application.ViewModels.Manage;
using Elegencia.Domain.Entities;
using Elegencia.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Elegencia.Persistence.Implementations.Repositories
{
    public class Repository<T> : IRepository<T> where T : BaseNameableEntity, new()
    {
        private readonly AppDbContext _context;
        private readonly DbSet<T> _table;
        public Repository(AppDbContext context)
        {
            _context = context;
            _table = _context.Set<T>();
        }
        public IQueryable<T> GetAll(params string[] includes)
        {
            IQueryable<T> query = _table;
            query = _addIncludes(query, includes);
            return query;
        }
        public IQueryable<T> GetAllWithSearch(
            string? search,
            Expression<Func<T, bool>>? expression = null,
            params string[] includes)
        {
            IQueryable<T> query = _table;
            if (!string.IsNullOrEmpty(search))
                query = query.Where(q => q.Name.ToLower().Contains(search.ToLower()));

            if (expression is not null) query = query.Where(expression);
            query = _addIncludes(query, includes);
            return query;
        }
        public IQueryable<T> GetAllWithOrder(Expression<Func<T, bool>>? expression = null, 
            Expression<Func<T, object>>? orderExpression = null,
            params string[] includes)
        {
            IQueryable<T> query = _table;
            if (expression is not null) query = query.Where(expression);
            if (orderExpression is not null)
            {
                query = query.OrderByDescending(orderExpression);
            }
            query = _addIncludes(query, includes);
            return query;

        }
        public async Task<T> GetByIdAsync(int id, params string[] includes)
        {
            IQueryable<T> query = _table.Where(i => i.Id == id);
            if (query is null) throw new Exception("Not found id");
            query = _addIncludes(query, includes);
            return query.FirstOrDefault();
        }
        public async Task<IQueryable<T>> GetAllWithoutSearch(Expression<Func<T, bool>>? expression = null, params string[] includes)
        {
            IQueryable<T> query = _table;
            if (expression is not null) query = query.Where(expression);
            query = _addIncludes(query, includes);
            return query;
        }
        public async Task<PaginationVM<T>> GetAllPagination(Expression<Func<T, bool>>? expression = null, 
            int page = 0, int take = 0, int count = 0, 
            params string[] includes)
        {
            IQueryable<T> query = _table;
            if (expression is not null) query = query.Where(expression);
            count = await _table.CountAsync();
            if (page > 0) query = query.Skip((page - 1) * take);
            else throw new Exception("Page can't be zero or negative number");
            if (take > 0) query = query.Take(take);
            else throw new Exception("Take can't be zero or negative number");
            query = _addIncludes(query, includes);
            PaginationVM<T> paginationVM = new PaginationVM<T>
            {
                TotalPage = Math.Ceiling((double)count / take),
                CurrentPage = page,
                Items = query
            };
            return paginationVM;
        }
        public async Task AddAsync(T item)
        {
            await _table.AddAsync(item);
        }
        public void Update(T item)
        {
            _table.Update(item);
        }
        public void Delete(T item)
        {
            _table.Remove(item);
        }
        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }


        private IQueryable<T> _addIncludes(IQueryable<T> query, params string[] includes)
        {
            if (includes is not null)
            {
                for (int i = 0; i < includes.Length; i++)
                {
                    query = query.Include(includes[i]);
                }
            }
            return query;

        }
        public async Task<int> CountAsync()
        {
            int count  = await _table.CountAsync();
            return count;
        }
    }
}
