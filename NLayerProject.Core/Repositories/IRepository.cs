using System.Linq.Expressions;

namespace NLayerProject.Core.Repositories
{

    /// <summary>
    /// * Repository sadece veritabanı ile ilgili işlemleri gerçekleştirir.
    /// </summary>
    /// <typeparam name="TEntity">TEntity bir entity/model olacak ve bu model/entity bir class olmak zorunda!</typeparam>
    public interface IRepository<TEntity> where TEntity : class
    {
        Task<TEntity> GetByIdAsync(int id);

        //IQueryable'da veritabanına sorgu atılmaz. Ne zaman ToList çağırırsak o zaman sorgu atılır.
        IQueryable<TEntity> GetAll();

        //TEntity alan, geriye bool dönen metot
        //IEnumerable tüm verileri alıp memory de tutarak, sorgulama işlemlerini memory üzerinden yaparken IQueryable ise şartlara bağlı query oluşturarak doğrudan veritabanı üzerinden sorgulama işlemi yapar.
        //IEnumerable hafızadaki koleksiyonlar için idealdir. IQueryable hafıza dışındaki (veritabanı, servis vs.) koleksiyonlar için idealdir.
        IQueryable<TEntity> Where(Expression<Func<TEntity, bool>> predicate);

        // category.SingleOrDefaultAsync(x=>x.Name == "Bebek Bezi")
        // Name'i Bebek Bezi olan ilk kaydı/ilk bulduğunu getirecek. 
        Task<TEntity> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate);

        Task AddAsync(TEntity entity);

        Task AddRangeAsync(IEnumerable<TEntity> entities);

        void Remove(TEntity entity);

        void RemoveRange(IEnumerable<TEntity> entities);

        void Update(TEntity entity);
    }
}
