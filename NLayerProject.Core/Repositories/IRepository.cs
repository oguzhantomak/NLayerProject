﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NLayerProject.Core.Repositories
{
    // TEntity bir entity/model olacak ve bu model/entity bir class olmak zorunda!
    internal interface IRepository<TEntity> where TEntity : class
    {
        Task<TEntity> GetByIdAsync(int id);

        Task<IEnumerable<TEntity>> GetAllAsync();

        //TEntity alan, geriye bool dönen metot
        //IEnumerable tüm verileri alıp memory de tutarak, sorgulama işlemlerini memory üzerinden yaparken IQueryable ise şartlara bağlı query oluşturarak doğrudan veritabanı üzerinden sorgulama işlemi yapar.
        //IEnumerable hafızadaki koleksiyonlar için idealdir. IQueryable hafıza dışındaki (veritabanı, servis vs.) koleksiyonlar için idealdir.
        Task<IEnumerable<TEntity>> Find(Expression<Func<TEntity, bool>> predicate);

        // category.SingleOrDefaultAsync(x=>x.Name == "Bebek Bezi")
        // Name'i Bebek Bezi olan ilk kaydı/ilk bulduğunu getirecek. 
        Task<TEntity> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate);

        Task AddAsync(TEntity entity);

        Task AddRangeAsync(IEnumerable<TEntity> entities);

        void Remove(TEntity entity);

        void RemoveRange(IEnumerable<TEntity> entities);

        TEntity Update (TEntity entity);
    }
}