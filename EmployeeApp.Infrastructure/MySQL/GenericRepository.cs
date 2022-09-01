﻿using EmployeeApp.Domain.Interfaces;
using EmployeeApp.Domain.Models;
using Mapster;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace EmployeeApp.Infrastructure.MySQL;


internal class GenericRepository<T> : IAsyncRepository<T>
    where T : class, IEntity<long>
{
    public GenericRepository(EmployeeContext EmployeeContext)
    {
        _EmployeeContext = EmployeeContext;
    }

    private readonly EmployeeContext _EmployeeContext;

    ~GenericRepository()
    {
        Dispose(false);
    }

    public async Task<T> AddAsync(T entity)
    {
        await _EmployeeContext.AddAsync(entity);
        return entity;
    }

    public async Task<T?> GetAsync(long id, params Expression<Func<T,object>>[] includes)
    {
        var query = _EmployeeContext.Set<T>().AsNoTracking();
        if (includes.Any())
        {
            foreach (var include in includes)
            {
                query = query.Include(include);
            }
        }
        return await query.SingleOrDefaultAsync(x => x.EmployeeNumber == id);
    }

    public long GetId(T entity)
    {
        return entity.EmployeeNumber;
    }

    public async Task<IEnumerable<T>> QueryAsync(Func<IQueryable<T>,  IQueryable<T>>? filter = null, params Expression<Func<T, object>>[] includes)
    {
        var query = _EmployeeContext.Set<T>().AsNoTracking();
        if (includes.Any())
        {
            foreach (var include in includes)
            {
                query = query.Include(include);
            }
        }

        if (filter != null)
            return await Task.FromResult(filter(query).ToList());
        else
            return await Task.FromResult(query.AsEnumerable());
    }

    public async Task<bool> RemoveAsync(long id)
    {
        var entity = _EmployeeContext.Find<T>(id);
        if (entity != null)
        {
            _EmployeeContext.Remove(entity);
            return true;
        }
        await Task.Yield();
        return false;
    }

    public async Task SaveChangesAsync(CancellationToken cancellationToken)
    {
        await _EmployeeContext.SaveChangesAsync(cancellationToken);
    }

    public async Task<bool> UpdateAsync(T entity)
    {
        _EmployeeContext.Update(entity);
        return await Task.FromResult(true);
    }

    public virtual void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        //if (disposing)
        //{

        //}
    }
}
