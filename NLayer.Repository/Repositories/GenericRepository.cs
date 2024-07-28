using Microsoft.EntityFrameworkCore;
using NLayer.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Repository.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly AppDbContext _context;
        protected readonly DbSet<T> _dbSet;
        //Constructor a geçireceğimiz değişkenlerimizi readonly yapmalıyız. Kazara başka şeyler set etmeyelim.(Best Practices)
        public GenericRepository(AppDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public async Task AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public async Task AddRangeAsync(IEnumerable<T> entities)
        {
            await _dbSet.AddRangeAsync(entities);
        }

        public async Task<bool> AnyAsync(Expression<Func<T, bool>> expression)
        {
            return await _dbSet.AnyAsync(expression); 
        }

        public void Delete(T entity)
        {
            _dbSet.Remove(entity);
        }

        public IQueryable<T> GetAll()
        {//AsNoTracking: EfCore çekmiş olduğu yasaları memory e almasın ki daha performanslı çalışsın. Eğer kullanmazsak çektiğimiz dataları memorye alır ve anlık olarak durumlarını track eder. performans kaybına neden olur despose edilene kadar.
            return _dbSet.AsNoTracking().AsQueryable();
        }

        public async Task<T> GetAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public void RemoveRange(IEnumerable<T> entities)
        {//Remove, update in asenkron olmamasının sebebi direkt veritabanı üzerinde değişiklik yapmadığı için, sadece aslında entitynin state durumunu değiştirmektedir. Ne zaman biz SaveChanges deriz işte ozaman veritabanı üzerinde bir değişiklik görürüz. Bu yüzden bu işlem üzerinde async tanımlaması yapmak gereksizdir.
            _dbSet.RemoveRange(entities);
        }

        public void Update(T entity)
        {
            _dbSet.Update(entity);
        }

        public IQueryable<T> Where(Expression<Func<T, bool>> expression)
        {
            return _dbSet.Where(expression);
        }
    }
}
