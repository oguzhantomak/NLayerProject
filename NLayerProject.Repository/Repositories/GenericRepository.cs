using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NLayerProject.Core.Repositories;

namespace NLayerProject.Repository.Repositories
{
    public class GenericRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        // Miras alacağım yerlerde buna erişebilmek için protected yapıyoruz. İleride generic crud metotlarının yetmediği zaman başka Repositoryler oluşturduğumuzda bu contexte erişebilmek için protected yapıyoruz. Protected olunca, bu contexte sadece miras alınan sınıflardan erişilebilir oluyor.
        protected readonly AppDbContext _appDbContext;

        // Entitymize karşılık geliyor.
        private readonly DbSet<TEntity> _dbSet;

        public GenericRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
            _dbSet = _appDbContext.Set<TEntity>();
        }

        public async Task AddAsync(TEntity entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public async Task AddRangeAsync(IEnumerable<TEntity> entities)
        {
            await _dbSet.AddRangeAsync(entities);
        }


        public async Task<TEntity> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public IQueryable<TEntity> GetAll()
        {
            // AsNoTracking: EfCore çekmiş olduğu dataları memory'e almasın. Daha performanslı çalışsın. AsNoTracking demezsek EfCore bu dataları çeker ve durumlarını izler. Böylelikle performanslı olmaz.
            return _dbSet.AsNoTracking().AsQueryable();
        }

        public void Remove(TEntity entity)
        {
            _dbSet.Remove(entity);
        }

        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            _dbSet.RemoveRange(entities);
        }

        public async Task<TEntity> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await _dbSet.SingleOrDefaultAsync(predicate);
        }

        public void Update(TEntity entity)
        {
            _dbSet.Update(entity);
        }

        public IQueryable<TEntity> Where(Expression<Func<TEntity, bool>> predicate)
        {
            return _dbSet.Where(predicate);
        }
    }
}
