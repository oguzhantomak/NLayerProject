using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NLayerProject.Core.Services
{
    /// <summary>
    /// IService metodumuz repositoryler ile iletişimde olacak. Bugün mssql kullanırken ileride farklı bir database ile çalıştığımız takdirde sadece repositoryler değişecek. Servis baki kalacak.
    /// </summary>
    /// <typeparam name="TEntity">Entity tipinde bir class almalı/alabilir.</typeparam>
    public interface IService<TEntity> where TEntity : class
    {
        Task<TEntity> GetByIdAsync(int id);

        Task<IEnumerable<TEntity>> GetAllAsync();

        //TEntity alan, geriye bool dönen metot
        //IEnumerable tüm verileri alıp memory de tutarak, sorgulama işlemlerini memory üzerinden yaparken IQueryable ise şartlara bağlı query oluşturarak doğrudan veritabanı üzerinden sorgulama işlemi yapar.
        //IEnumerable hafızadaki koleksiyonlar için idealdir. IQueryable hafıza dışındaki (veritabanı, servis vs.) koleksiyonlar için idealdir.
        IQueryable<TEntity> Where(Expression<Func<TEntity, bool>> predicate);

        // category.SingleOrDefaultAsync(x=>x.Name == "Bebek Bezi")
        // Name'i Bebek Bezi olan ilk kaydı/ilk bulduğunu getirecek. 
        Task<TEntity> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate);

        Task<TEntity> AddAsync(TEntity entity);

        Task<IEnumerable<TEntity>> AddRangeAsync(IEnumerable<TEntity> entities);

        Task RemoveAsync(TEntity entity);

        Task RemoveRangeAsync(IEnumerable<TEntity> entities);

        Task UpdateAsync(TEntity entity);
    }
}
