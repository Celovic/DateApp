using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Tinder.Data.Entities;

namespace Tinder.Repository.Abstract
{
    public interface IGenericRepository/*<User>*/<TEntity> where TEntity : class, IEntity, new() /*Buraya ancak veri tabanı nesnesi yazılır - IEntity'i TEntity'e yazamayız - Abstract ve Interface'ler dışındaki Classlar yazılabilir */
    {
        Task Add(TEntity entity);
        //void AddRange(IEnumerable<TEntity> entity);
        // IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);
        Task Update(TEntity entity);
        //TEntity Get(Expression<Func<TEntity, bool>> filter = null);
        // void AddRange(IEnumerable<TEntity> entity);
        Task<TEntity> GetById(string id1);
        Task<TEntity> GetByMatchesId(int id);
        Task<List<TEntity>> GetAll();
        ValueTask<List<TEntity>> GetAll(Expression<Func<TEntity, bool>> filter);
        Task Remove(TEntity entity);
        Task<IEnumerable<TEntity>> Include(string table);

        //void Remove(TEntity entity;
        //void RemoveRange(IEnumerable<TEntity> entity);


        /*TEntity Get(int id);
        IEnumerable<TEntity> GetAll();
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);
        void Add(TEntity entity);*/
    }
}
